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
using Tippspiel_Server.Sources.Service;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;
using Season = Tippspiel_Server.Sources.Models.Season;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for TeamEditingWindow.xaml
    /// </summary>
    public partial class TeamEditingWindow : Window
    {
        public TeamMessage Team { get; set; }

        public ObservableCollection<SeasonMessage> SeasonsOfTeam { get; set; } =
            new ObservableCollection<SeasonMessage>();

        public TeamEditingWindow(TeamMessage team)
        {
            InitializeComponent();
            DataContext = this;

            Team = team;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            TeamEditingController.FinishEditing();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            TeamEditingController.CancelEditing();
        }

        private void ButtonAddSeasonToTeam_OnClick(object sender, RoutedEventArgs e)
        {
            TeamEditingController.AddSeason();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var season = button.DataContext as SeasonMessage;
            TeamEditingController.DeleteSeason(season);
        }
    }
}
