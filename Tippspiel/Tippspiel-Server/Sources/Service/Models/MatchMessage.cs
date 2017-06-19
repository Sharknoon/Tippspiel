using System;

namespace Tippspiel_Server.Sources.Service.Models
{
    public class MatchMessage
    {
        public int Id { get; set; } = -1;
        public int MatchDay { get; set; }
        public DateTime DateTime { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int SeasonId { get; set; }
    }
}