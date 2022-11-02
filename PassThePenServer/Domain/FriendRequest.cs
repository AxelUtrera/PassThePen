using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class FriendRequest
    {
        [DataMember]
        public int idRequest { get; set; }
        [DataMember]
        public string usernamePlayer { get; set; }
        [DataMember]
        public string friendUsername { get; set; }
        [DataMember]
        public string status { get; set; }

    }
}
