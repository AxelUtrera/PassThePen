using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceContract]
    public interface IPlayerManagement
    {
        [OperationContract]
        int AddPlayer(Player player);

        [OperationContract]
        int UpdateDataPlayer(string username, Player player);

        [OperationContract]
        Player GetDataPlayer(string username);

        [OperationContract]
        int UpdatePlayerPassword(string username, string password);

        [OperationContract]
        int UpdatePassword(string email, string password);

        [OperationContract]
        void GetFriends(String username);
    }
            
      
}
