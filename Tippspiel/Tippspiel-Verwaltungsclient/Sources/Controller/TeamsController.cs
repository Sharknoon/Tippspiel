using System.Linq;
using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class TeamsController
    {
        public static TeamsWindow TeamsWindow;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void Start()
        {
            TeamsWindow = new TeamsWindow();

            LoadTeams();

            TeamsWindow.ShowDialog();
        }

        public static void LoadTeams()
        {
            TeamsWindow.Teams.Clear();
            var orderedTeams = Service.GetAllTeams().OrderBy(team => team.Name).ToList();
            foreach (var teamMessage in orderedTeams)
                TeamsWindow.Teams.Add(teamMessage);
        }

        public static void AddTeam()
        {
            TeamEditingController.StartAsNewTeam();
            LoadTeams();
        }

        public static void EditTeam(TeamMessage team)
        {
            TeamEditingController.StartAsEditingTeam(team);
            LoadTeams();
        }

        public static void DeleteTeam(TeamMessage team)
        {
            var errors = Service.DeleteTeam(team);
            if (errors.IsNotEmpty())
                MessageBox.Show("Es sind folgende Fehler bei der Teamlöschung aufgetreten:\n" + errors,
                    "Fehler bei der Teamlöschung", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                LoadTeams();
        }
    }
}