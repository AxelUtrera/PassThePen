using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Comunication
{
    [ServiceContract]
    public interface IDrawReviewService
    {
        
        [OperationContract]
        void SetDrawReviewContext(string username);

        [OperationContract]
        void AddPlayerScore(Dictionary<string, int> playerScore);
    }

}
