using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for MatchesWindow.xaml
    /// </summary>
    public partial class MatchesWindow : Window
    {
        public int CurrentMatchDay { get; set; } = 1;


        public ObservableCollection<ListItem> ListItems { get; set; } = new ObservableCollection<ListItem>();
        public ServiceClient Service = WcfHelper.ServiceClient;

        public MatchesWindow()
        {
            InitializeComponent();
            DataContext = this;

            LoadMatches();
        }

        private void LoadMatches()
        {
            foreach (var matchMessage in Service.GetAllMatches())
            {
                TeamMessage[] teams = Service.GetTeamsById(new int[]
                    {matchMessage.HomeTeamId, matchMessage.AwayTeamId});
                string matchResult;
                if (matchMessage.DateTime < DateTime.Now)
                {
                    matchResult = " (" + matchMessage.HomeTeamScore + ":" + matchMessage.AwayTeamScore + ")";
                }
                else
                {
                    matchResult = "";
                }
                ListItems.Add(new ListItem()
                {
                    Season = Service.GetSeasonsById(new int[] {matchMessage.SeasonId}).First().Name,
                    Id = matchMessage.Id,
                    DateTime =
                        matchMessage.DateTime.ToShortDateString() + " " + matchMessage.DateTime.ToShortTimeString(),
                    AagainstB = teams[0].Name + " : " + teams[1].Name + matchResult
                });
            }
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonGenerate_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonImport_OnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(CurrentMatchDay);
        }

        private bool dragStarted = false;

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!dragStarted)
            {
                MatchDayChanged();
            }
        }

        private void Slider_OnDragStarted(object sender, DragStartedEventArgs e)
        {
            this.dragStarted = true;
        }

        private void Slider_OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            MatchDayChanged();
            this.dragStarted = false;
        }

        private void MatchDayChanged()
        {
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MatchMessage match = button.DataContext as MatchMessage;
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MatchMessage match = button.DataContext as MatchMessage;
        }

        public class ListItem
        {
            public int Id { get; set; }
            public string AagainstB { get; set; }
            public string DateTime { get; set; }
            public string Season { get; set; }
        }
    }
}
