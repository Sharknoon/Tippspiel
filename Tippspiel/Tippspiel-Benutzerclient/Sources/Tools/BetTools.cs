using System.Collections.Generic;
using System.Linq;
using Tippspiel_Benutzerclient.ServiceReference;
using Tippspiel_Benutzerclient.Sources.Models;

namespace Tippspiel_Benutzerclient.Sources.Tools
{
    public class BetTools
    {
        public static List<SeasonBetEntry> GetBetsFor(SeasonMessage season, int matchDay)
        {
            Dictionary<int, SeasonBetEntry> bets = new Dictionary<int, SeasonBetEntry>();

            foreach (var bet in Tools.BetsOfSeasonOfMatchday.Values)
            {
                bets.Add(bet.Id, new SeasonBetEntry
                {
                    Awayteam = Tools.TeamsOfSeason[Tools.MatchesOfMatchdayOfSeason[bet.MatchId].AwayTeamId].Name
                });
            }

            return bets.Values.ToList();
        }
    }
}