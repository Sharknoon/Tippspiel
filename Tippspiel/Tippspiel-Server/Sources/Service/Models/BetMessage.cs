using System;

namespace Tippspiel_Server.Sources.Service.Models
{
    public class BetMessage
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int MatchId { get; set; }
        public int BettorId { get; set; }
    }
}