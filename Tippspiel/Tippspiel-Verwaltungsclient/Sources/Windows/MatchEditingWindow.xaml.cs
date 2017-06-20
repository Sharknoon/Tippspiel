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

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for MatchEditingWindow.xaml
    /// </summary>
    public partial class MatchEditingWindow : Window
    {
        public MatchMessage Match { get; set; }
        public ObservableCollection<SeasonMessage> Seasons { get; set; } = new ObservableCollection<SeasonMessage>();
        public SeasonMessage CurrentSeason { get; set; }

        private readonly ServiceClient _service = WcfHelper.ServiceClient;
        private bool _newMatch;

        public MatchEditingWindow(MatchMessage match, bool newMatch)
        {
            InitializeComponent();
            DataContext = this;

            Match = match;
            foreach (var seasonMessage in _service.GetAllSeasons())
            {
                Seasons.Add(seasonMessage);
                if (seasonMessage.Id.Equals(Match.SeasonId))
                {
                    CurrentSeason = seasonMessage;
                }
            }
            _newMatch = newMatch;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            Match.SeasonId = CurrentSeason.Id;
            string errors = _newMatch ? _service.CreateMatch(Match) : _service.EditMatch(Match);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei derSpielbearbeitung aufgetreten:\n" + errors,
                    "Fehler bei der Spielbearbeitung", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
