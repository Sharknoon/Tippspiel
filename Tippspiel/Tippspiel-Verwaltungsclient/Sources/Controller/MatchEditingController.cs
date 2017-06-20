using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Server.Sources.Database.Mappings;
using Tippspiel_Server.Sources.Service;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class MatchEditingController
    {
        public static MatchEditingWindow MatchEditingWindow;
        public static bool IsNewMatch;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void StartAsNewMatch(int seasonId, int matchDay)
        {
            IsNewMatch = true;
            //Infos vom MatchWindow
            var match = new MatchMessage
            {
                SeasonId = seasonId,
                MatchDay = matchDay,
                DateTime = DateTime.Now
            };
            MatchEditingWindow = new MatchEditingWindow(match);
            
            foreach (var seasonMessage in Service.GetAllSeasons())
            {
                MatchEditingWindow.Seasons.Add(seasonMessage);
                //Ein paar Default Werte Setzen für die Bequemlichkeit
                if (seasonMessage.Id.Equals(MatchEditingWindow.Match.SeasonId))
                {
                    MatchEditingWindow.CurrentSeason = seasonMessage;
                }
            }

            RefreshTeamDropDowns();

            MatchEditingWindow.ShowDialog();
        }

        public static void StartAsEditingMatch(MatchMessage match)
        {
            IsNewMatch = false;
            MatchEditingWindow = new MatchEditingWindow(match);

            foreach (var seasonMessage in Service.GetAllSeasons())
            {
                MatchEditingWindow.Seasons.Add(seasonMessage);
                //Ein paar Default Werte Setzen für die Bequemlichkeit
                if (seasonMessage.Id.Equals(MatchEditingWindow.Match.SeasonId))
                {
                    MatchEditingWindow.CurrentSeason = seasonMessage;
                }
            }

            RefreshTeamDropDowns();

            MatchEditingWindow.ShowDialog();
        }

        private static void RefreshTeamDropDowns()
        {
            var allTeams = Service.GetAllTeams().ToList().Where(team => team.SeasonIDs.Contains(MatchEditingWindow.CurrentSeason.Id)).ToList();
            if (IsNewMatch || !MatchEditingWindow.CurrentSeason.Id.Equals(MatchEditingWindow.Match.SeasonId))
            {
                MatchEditingWindow.CurrentHomeTeam = allTeams.First();
                if (allTeams.Count>1)
                {
                    MatchEditingWindow.CurrentAwayTeam = allTeams[1];
                }
            }
            else
            {
                MatchEditingWindow.CurrentHomeTeam = allTeams.Find(team => team.Id.Equals(MatchEditingWindow.Match.HomeTeamId));
                MatchEditingWindow.CurrentAwayTeam = allTeams.Find(team => team.Id.Equals(MatchEditingWindow.Match.AwayTeamId));
            }
            MatchEditingWindow.Teams.Clear();
            foreach (var teamMessage in allTeams)
            {
                MatchEditingWindow.Teams.Add(teamMessage);
            }
        }

        public static void EditingFinished()
        {
            MatchEditingWindow.Match.SeasonId = MatchEditingWindow.CurrentSeason.Id;
            MatchEditingWindow.Match.AwayTeamId = MatchEditingWindow.CurrentAwayTeam.Id;
            MatchEditingWindow.Match.HomeTeamId = MatchEditingWindow.CurrentHomeTeam.Id;
            var errors = IsNewMatch ? Service.CreateMatch(MatchEditingWindow.Match) : Service.EditMatch(MatchEditingWindow.Match);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei derSpielbearbeitung aufgetreten:\n" + errors,
                    "Fehler bei der Spielbearbeitung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MatchEditingWindow.Close();
            }
        }

        public static void EditingCanceled()
        {
            MatchEditingWindow.Close();
        }

        public static void SeasonChangedByUser()
        {
            RefreshTeamDropDowns();
        }

        public static bool IsNumeric(string value)
        {
            Regex regex = new Regex("[^0-9]+");
            return regex.IsMatch(value);
        }

    }

}