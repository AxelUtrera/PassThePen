using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceContract]
    public interface IAutentication
    {
        [OperationContract]
        int AutenticatePlayer(DataAccess.Player player);

        [OperationContract]
        int AutenticateEmail(string email);

        [OperationContract]
        int CodeEmail(string to, String affair, int validationCode);
    }
}
