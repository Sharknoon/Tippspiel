using System;
using System.Runtime.Serialization;

namespace Tippspiel_Server.Sources.Models
{
    [DataContract]
    public class Match
    {
        //DB Identifier and Locking
        public int Id { get; set; }
        public int Version { get; set; }

        //Informations from the DB
        [DataMember]
        public int MatchDay { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public int HomeTeamScore { get; set; }
        [DataMember]
        public int AwayTeamScore { get; set; }
        [DataMember]
        public Team HomeTeam { get; set; }
        [DataMember]
        public Team AwayTeam { get; set; }
        [DataMember]
        public Season Season { get; set; }
    }
}