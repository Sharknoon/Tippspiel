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

        public static Dictionary<int, MatchMessage> MatchesOfSeason =
            new Dictionary<int, MatchMessage>();

        //all matchdays plus current
        public static Dictionary<int, MatchMessage> MatchesOfMatchdayOfSeason { get; private set; } =
            new Dictionary<int, MatchMessage>();

        public static Dictionary<int, BetMessage> BetsOfSeason { get; private set; } =
            new Dictionary<int, BetMessage>();

        //all matchdays plus current
        public static Dictionary<int, BetMessage> BetsOfMatchdayOfSeason { get; private set; } = 
            new Dictionary<int, BetMessage>();

        public static Dictionary<int, TeamMessage> TeamsOfSeason { get; private set; } =
            new Dictionary<int, TeamMessage>();

        public static Dictionary<int, BettorMessage> Bettors { get; private set; } =
            new Dictionary<int, BettorMessage>();

        public static Dictionary<int, SeasonMessage> Seasons { get; private set; } =
            new Dictionary<int, SeasonMessage>();


        private static bool _firstRun = true;

        public static void Reload(int seasonId, int matchDay)
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
                OnSeasonChanged(seasonId);
                OnMatchdayChanged(matchDay);
            }
        }

        public static void Init()
        {
            Seasons = Service.GetAllSeasons().ToDictionary(season => season.Id, season => season);
            _firstRun = false;
        }

        private static void OnSeasonChanged(int seasonId) //From DB
        {
            _currentSeasonId = seasonId;
            MatchesOfSeason = Service.GetAllMatchesForSeason(seasonId).ToDictionary(match => match.Id, match => match);
            BetsOfSeason = Service.GetAllBetsForSeason(seasonId).ToDictionary(bet => bet.Id, bet => bet);
            TeamsOfSeason = Service.GetAllTeamsForSeason(seasonId).ToDictionary(team => team.Id, team => team);
            Bettors = Service.GetAllBettors().ToDictionary(bettor => bettor.Id, bettor => bettor);
        }

        private static void OnMatchdayChanged(int matchDay) //Locally
        {
            _currentMatchDay = matchDay;

            MatchesOfMatchdayOfSeason = MatchesOfSeason.Values
                .Where(match => match.MatchDay <= matchDay)
                .ToDictionary(match => match.Id, match => match);
            BetsOfMatchdayOfSeason = BetsOfSeason.Values
                .Where(bet => MatchesOfSeason[bet.MatchId]?.MatchDay <= matchDay)
                .ToDictionary(bet => bet.Id, bet => bet);
        }
    }
}