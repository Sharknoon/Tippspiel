using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tippspiel_Server.Sources.Models
{
    [DataContract]
    public class Team
    {
        //DB Identifier and Locking
        public int Id { get; set; }
        public int Version { get; set; }

        //Informations from the DB
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public IList<Season> Seasons { get; set; }

    }
}