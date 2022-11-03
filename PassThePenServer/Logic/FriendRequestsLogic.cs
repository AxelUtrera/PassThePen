using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FriendRequestsLogic
    {

        public List<Domain.FriendRequest> GetFriendRequestsOfPlayer(string username)
        {
            List<Domain.FriendRequest> friendRequestList = new List<Domain.FriendRequest>();

            using (var context = new passthepenEntities())
            {
                var listRequests = context.FriendRequest
                                   .Where(b => b.usernamePlayer.Equals(username) && b.status.Equals("Pending"))
                                   .ToList();
                                 
                foreach(DataAccess.FriendRequest request in listRequests)
                {
                    Domain.FriendRequest friendRequest = new Domain.FriendRequest
                    {
                        idRequest = request.idRequest,
                        usernamePlayer = request.usernamePlayer,
                        friendUsername = request.friendUsername,
                        status = request.status
                    };

                    friendRequestList.Add(friendRequest);
                }
                return friendRequestList;
            }

        }

    }
}
