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
    public interface IPlayerConnection
    {
        [OperationContract]
        void Connect(string username);

        [OperationContract]
        void Disconnect(string username);

        [OperationContract (IsOneWay = true)]
        void SendOnlinePlayers(string username);

        [OperationContract]
        List<string> GetNameOnlinePlayers();

        [OperationContract]
        void SendMathInvitation(string invitingPlayer, string invitedPlayer);

        [OperationContract]
        int FindPlayerIsConected(string usernamePlayer);

        [OperationContract]
        int FindPlayerInGroup(string usernameToFind);

        [OperationContract]
        int GroupIsNotFull();

        [OperationContract]
        List<string> GetListUsernamesPlayersInGroup();
    }

    [ServiceContract]
    public interface IPlayersServicesCallBack
    {
        [OperationContract(IsOneWay = true)]
        void PlayersCallBack(Friends[] friends);


        [OperationContract]
        int NotifyMatchInvitation(string invitingPlayer);
    }
}

