﻿using Domain;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public int UpdatePassword(string SendEmail, string password)
        {
            return playerLogic.UpdatePasswordEmail(SendEmail, password);
        }

        public Friends[] GetFriends(String username)
        {
            List<Friends> friends = playerLogic.RecoverFriends(username);
            return friends.ToArray();
        }

        public int DeleteFriend(Friends friend)
        {
            return playerLogic.DeleteFriend(friend);
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
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.AutenticatePlayer(player);
        }

        public int AutenticateEmail(string email)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.AutenticateEmail(email);
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

        public List<FriendRequest> GetFriendRequestsList(string player)
        {
            return friendRequestLogic.GetFriendRequestsOfPlayer(player);
        }

        public int SendFriendRequests(FriendRequest friendRequests)
        {
            return friendRequestLogic.SendFriendRequests(friendRequests);
        }
    }

    public partial class ImplementationServices : IPlayerConnection
    {
        private List<ConnectedUser> users = new List<ConnectedUser>();
        private List<ConnectedUser> playersInGroup = new List<ConnectedUser>();

        public void Connect(string username)
        {
            ConnectedUser user = new ConnectedUser()
            {
                username = username,
                operationContext = OperationContext.Current
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
            

            if (FindPlayerInGroup(invitingPlayer) == userNotFound)
            {
                matchHost.hostState = true;
                playersInGroup.Add(matchHost);
            }

            if (userConnected.operationContext.GetCallbackChannel<IPlayersServicesCallBack>().NotifyMatchInvitation(invitingPlayer) == operationOK)
            {
                playersInGroup.Add(userConnected);
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

            if (playersInGroup.Count() <=  6)
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
    }

    public partial class ImplementationServices : IMatchManagement
    {

        public void SelectTurnTime()
        {
            int[] seconds = { 15, 20, 25, 30 };
            Random random = new Random();
            int time = seconds[random.Next(seconds.Length)];
            OperationContext.Current.GetCallbackChannel<IMatchCallback>().DistributeTurnTime(time);
        }

        public void SendCard(string card)
        {
            OperationContext.Current.GetCallbackChannel<IMatchCallback>().DistributeCard(card);
        }

  
        public void StartTurnSignal()
        {
            OperationContext.Current.GetCallbackChannel<IMatchCallback>().ReturnStartTurnSignal();
        }
    }

    public partial class ImplementationServices : IChatServices
    {

        public void SendMessage(string senderUsername, string message)
        {
            ChatLogic chatLogic = new ChatLogic();
            string completeMessage = chatLogic.BuildMessage(senderUsername, message);
            OperationContext.Current.GetCallbackChannel<IChatServiceCallback>().MessageSend(completeMessage);
        }

    }

    public partial class ImplementationServices : IDrawReviewService
    {
        public void SendDraws(byte[] draw)
        {
            OperationContext.Current.GetCallbackChannel<IDrawReviewCallback>().DistributeDraws(draw);
        }
    }
}
