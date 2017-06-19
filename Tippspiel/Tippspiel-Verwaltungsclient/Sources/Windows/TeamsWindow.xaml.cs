using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Team = Tippspiel_Server.Sources.Models.Team;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for TeamsWindow.xaml
    /// </summary>
    public partial class TeamsWindow : Window
    {
        public ServiceClient Service = WcfHelper.ServiceClient;
        public ObservableCollection<TeamMessage> Teams { get; set; } = new ObservableCollection<TeamMessage>();

        public TeamsWindow()
        {
            InitializeComponent();
            DataContext = this;

            LoadTeams();
        }

        public void LoadTeams()
        {
            Teams.Clear();
            var orderedTeams = Service.GetAllTeams().OrderBy(team => team.Name).ToList();
            foreach (var teamMessage in orderedTeams)
            {
                Teams.Add(teamMessage);
            }
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            TeamMessage newTeamMessage = new TeamMessage();
            newTeamMessage.SeasonIDs = new int[] {};
            TeamEditingWindow teamEditingWindow = new TeamEditingWindow(newTeamMessage, true);
            teamEditingWindow.ShowDialog();
            LoadTeams();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            TeamMessage team = button.DataContext as TeamMessage;
            string errors = Service.DeleteTeam(team);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Teamlöschung aufgetreten:\n" + errors,
                    "Fehler bei der Teamlöschung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                LoadTeams();
            }
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            TeamMessage team = button.DataContext as TeamMessage;
            TeamEditingWindow teamEditingWindow = new TeamEditingWindow(team, false);
            teamEditingWindow.ShowDialog();
            LoadTeams();
        }
    }
}
