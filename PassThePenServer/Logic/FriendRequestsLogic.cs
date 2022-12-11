using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FriendRequestsLogic
    {

        public int AcceptFriendRequest(Domain.FriendRequest friendRequest)
        {
            int operationResult = 500;

            using (var context = new passthepenEntities())
            {

                //Se realizan 2 registros para que haya relacion desde los dos usuarios, al que se le envio la solicitud y el que la acepto
                var registerFriendApplicantToPlayer = context.Friends.Add(new DataAccess.Friends()
                {
                    usernamePlayer = friendRequest.usernamePlayer,
                    friendUsername = friendRequest.friendUsername
                });

                context.Friends.Add(new DataAccess.Friends()
                {
                    usernamePlayer = friendRequest.friendUsername,
                    friendUsername = friendRequest.usernamePlayer
                });

                context.SaveChanges();

                int statusFriendRequest = DeleteFriendRequest(friendRequest);

                if (registerFriendApplicantToPlayer != null && statusFriendRequest == 200)
                {
                    operationResult = 200;
                }


            }

            return operationResult;
        }


        public int DeleteFriendRequest(Domain.FriendRequest friendRequest)
        {
            int operationResult = 500;

            using (var context = new passthepenEntities())
            {
                var friendRequestInDataBase = context.FriendRequest.Where(u => u.idRequest == friendRequest.idRequest).First();

                if (friendRequestInDataBase != null)
                {
                    context.FriendRequest.Remove(friendRequestInDataBase);
                    context.SaveChanges();
                    operationResult = 200;
                }
            }

            return operationResult;
        }


        public List<Domain.FriendRequest> GetFriendRequestsOfPlayer(string username)
        {
            List<Domain.FriendRequest> friendRequestList = new List<Domain.FriendRequest>();

            using (var context = new passthepenEntities())
            {
                var listRequests = context.FriendRequest
                                   .Where(b => b.usernamePlayer.Equals(username))
                                   .ToList();

                foreach (DataAccess.FriendRequest request in listRequests)
                {
                    Domain.FriendRequest friendRequest = new Domain.FriendRequest
                    {
                        idRequest = request.idRequest,
                        usernamePlayer = request.usernamePlayer,
                        friendUsername = request.friendUsername,
                    };

                    friendRequestList.Add(friendRequest);
                }
                return friendRequestList;
            }

        }

        public int SendFriendRequests(Domain.FriendRequest friendRequests)
        {
            int operationCode = 500;
            int validationOKCode = 200; 
            DataAccess.FriendRequest dataAccesFriendRequests = ConvertToDataAccessFriendRequests(friendRequests);

            using (var context = new passthepenEntities())
            {
                if (ValidateExistFriendRequestOrFriend(friendRequests) == validationOKCode && friendRequests.usernamePlayer != friendRequests.friendUsername)
                {
                    var friendRequestDataBase = context.FriendRequest.Add(dataAccesFriendRequests);
                    context.SaveChanges();

                    if (friendRequestDataBase != null)
                    {
                        operationCode = 200;
                    }
                }                
            }
            return operationCode;
        }

        private int ValidateExistFriendRequestOrFriend(Domain.FriendRequest friendRequest)
        {
            int operationResult = 500;

            using (var context = new passthepenEntities())
            {
                try
                {
                    DataAccess.Friends friendInDataBase = context.Friends.Where(u => u.usernamePlayer.Equals(friendRequest.usernamePlayer) && u.friendUsername.Equals(friendRequest.friendUsername)).FirstOrDefault();
                    DataAccess.FriendRequest friendRequestsInDataBase = context.FriendRequest.Where(u => u.usernamePlayer.Equals(friendRequest.usernamePlayer) && u.friendUsername.Equals(friendRequest.friendUsername)).FirstOrDefault();

                    if (friendInDataBase == null && friendRequestsInDataBase == null)
                    {
                        operationResult = 200;
                    }

                    Console.WriteLine(operationResult);
                }
                catch (EntityException ex)
                {
                    //manejar
                } 
            }
            return operationResult;
        }

        private DataAccess.FriendRequest ConvertToDataAccessFriendRequests(Domain.FriendRequest domainFriendRequests)
        {
            return new DataAccess.FriendRequest()
            {
                usernamePlayer = domainFriendRequests.usernamePlayer,
                friendUsername = domainFriendRequests.friendUsername,
            };

        }
    }
}
