using System.Runtime.Serialization;

namespace Tippspiel_Server.Sources.Models
{
    [DataContract]
    public class Bettor
    {
        //DB Identifier and Locking
        public int Id { get; set; }
        public int Version { get; set; }

        //Informations from the DB
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string Lastname { get; set; }
    }
}