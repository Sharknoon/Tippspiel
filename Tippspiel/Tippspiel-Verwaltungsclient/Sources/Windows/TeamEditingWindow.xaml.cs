using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for TeamEditingWindow.xaml
    /// </summary>
    public partial class TeamEditingWindow
    {
        public TeamEditingWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public TeamMessage Team { get; set; }

        public ObservableCollection<SeasonMessage> SeasonsOfTeam { get; set; } =
            new ObservableCollection<SeasonMessage>();

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