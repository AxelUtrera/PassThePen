﻿using Domain;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class ImplementationServices : IPlayerManagement
    {
        public int AddPlayer(Player player)
        {
            return PlayerLogic.AddPlayerToDB(player);
        }

        public int UpdateDataPlayer(string username, Player player)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.UpdateDataPlayer(username, player);
        }

        public Player GetDataPlayer(string username)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.ObtainPlayerData(username);
        }

        public int UpdatePlayerPassword(string username, string password)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.UpdatePassword(username, password);
        }

        public int UpdatePassword(string SendEmail, string password)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.UpdatePasswordEmail(SendEmail, password);
        }

        public void GetFriends(String username)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            List<Friends> friends = playerLogic.RecoverFriends(username);
            Friends[] friendsArray = new Friends[friends.Count];
            for(int index = 0; index < friends.Count; index++)
            {
                friendsArray[index] = friends[index];
            }
            
            RecoverPlayers(friendsArray, username);
        }
    }

    public partial class ImplementationServices : IAutentication
    {
        public int AutenticatePlayer(Player player)
        {
            PlayerLogic playerLogic = new PlayerLogic();
            return playerLogic.AutenticatePlayerDB(player);
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
       
        public int DeclineFriendRequests(Player player)
        {
            throw new NotImplementedException();
        }

        public List<FriendRequest> GetFriendRequestsList(string user)
        {
            FriendRequestsLogic friendRequestsLogic = new FriendRequestsLogic();
            return friendRequestsLogic.GetFriendRequestsOfPlayer(user);
        }

        public int SendFriendRequests(Player player)
        {
            throw new NotImplementedException();
        }
    }

    public partial class ImplementationServices : IPlayerConexion
    {
        List<ConnectedUser> users = new List<ConnectedUser>();

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

        public void RecoverPlayers(Friends[] friends, string username)
        {   

            
            for(int index = 0; index < users.Count; index++)
            {
                for(int index2 = 0; index2 < friends.Length; index2++)
                {
                    if (! friends[index2].status)
                    {
                        if (users[index].username.Equals(friends[index2].friendUsername))
                        {
                            friends[index2].status = true;
                        }
                    }
                }
            }
            for(int index = 0; index < users.Count; index++)
            {
                if (username.Equals(users[index].username))
                {
                    users[index].operationContext.GetCallbackChannel<IPlayersServicesCallBack>().PlayersCallBack(friends);
                }   
            }
            
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
