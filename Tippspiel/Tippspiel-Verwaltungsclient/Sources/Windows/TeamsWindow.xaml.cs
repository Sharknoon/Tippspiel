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
using Tippspiel_Verwaltungsclient.Sources.Controller;
using Team = Tippspiel_Server.Sources.Models.Team;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for TeamsWindow.xaml
    /// </summary>
    public partial class TeamsWindow : Window
    {
        public ObservableCollection<TeamMessage> Teams { get; set; } = new ObservableCollection<TeamMessage>();

        public TeamsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }



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
