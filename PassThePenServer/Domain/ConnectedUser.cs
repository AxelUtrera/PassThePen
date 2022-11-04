using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ConnectedUser
    {
        public string username { get; set; }
        public OperationContext operationContext { get; set; }
    }
}
