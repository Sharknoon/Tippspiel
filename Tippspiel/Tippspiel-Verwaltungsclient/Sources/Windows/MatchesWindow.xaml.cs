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
using FluentNHibernate.Conventions;
using NHibernate.Util;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for MatchesWindow.xaml
    /// </summary>
    public partial class MatchesWindow : Window
    {
        public int CurrentMatchDay { get; set; } = 1;
        public SeasonMessage CurrentSeason { get; set; }

        public ObservableCollection<SeasonMessage> Seasons { get; set; } = new ObservableCollection<SeasonMessage>();
        public ObservableCollection<ListItem> ListItems { get; set; } = new ObservableCollection<ListItem>();
        public ServiceClient Service = WcfHelper.ServiceClient;

        public MatchesWindow()
        {
            InitializeComponent();
            DataContext = this;

            foreach (var seasonMessage in Service.GetAllSeasons().OrderBy(season => season.Sequence))
            {
                Seasons.Add(seasonMessage);
            }
            CurrentSeason = Seasons.First();
            LoadMatches();
        }

        private void LoadMatches()
        {
            //Nur zwei DB Zugriffe => Deutlich bessere Performance
            ListItems.Clear();
            MatchMessage[] matches = Service.GetAllMatchesForMatchDayInSeason(CurrentSeason.Id, CurrentMatchDay);
            int[] teamIds = new int[matches.Length*2];
            for (var i = 0; i < matches.Length; i++)
            {
                teamIds[i * 2] = matches[i].HomeTeamId;
                teamIds[(i * 2) + 1] = matches[i].AwayTeamId;
            }
            TeamMessage[] teams = Service.GetTeamsById(teamIds);

            for (var i = 0; i < matches.Length; i++)
            {
                MatchMessage matchMessage = matches[i];
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
                    Season = CurrentSeason.Name,
                    Id = matchMessage.Id,
                    DateTime =
                        matchMessage.DateTime.ToShortDateString() + " " + matchMessage.DateTime.ToShortTimeString(),
                    AagainstB = teams[i*2].Name + " : " + teams[(i*2)+1].Name + matchResult
                });
            }
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            MatchMessage match = new MatchMessage();
            match.SeasonId = CurrentSeason.Id;
            match.MatchDay = CurrentMatchDay;
            MatchEditingWindow matchEditingWidnow = new MatchEditingWindow(match,true);
            matchEditingWidnow.ShowDialog();
            LoadMatches();
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
            if (CurrentSeason != null)
            {
                LoadMatches();
            }
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MatchMessage match = button.DataContext as MatchMessage;
            string errors = Service.DeleteMatch(match);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Spiellöschung aufgetreten:\n" + errors,
                    "Fehler bei der Spiellöschung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Close();
            }
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MatchMessage match = button.DataContext as MatchMessage;
            MatchEditingWindow matchEditingWidnow = new MatchEditingWindow(match, false);
            matchEditingWidnow.ShowDialog();
            LoadMatches();
        }

        public class ListItem
        {
            public int Id { get; set; }
            public string AagainstB { get; set; }
            public string DateTime { get; set; }
            public string Season { get; set; }
        }

        private void ComboBoxSeasons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrentSeason != null)
            {
                LoadMatches();
            }
        }
    }
}
