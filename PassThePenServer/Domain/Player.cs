using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public byte[] profileImage { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   username == player.username &&
                   name == player.name &&
                   lastname == player.lastname &&
                   email == player.email;
        }
    }
}
