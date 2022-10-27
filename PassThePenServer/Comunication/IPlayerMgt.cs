using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceContract]
    public interface IPlayerMgt
    {
        [OperationContract]
        int AddPlayer(DataAccess.Player player);

        [OperationContract]
        int AutenticatePlayer(DataAccess.Player player);

        [OperationContract]
        int AutenticateEmail(string email);

        [OperationContract]
        Boolean UpdateDataPlayer(string username, Player player);

        [OperationContract]
        Player GetDataPlayer(string username);

        [OperationContract]
        Boolean UpdatePlayerPassword(string username, string password);

        [OperationContract]
        int CodeEmail(string to, String affair, int validationCode);

        [OperationContract]
        int UpdatePassword(string email, string password);
    }
            
      
}
