using System.Windows;

namespace Tippspiel_Benutzerclient.Sources.Models
{
    public class SeasonBetEntry
    {
        public int BetId { get; set; } = -1;
        public int MatchId { get; set; } = -1;
        public string Hometeam { get; set; } = "";
        public string Awayteam { get; set; } = "";
        public Visibility MatchUpcoming { get; set; } = Visibility.Visible;
        public int ButtonsHeight { get; set; } = 0;
        public string HometeamScore { get; set; } = "";
        public string HometeamBet { get; set; } = "";
        public string AwayteamScore { get; set; } = "";
        public string AwayteamBet { get; set; } = "";
        public int TempHometeamScore { get; set; } = 0;
        public int TempHometeamBet { get; set; } = -1;
        public int TempAwayteamScore { get; set; } = 0;
        public int TempAwayteamBet { get; set; } = -1;
        public string DateTime { get; set; } = "";
        public bool Changed { get; set; }= false;
    }
}