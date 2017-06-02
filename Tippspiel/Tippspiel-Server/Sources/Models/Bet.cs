using System;

namespace Tippspiel_Server.Sources.Models
{
    public class Bet
    {
        //DB Identifier and Locking
        public int Id { get; set; }
        public int Version { get; set; }

        //Informations from the DB
        public DateTime DateTime { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public Match Match { get; set; }
        public Bettor Bettor { get; set; }
    }
}