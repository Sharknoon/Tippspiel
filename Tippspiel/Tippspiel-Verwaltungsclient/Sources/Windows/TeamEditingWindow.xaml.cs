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
using Season = Tippspiel_Server.Sources.Models.Season;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for TeamEditingWindow.xaml
    /// </summary>
    public partial class TeamEditingWindow : Window
    {
        public ServiceClient Service = WcfHelper.ServiceClient;
        public TeamMessage Team { get; set; }
        public bool NewTeam;
        public ObservableCollection<SeasonMessage> SeasonsOfTeam { get; set; } = new ObservableCollection<SeasonMessage>();

        public TeamEditingWindow(TeamMessage team, bool newTeam)
        {
            InitializeComponent();
            DataContext = this;

            Team = team;
            NewTeam = newTeam;
            SeasonMessage[] seasonsById = Service.GetSeasonsById(Team.SeasonIDs);
            foreach (var seasonMessage in seasonsById)
            {
                SeasonsOfTeam.Add(seasonMessage);
            }
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            string errors;
            Team.SeasonIDs = SeasonsOfTeam.Select(season => season.Id).ToArray();
            errors = NewTeam ? Service.CreateTeam(Team) : Service.EditTeam(Team);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Mannschaftsbearbeitung aufgetreten:\n" + errors,
                    "Fehler bei der Mannschaftsbearbeitung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Close();
            }
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAddSeasonToTeam_OnClick(object sender, RoutedEventArgs e)
        {
            TeamEditingSeasonSelection selectionWindow =new TeamEditingSeasonSelection(Team);
            selectionWindow.ShowDialog();
            SeasonMessage[] seasonsById = Service.GetSeasonsById(Team.SeasonIDs);
            SeasonsOfTeam.Clear();
            foreach (var seasonMessage in seasonsById)
            {
                SeasonsOfTeam.Add(seasonMessage);
            }
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SeasonMessage season = button.DataContext as SeasonMessage;
            SeasonsOfTeam.Remove(season);
        }
    }
}
