using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for MatchEditingWindow.xaml
    /// </summary>
    public partial class MatchEditingWindow
    {
        public MatchEditingWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public MatchMessage Match { get; set; }
        public ObservableCollection<SeasonMessage> Seasons { get; set; } = new ObservableCollection<SeasonMessage>();
        public SeasonMessage CurrentSeason { get; set; }
        public ObservableCollection<TeamMessage> Teams { get; set; } = new ObservableCollection<TeamMessage>();
        public TeamMessage CurrentHomeTeam { get; set; }
        public TeamMessage CurrentAwayTeam { get; set; }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            MatchEditingController.EditingFinished();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            MatchEditingController.EditingCanceled();
        }

        private void ComboBoxSeasons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MatchEditingController.SeasonChangedByUser();
        }

        private void TextBoxTeamScore_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = MatchEditingController.IsNumeric(e.Text);
        }
    }
}