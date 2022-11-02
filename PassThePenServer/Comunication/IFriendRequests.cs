using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{

    [ServiceContract]
    public interface IFriendRequests
    {
        [OperationContract]
        List<Domain.FriendRequest> GetFriendRequestsList(string username);

        [OperationContract]
        int SendFriendRequests(Player player);

        //operation contract insecure desicion...
        [OperationContract]
        int DeclineFriendRequests(Player player);
    }
}
