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


        public static Dictionary<int, MatchMessage> MatchesOfMatchdayOfSeason { get; private set; } =
            new Dictionary<int, MatchMessage>();

        public static Dictionary<int, BetMessage> BetsOfSeasonOfMatchday { get; private set; } =
            new Dictionary<int, BetMessage>();

        public static Dictionary<int, TeamMessage> TeamsOfSeason { get; private set; } =
            new Dictionary<int, TeamMessage>();

        public static Dictionary<int, BettorMessage> Bettors { get; private set; } =
            new Dictionary<int, BettorMessage>();

        public static Dictionary<int, SeasonMessage> Seasons { get; private set; } =
            new Dictionary<int, SeasonMessage>();


        private static bool _firstRun = true;

        public static void Reload(int seasonId, int matchDay, int bettorId)
        {
            if (_firstRun)
            {
                Init();
                _firstRun = false;
            }

            if (seasonId == _currentSeasonId && matchDay == _currentMatchDay) return;//Nothing changed

            if (seasonId == _currentSeasonId && matchDay != _currentMatchDay) //Only matchday changed
            {
                OnMatchdayChanged(matchDay);
                return;
            }

            if (seasonId != _currentSeasonId) //Season changed, Matchday even if the same has other matches
            {
                OnSeasonChanged(seasonId, bettorId);
                OnMatchdayChanged(matchDay);
            }
        }

        public static void Init()
        {
            Seasons = Service.GetAllSeasons().ToDictionary(season => season.Id, season => season);
            _firstRun = false;
        }

        private static void OnSeasonChanged(int seasonId, int bettorId) //From DB
        {
            _currentSeasonId = seasonId;
            _matchesOfSeason = Service.GetAllMatchesForSeason(seasonId).ToDictionary(match => match.Id, match => match);
            if (bettorId != -1)
            {
                _betsOfSeason = Service.GetAllBetsForBettorInSeason(bettorId, seasonId)
                    .ToDictionary(bet => bet.Id, bet => bet);
            }
            TeamsOfSeason = Service.GetAllTeamsForSeason(seasonId).ToDictionary(team => team.Id, team => team);
            Bettors = Service.GetAllBettors().ToDictionary(bettor => bettor.Id, bettor => bettor);
        }

        private static void OnMatchdayChanged(int matchDay) //Locally
        {
            _currentMatchDay = matchDay;

            MatchesOfMatchdayOfSeason = _matchesOfSeason.Values
                .Where(match => match.MatchDay <= matchDay)
                .ToDictionary(match => match.Id, match => match);
            BetsOfSeasonOfMatchday = _betsOfSeason.Values
                .Where(bet => MatchesOfMatchdayOfSeason.ContainsKey(bet.MatchId))
                .ToDictionary(bet => bet.Id, bet => bet);
        }
    }
}