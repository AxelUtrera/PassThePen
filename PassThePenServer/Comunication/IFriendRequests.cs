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
        int AcceptFriendRequest(FriendRequest friendRequest);

        [OperationContract]
        int DeclineFriendRequests(FriendRequest friendRequest);

        [OperationContract]
        List<Domain.FriendRequest> GetFriendRequestsList(string username);

        [OperationContract]
        int SendFriendRequests(FriendRequest friendRequest);
       
    }
}
