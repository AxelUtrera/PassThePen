﻿using Domain;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class ImplementationServices : IPlayerManagement
    {
        PlayerLogic playerLogic = new PlayerLogic();

        public int AddPlayer(Player player)
        {
            return playerLogic.AddPlayer(player);
        }

        public int UpdateDataPlayer(string username, Player player)
        {
            return playerLogic.UpdateDataPlayer(username, player);
        }

        public Player GetDataPlayer(string username)
        {
            return playerLogic.ObtainPlayerData(username);
        }

        public int UpdatePlayerPassword(string username, string password)
        {
            return playerLogic.UpdatePassword(username, password);
        }

        public int UpdatePassword(string email, string password)
        {
            return playerLogic.UpdatePasswordEmail(email, password);
        }

        public Friends[] GetFriends(String username)
        {
            List<Friends> friends = playerLogic.RecoverFriends(username);
            return friends.ToArray();
        }

        public int DeleteFriend(Friends friendToDelete)
        {
            return playerLogic.DeleteFriend(friendToDelete);
        }

        public int FindPlayer(string username)
        {
            return playerLogic.FindPlayer(username);
        }
    }

    public partial class ImplementationServices : IAutentication
    {
        public int AutenticatePlayer(Player player)
        {
            PlayerLogic newPlayerLogic = new PlayerLogic();
            return newPlayerLogic.AutenticatePlayer(player);
        }

        public int AutenticateEmail(string email)
        {
            PlayerLogic playerNewLogic = new PlayerLogic();
            return playerNewLogic.AutenticateEmail(email);
        }

        public int CodeEmail(string to, String affair, int validationCode)
        {
            SendEmail sendEmail = new SendEmail();
            return sendEmail.SendNewEmail(to, affair, validationCode);
        }
    }

    public partial class ImplementationServices : IFriendRequests
    {
        FriendRequestsLogic friendRequestLogic = new FriendRequestsLogic();

        public int AcceptFriendRequest(FriendRequest friendRequest)
        {
            return friendRequestLogic.AcceptFriendRequest(friendRequest);
        }

        public int DeclineFriendRequests(FriendRequest friendRequest)
        {
            return friendRequestLogic.DeleteFriendRequest(friendRequest);
        }

        public List<FriendRequest> GetFriendRequestsList(string username)
        {
            return friendRequestLogic.GetFriendRequestsOfPlayer(username);
        }

        public int SendFriendRequests(FriendRequest friendRequest)
        {
            return friendRequestLogic.SendFriendRequests(friendRequest);
        }
    }


    public partial class ImplementationServices : IPlayerConnection
    {
        private List<ConnectedUser> users = new List<ConnectedUser>();
        private static List<ConnectedUser> playersInGroup = new List<ConnectedUser>();

        public void Connect(string username)
        {
            ConnectedUser user = new ConnectedUser()
            {
                username = username,
                operationContext = OperationContext.Current,
                score = 0
            };

            users.Add(user);
        }

        public void Disconnect(string username)
        {
            var user = users.FirstOrDefault(i => i.username == username);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public List<string> GetNameOnlinePlayers()
        {
            List<string> onlinePlayers = new List<string>();
            foreach (ConnectedUser player in users)
            {
                onlinePlayers.Add(player.username);
            }

            return onlinePlayers;
        }

        public void SendOnlinePlayers(string username)
        {
            Friends[] friends = GetFriends(username);
            users.Find(us => us.username.Equals(username)).operationContext.GetCallbackChannel<IPlayersServicesCallBack>().PlayersCallBack(friends);
        }


        public void SendMathInvitation(string invitingPlayer, string invitedPlayer)
        {
            int operationOK = 200;
            int userNotFound = 404;

            ConnectedUser userConnected = users.FirstOrDefault(user => user.username.Equals(invitedPlayer));
            ConnectedUser matchHost = users.FirstOrDefault(user => user.username.Equals(invitingPlayer));

            if (userConnected != null)
            {
                if (FindPlayerInGroup(invitingPlayer) == userNotFound)
                {
                    if (matchHost != null)
                    {
                        matchHost.hostState = true;
                    }

                    playersInGroup.Add(matchHost);
                }


                if (userConnected.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().NotifyMatchInvitation(invitingPlayer) == operationOK)
                {
                    playersInGroup.Add(userConnected);
                }
            }



        }

        public int FindPlayerIsConected(string usernamePlayer)
        {
            int isConected = 200;
            int userNotConected = 404;

            if (users.FirstOrDefault(user => user.username.Equals(usernamePlayer)) == null)
            {
                isConected = userNotConected;
            }

            return isConected;
        }

        public int FindPlayerInGroup(string usernameToFind)
        {
            int statusUser = 200;
            int userNotFound = 404;
            if (playersInGroup.FirstOrDefault(user => user.username.Equals(usernameToFind)) == null)
            {
                statusUser = userNotFound;
            }
            return statusUser;
        }

        public int GroupIsNotFull()
        {
            int statusCode = 500;

            if (playersInGroup.Count <= 6)
            {
                statusCode = 200;
            }
            return statusCode;
        }


        public List<string> GetListUsernamesPlayersInGroup()
        {
            List<string> groupPlayers = new List<string>();

            foreach (ConnectedUser playerConnected in playersInGroup)
            {
                groupPlayers.Add(playerConnected.username);
            }
            return groupPlayers;
        }

        public void StartMatch(string username)
        {
            foreach (ConnectedUser user in playersInGroup)
            {
                if (user.username.Equals(username) && user.hostState)
                {
                    foreach (ConnectedUser connectedUser in playersInGroup)
                    {
                        connectedUser.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().OpenMatchWindow();
                    }
                }
            }
        }
    }

    public partial class ImplementationServices : IMatchManagement
    {
        private int turnNumber = 0;

        public void SelectTurnTime()
        {
            int[] seconds = { 15, 20, 25, 30 };
            Random random = new Random();
            int time = seconds[random.Next(seconds.Length)];
            foreach (ConnectedUser user in playersInGroup)
            {
                user.matchContext.GetCallbackChannel<IMatchCallback>().DistributeTurnTime(time);
            }
        }


        public void SendCard(string card)
        {
            foreach (ConnectedUser user in playersInGroup)
            {
                user.matchContext.GetCallbackChannel<IMatchCallback>().DistributeCard(card);
            }
        }


        public void SetMatchOperationContext(string username)
        {

            foreach (ConnectedUser user in playersInGroup)
            {
                if (user.username.Equals(username))
                {
                    user.matchContext = OperationContext.Current;
                }
            }
        }


        public void StartTurnSignal(string username)
        {
            foreach (ConnectedUser user in playersInGroup)
            {
                if (user.username.Equals(username) && user.hostState)
                {
                    turnNumber++;
                    if(turnNumber == 11)
                    {
                        ObtainMatchWinner();
                    }
                    else
                    {
                        foreach (ConnectedUser matchUser in playersInGroup)
                        {
                            matchUser.matchContext.GetCallbackChannel<IMatchCallback>().ReturnStartTurnSignal(turnNumber);
                        }
                    }
                    
                }
            }
        }


        public void SendDraws(string username, byte[] draw)
        {
            playersDraws.Add(username, draw);

            if (playersDraws.Count() == playersInGroup.Count())
            {
                foreach (ConnectedUser player in playersInGroup)
                {
                    player.matchContext.GetCallbackChannel<IMatchCallback>().DistributeDraws(playersDraws);
                }
            }

        }


        public Dictionary<string, int> GetPlayersScore()
        {
            Dictionary<string, int> playersScore = new Dictionary<string, int>();
            foreach(ConnectedUser user in playersInGroup)
            {
                playersScore.Add(user.username, user.score);
            }
            return playersScore;
        }


        public void ObtainMatchWinner()
        {
            int maxScore = playersInGroup.Max(s => s.score);
            ConnectedUser winner = playersInGroup.Where(w => w.score == maxScore).FirstOrDefault();

            MatchLogic matchLogic = new MatchLogic();
            int result = matchLogic.AddMatchWinner(winner.username);

            if(result == 200)
            {
                foreach(ConnectedUser user in playersInGroup)
                {
                    user.matchContext.GetCallbackChannel<IMatchCallback>().NotifyWinner(winner.username);
                }
            }
        }
    }


    public partial class ImplementationServices : IChatServices
    {
        public void SendMessage(string senderUsername, string message)
        {
            ChatLogic chatLogic = new ChatLogic();
            string completeMessage = chatLogic.BuildMessage(senderUsername, message);

            foreach (ConnectedUser user in playersInGroup)
            {
                user.chatContext.GetCallbackChannel<IChatServiceCallback>().MessageSend(completeMessage);
            }

        }


        public void SetChatOperationContext(string username)
        {
            foreach (ConnectedUser user in playersInGroup)
            {
                if (user.username.Equals(username))
                {
                    user.chatContext = OperationContext.Current;
                }
            }
        }
    }

    public partial class ImplementationServices : IDrawReviewService
    {
        Dictionary<string, byte[]> playersDraws = new Dictionary<string, byte[]>();

        public void AddPlayerScore(Dictionary<string, int> playerScore)
        {
            foreach(ConnectedUser player in playersInGroup)
            {
                player.score += playerScore.FirstOrDefault(x => x.Key == player.username).Value;
            }

            foreach(ConnectedUser connectedUser in playersInGroup)
            {
                Console.WriteLine(connectedUser.username + "---" + connectedUser.score);
            }
        }


        
        public void SetDrawReviewContext(string username)
        {
            foreach(ConnectedUser player in playersInGroup)
            {
                if (player.username.Equals(username))
                {
                    player.drawContext = OperationContext.Current;
                }
            }
        }
    }

}
