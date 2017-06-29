using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for TeamsWindow.xaml
    /// </summary>
    public partial class TeamsWindow
    {
        public TeamsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<TeamMessage> Teams { get; set; } = new ObservableCollection<TeamMessage>();


        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            TeamsController.AddTeam();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var team = button.DataContext as TeamMessage;
            TeamsController.DeleteTeam(team);
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var team = button.DataContext as TeamMessage;
            TeamsController.EditTeam(team);
        }
    }
}