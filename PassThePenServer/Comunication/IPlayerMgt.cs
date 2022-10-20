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
            int AddPlayer(Player player);

            [OperationContract]
            int AutenticatePlayer(string username, string password);
      }
}
