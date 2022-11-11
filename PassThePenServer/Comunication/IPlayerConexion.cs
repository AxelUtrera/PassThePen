using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceContract(CallbackContract = typeof(IPlayersServicesCallBack))]
    public interface IPlayerConexion
    {
        [OperationContract]
        void Connect(string username);

        [OperationContract]
        void Disconnect(string username);

        [OperationContract]
        void SendOnlinePlayers(string username);
    }

    [ServiceContract]
    public interface IPlayersServicesCallBack
    {
        [OperationContract(IsOneWay = true)]
        void PlayersCallBack(Friends[] friends);
    }
}

