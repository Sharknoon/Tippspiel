using System.Windows;

namespace Tippspiel_Benutzerclient.Sources.Models
{
    public class SeasonBetEntry
    {
        public string Hometeam { get; set; } = "";
        public string Awayteam { get; set; } = "";
        public Visibility MatchUpcoming { get; set; } = Visibility.Visible;
        public int ButtonsHeight { get; set; } = 0;
        public string HometeamScore { get; set; } = "";
        public string HometeamBet { get; set; } = "";
        public string AwayteamScore { get; set; } = "";
        public string AwayteamBet { get; set; } = "";
        public string DateTime { get; set; } = "";
    }
}