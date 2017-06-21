using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FluentNHibernate.Conventions;
using FluentNHibernate.Utils;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Generation
{
    public class SeasonGeneration
    {
        public static DateTime CurrentDate;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void GenerateSeason(DateTime date, SeasonMessage season)
        {
            CurrentDate = date;

            var allTeams = Service.GetAllTeams().ToList().Where(team => team.SeasonIDs.Contains(season.Id)).ToList();

            var random = new Random();
            var shuffeledTeams = allTeams.OrderBy(item => random.Next()).ToList();

            var rot = Rotator.CreateRotator(shuffeledTeams);

            var firstRound = new Dictionary<int,List<MatchMessage>>();//Spieltag => Spiele
            for (var i = 0; i < 17; i++)//For every matchday
            {
                var pairs = rot.GetTeamPairs();

                var matchOfMatchDay = 0;
                foreach (var match in pairs)//For every match
                {
                    if (!firstRound.ContainsKey(i+1))
                    {
                        firstRound[i+1] = new List<MatchMessage>();
                    }
                    firstRound[i + 1].Add(GenerateMatch(match.Key, match.Value, i + 1, matchOfMatchDay, season.Id));
                    matchOfMatchDay++;
                }

                rot.Rotate();
            }
            Dictionary<int, List<MatchMessage>> completeSeason = AddSecondRound(firstRound);
            WaitingWindow waiting = new WaitingWindow();
            waiting.Show();
            string errors = Service.CreateMatches(completeSeason.Values.SelectMany(mday => mday).ToArray());
            waiting.Close();
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Spielgenerierung aufgetreten:\n" + errors,
                    "Fehler bei der Spielgenerierung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static Dictionary<int, List<MatchMessage>> AddSecondRound(Dictionary<int, List<MatchMessage>> firstRound)
        {
            Dictionary<int, List<MatchMessage>> completeSeason = new Dictionary<int, List<MatchMessage>>();
            foreach (var kvpair in firstRound)
            {
                completeSeason.Add(kvpair.Key.DeepClone(), kvpair.Value.DeepClone());
            }
            foreach (var matchDay in firstRound)//swap home and awayteam, move date 17 weeks forward, add 17 to matchdate
            {
                List<MatchMessage> swappedMatches = new List<MatchMessage>();
                foreach (var match in matchDay.Value)
                {
                    int oldHomeTeam = match.HomeTeamId;
                    match.HomeTeamId = match.AwayTeamId;
                    match.AwayTeamId = oldHomeTeam;
                    match.DateTime = match.DateTime.AddDays(17 * 7);
                    match.MatchDay = match.MatchDay + 17;
                    swappedMatches.Add(match);
                }
                completeSeason.Add(matchDay.Key+17, swappedMatches);
            }
            return completeSeason;
        }

        public static MatchMessage GenerateMatch(TeamMessage teamA, TeamMessage teamB, int matchDay, int matchOfMatchDay, int seasonId)
        {
            var match = new MatchMessage
            {
                HomeTeamId = teamA.Id,
                HomeTeamScore = 0,
                AwayTeamId = teamB.Id,
                AwayTeamScore = 0,
                SeasonId = seasonId,
                MatchDay = matchDay
            };

            TimeSpan ts;
            switch (matchOfMatchDay)
            {
                case 0://Friday, 20:30
                    NextWeekday(DayOfWeek.Friday);
                    ts = new TimeSpan(20, 30, 0);
                    match.DateTime = CurrentDate.Date + ts;
                    break;
                case 1://Sunday, 15:30
                    NextWeekday(DayOfWeek.Sunday);
                    ts = new TimeSpan(15, 30, 0);
                    match.DateTime = CurrentDate.Date + ts;
                    break;
                case 2://Sunday, 17:30
                    NextWeekday(DayOfWeek.Sunday);
                    ts = new TimeSpan(17, 30, 0);
                    match.DateTime = CurrentDate.Date + ts;
                    break;
                default://Saturday, 15:30
                    PreviousWeekday(DayOfWeek.Saturday);
                    ts = new TimeSpan(15, 30, 0);
                    match.DateTime = CurrentDate.Date + ts;
                    break;
            }
            return match;
        }

        //Today or next weekday
        public static void NextWeekday(DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            var daysToAdd = ((int)day - (int)CurrentDate.DayOfWeek + 7) % 7;
            CurrentDate = CurrentDate.AddDays(daysToAdd);
        }

        //Today or previous weekday
        public static void PreviousWeekday(DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            var daysToSub = ((int)day - (int)CurrentDate.DayOfWeek + 7) % 7;
            CurrentDate = daysToSub != 0 ? CurrentDate.AddDays(daysToSub).AddDays(-7) : CurrentDate;
        }

    }
}