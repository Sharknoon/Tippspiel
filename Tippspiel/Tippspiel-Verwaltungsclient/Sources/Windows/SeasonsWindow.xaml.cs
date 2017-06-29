using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for SeasonsWindow.xaml
    /// </summary>
    public partial class SeasonsWindow : Window
    {
        public SeasonsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<SeasonMessage> Seasons { get; set; } = new ObservableCollection<SeasonMessage>();


        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonsController.AddSeason();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var season = button.DataContext as SeasonMessage;
            SeasonsController.DeleteSeason(season);
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var season = button.DataContext as SeasonMessage;
            SeasonsController.EditSeason(season);
        }
    }
}