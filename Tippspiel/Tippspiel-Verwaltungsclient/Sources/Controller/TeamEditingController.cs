using System.Linq;
using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class TeamEditingController
    {
        public static TeamEditingWindow TeamEditingWindow;
        public static bool NewTeam;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void StartAsNewTeam()
        {
            NewTeam = true;
            var newTeam = new TeamMessage {SeasonIDs = new int[] { }};
            TeamEditingWindow = new TeamEditingWindow(newTeam);

            TeamEditingWindow.ShowDialog();
        }

        public static void StartAsEditingTeam(TeamMessage team)
        {
            NewTeam = false;
            TeamEditingWindow = new TeamEditingWindow(team);

            var seasonsById = Service.GetSeasonsById(TeamEditingWindow.Team.SeasonIDs);
            foreach (var seasonMessage in seasonsById)
            {
                TeamEditingWindow.SeasonsOfTeam.Add(seasonMessage);
            }

            TeamEditingWindow.ShowDialog();
        }

        public static void FinishEditing()
        {
            TeamEditingWindow.Team.SeasonIDs = TeamEditingWindow.SeasonsOfTeam.Select(season => season.Id).ToArray();
            var errors = NewTeam ? Service.CreateTeam(TeamEditingWindow.Team) : Service.EditTeam(TeamEditingWindow.Team);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Mannschaftsbearbeitung aufgetreten:\n" + errors,
                    "Fehler bei der Mannschaftsbearbeitung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                TeamEditingWindow.Close();
            }
        }

        public static void CancelEditing()
        {
            TeamEditingWindow.Close();
        }

        public static void DeleteSeason(SeasonMessage season)
        {
            TeamEditingWindow.SeasonsOfTeam.Remove(season);
        }

        public static void AddSeason()
        {
            TeamEditingSeasonSelectionController.Start(TeamEditingWindow.Team);
            var seasonsById = Service.GetSeasonsById(TeamEditingWindow.Team.SeasonIDs);
            TeamEditingWindow.SeasonsOfTeam.Clear();
            foreach (var seasonMessage in seasonsById)
            {
                TeamEditingWindow.SeasonsOfTeam.Add(seasonMessage);
            }
        }
    }
}