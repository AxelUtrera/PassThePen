using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceContract(CallbackContract = typeof(IMatchCallback))]
    public interface IMatchManagement
    {
        [OperationContract(IsOneWay = true)]
        void SendCard(string card);

        [OperationContract(IsOneWay = true)]
        void SelectTurnTime();

        [OperationContract(IsOneWay = true)]
        void StartTurnSignal(string username);

        [OperationContract(IsOneWay = true)]
        void SetMatchOperationContext(string username);

        [OperationContract(IsOneWay = true)]
        void SendDraws(string username, byte[] draw);

        [OperationContract]
        Dictionary<string, int> GetPlayersScore();

        [OperationContract]
        void ObtainMatchWinner();
    }

    [ServiceContract]
    public interface IMatchCallback
    {
        [OperationContract(IsOneWay = true)]
        void DistributeCard(string card);

        [OperationContract(IsOneWay = true)]
        void DistributeTurnTime(int turnTime);

        [OperationContract(IsOneWay = true)]
        void ReturnStartTurnSignal(int turnNumber);

        [OperationContract(IsOneWay = true)]
        void DistributeDraws(Dictionary<string, byte[]> playersDraw);

        [OperationContract(IsOneWay = true)]
        void NotifyWinner(string winner);
    }
}
