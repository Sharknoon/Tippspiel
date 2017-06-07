using System;
using System.Runtime.Serialization;

namespace Tippspiel_Server.Sources.Models
{
    [DataContract]
    public class Bet
    {
        //DB Identifier and Locking
        public int Id { get; set; }
        public int Version { get; set; }

        //Informations from the DB
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public int HomeTeamScore { get; set; }
        [DataMember]
        public int AwayTeamScore { get; set; }
        [DataMember]
        public Match Match { get; set; }
        [DataMember]
        public Bettor Bettor { get; set; }
    }
}