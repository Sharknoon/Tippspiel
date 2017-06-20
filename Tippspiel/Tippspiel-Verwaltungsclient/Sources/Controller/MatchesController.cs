using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;


namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class MatchesController
    {
        public static MatchesWindow MatchesWindow;
        public static List<MatchMessage> Matches = new List<MatchMessage>();

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void Start()
        {
            MatchesWindow = new MatchesWindow();

            foreach (var seasonMessage in Service.GetAllSeasons().OrderBy(season => season.Sequence))
            {
                MatchesWindow.Seasons.Add(seasonMessage);
            }
            MatchesWindow.CurrentSeason = MatchesWindow.Seasons.First();
            LoadMatches();

            MatchesWindow.ShowDialog();
        }

        private static void LoadMatches()
        {
            //Nur zwei DB Zugriffe => Deutlich bessere Performance
            MatchesWindow.ListItems.Clear();
            var matches = Service.GetAllMatchesForMatchDayInSeason(MatchesWindow.CurrentSeason.Id, MatchesWindow.CurrentMatchDay);
            Matches = matches.ToList();
            var teamIds = new int[matches.Length * 2];
            for (var i = 0; i < matches.Length; i++)
            {
                teamIds[i * 2] = matches[i].HomeTeamId;
                teamIds[(i * 2) + 1] = matches[i].AwayTeamId;
            }
            var teams = Service.GetTeamsById(teamIds);

            for (var i = 0; i < matches.Length; i++)
            {
                var matchMessage = matches[i];
                string matchResult;
                if (matchMessage.DateTime < DateTime.Now)
                {
                    matchResult = " (" + matchMessage.HomeTeamScore + ":" + matchMessage.AwayTeamScore + ")";
                }
                else
                {
                    matchResult = "";
                }
                MatchesWindow.ListItems.Add(new MatchesWindow.ListItem()
                {
                    Season = MatchesWindow.CurrentSeason.Name,
                    Id = matchMessage.Id,
                    DateTime =
                        matchMessage.DateTime.ToShortDateString() + " " + matchMessage.DateTime.ToShortTimeString(),
                    AagainstB = teams[i * 2].Name + " : " + teams[(i * 2) + 1].Name + matchResult
                });
            }
        }

        public static void SeasonChangedByUser()
        {
            if (MatchesWindow.CurrentSeason != null)
            {
                LoadMatches();
            }
        }

        public static void MatchDayChangedByUser()
        {
            if (MatchesWindow?.CurrentSeason != null)
            {
                LoadMatches();
            }
        }

        public static void AddNewMatch()
        {
            MatchEditingController.StartAsNewMatch(MatchesWindow.CurrentSeason.Id, MatchesWindow.CurrentMatchDay);
            LoadMatches();
        }

        public static void EditMatch(MatchesWindow.ListItem matchItem)
        {
            var match = Matches.Find(m => m.Id.Equals(matchItem.Id));
            MatchEditingController.StartAsEditingMatch(match);
            LoadMatches();
        }

        public static void DeleteMatch(MatchesWindow.ListItem match)
        {
            var errors = Service.DeleteMatch(Matches.Find(m => m.Id.Equals(match.Id)));
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Spiellöschung aufgetreten:\n" + errors,
                    "Fehler bei der Spiellöschung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadMatches();
        }

        public static void ImportMatchDayFromXml()
        {
            XmlFileChooseController.Start(MatchesWindow.CurrentMatchDay, MatchesWindow.CurrentSeason.Id);
            LoadMatches();
        }

        public static void GenerateMatchDay()
        {
            
        }

    }
}