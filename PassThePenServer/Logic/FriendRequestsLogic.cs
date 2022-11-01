using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class FriendRequestsLogic
    {

        public List<FriendRequest> GetFriendRequestsOfPlayer(string username)
        {
            List<FriendRequest> friendRequestsList = null;
            using (var context = new passthepenEntities())
            {
                friendRequestsList = (from request in context.FriendRequest
                                      where request.usernamePlayer.Equals(username)
                                      && request.status.Equals("Pending")
                                      select request).ToList();
                               
            }

            return friendRequestsList;
        }

    }
}
