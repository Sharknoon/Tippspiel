using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tippspiel_Server.Sources.Models
{
    [DataContract]
    public class Season
    {
        //DB Identifier and Locking
        public int Id { get; set; }
        public int Version { get; set; }

        //Informations from the DB
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Sequence { get; set; }
        [DataMember]
        public IList<Team> Teams { get; set; }
    }
}