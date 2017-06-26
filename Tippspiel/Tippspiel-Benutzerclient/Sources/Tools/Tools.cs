using System.Collections.Generic;
using System.Linq;
using Tippspiel_Benutzerclient.ServiceReference;

namespace Tippspiel_Benutzerclient.Sources.Tools
{
    public class Tools
    {
        private static readonly ServiceClient Service = WcfHelper.ServiceClient;
        private static int _currentSeasonId = -1;
        private static int _currentMatchDay = -1;

        private static Dictionary<int, MatchMessage> _matchesOfSeason =
            new Dictionary<int, MatchMessage>();

        private static Dictionary<int, BetMessage> _betsOfSeason =
            new Dictionary<int, BetMessage>();


        public static Dictionary<int, MatchMessage> MatchesOfSeasonOfMatchday { get; private set; } =
            new Dictionary<int, MatchMessage>();

        public static Dictionary<int, BetMessage> BetsOfSeasonOfMatchday { get; private set; } =
            new Dictionary<int, BetMessage>();

        public static Dictionary<int, TeamMessage> TeamsOfSeason { get; private set; } =
            new Dictionary<int, TeamMessage>();

        public static Dictionary<int, BettorMessage> Bettors { get; private set; } =
            new Dictionary<int, BettorMessage>();


        public static void Reload(int seasonId, int matchDay)
        {
            if (seasonId == _currentSeasonId && matchDay == _currentMatchDay) return;

            if (seasonId == _currentSeasonId && matchDay != _currentMatchDay) //Only matchday changed
            {
                ReloadMatchdayLocally(matchDay);
                return;
            }

            if (seasonId != _currentSeasonId) //Season changed, Matchday even if the same has other matches
            {
                ReloadSeasonFromDb(seasonId);
                ReloadMatchdayLocally(matchDay);
            }
        }

        private static void ReloadSeasonFromDb(int seasonId)
        {
            _currentSeasonId = seasonId;
            _matchesOfSeason = Service.GetAllMatchesForSeason(seasonId).ToDictionary(match => match.Id, match => match);
            _betsOfSeason = Service.GetAllBetsForSeason(seasonId).ToDictionary(bet => bet.Id, bet => bet);
            TeamsOfSeason = Service.GetAllTeamsForSeason(seasonId).ToDictionary(team => team.Id, team => team);
            Bettors = Service.GetAllBettors().ToDictionary(bettor => bettor.Id, bettor => bettor);
        }

        private static void ReloadMatchdayLocally(int matchDay)
        {
            _currentMatchDay = matchDay;
            MatchesOfSeasonOfMatchday = _matchesOfSeason.Values
                .Where(match => match.MatchDay <= matchDay)
                .ToDictionary(match => match.Id, match => match);
            BetsOfSeasonOfMatchday = _betsOfSeason.Values
                .Where(bet => MatchesOfSeasonOfMatchday.ContainsKey(bet.MatchId))
                .ToDictionary(bet => bet.Id, bet => bet);
        }
    }
}