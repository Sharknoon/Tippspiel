using System.Windows;

namespace Tippspiel_Benutzerclient.Sources.Models
{
    public class SeasonBetEntry
    {
        public string Hometeam { get; set; } = "";
        public string Awayteam { get; set; } = "";
        public Visibility MatchUpcoming { get; set; } = Visibility.Visible;
        public string HometeamScore { get; set; } = "";
        public string AwayteamScore { get; set; } = "";
        public string DateTime { get; set; } = "";
    }
}