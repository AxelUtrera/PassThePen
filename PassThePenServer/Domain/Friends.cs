using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class Friends
    {
        [DataMember]
        public int idPlayerFriends { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string friendUsername { get; set; }
    }
}
