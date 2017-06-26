namespace Tippspiel_Benutzerclient.Sources.Models
{
    public class SeasonBetEntry
    {
        public string Hometeam { get; set; } = "";
        public string Awayteam { get; set; } = "";
        public bool MatchPlayed { get; set; } = false;
        public int HometeamScore { get; set; } = 0;
        public int AwayteamScore { get; set; } = 0;
    }
}