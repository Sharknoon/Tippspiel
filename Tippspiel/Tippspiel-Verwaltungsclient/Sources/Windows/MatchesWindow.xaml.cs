using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for MatchesWindow.xaml
    /// </summary>
    public partial class MatchesWindow
    {
        private bool _dragStarted;

        public MatchesWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public int CurrentMatchDay { get; set; } = 1;
        public SeasonMessage CurrentSeason { get; set; }

        public ObservableCollection<SeasonMessage> Seasons { get; set; } = new ObservableCollection<SeasonMessage>();
        public ObservableCollection<ListItem> ListItems { get; set; } = new ObservableCollection<ListItem>();


        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            MatchesController.AddNewMatch();
        }

        private void ButtonGenerate_OnClick(object sender, RoutedEventArgs e)
        {
            MatchesController.GenerateSeason();
        }

        private void ButtonImport_OnClick(object sender, RoutedEventArgs e)
        {
            MatchesController.ImportMatchDayFromXml();
        }

        private void Slider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_dragStarted)
                MatchDayChanged();
        }

        private void Slider_OnDragStarted(object sender, DragStartedEventArgs e)
        {
            _dragStarted = true;
        }

        private void Slider_OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            MatchDayChanged();
            _dragStarted = false;
        }

        private static void MatchDayChanged()
        {
            MatchesController.MatchDayChangedByUser();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var match = button.DataContext as ListItem;
            MatchesController.DeleteMatch(match);
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var matchItem = button.DataContext as ListItem;
            MatchesController.EditMatch(matchItem);
        }

        private void ComboBoxSeasons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MatchesController.SeasonChangedByUser();
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