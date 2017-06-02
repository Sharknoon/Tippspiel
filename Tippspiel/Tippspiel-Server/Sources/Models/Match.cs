using System;

namespace Tippspiel_Server.Sources.Models
{
    public class Match
    {
        //DB Identifier and Locking
        public int Id { get; set; }
        public int Version { get; set; }

        //Informations from the DB
        public int MatchDay { get; set; }
        public DateTime DateTime { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Season Season { get; set; }
    }
}