using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceContract(CallbackContract = typeof(IDrawReviewCallback))]
    public interface IDrawReviewService
    {
        [OperationContract(IsOneWay = true)]
        void SendDraws(Byte[] draw);
    }

    [ServiceContract]
    public interface IDrawReviewCallback
    {
        [OperationContract(IsOneWay = true)]
        void DistributeDraws(Byte[] draw);
    }
}
