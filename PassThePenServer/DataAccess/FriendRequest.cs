//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class FriendRequest
    {
        [DataMember]
        public int idRequest { get; set; }
        [DataMember]
        public string usernamePlayer { get; set; }
        [DataMember]
        public string friendUsername { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public virtual Player Player { get; set; }
    }
}
