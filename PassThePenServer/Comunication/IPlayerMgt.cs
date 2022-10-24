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
      }
}
