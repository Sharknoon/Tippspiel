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
using Tippspiel_Verwaltungsclient.Sources.Controller;

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

        public MatchesWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


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

        public class ListItem
        {
            public int Id { get; set; }
            public string AagainstB { get; set; }
            public string DateTime { get; set; }
            public string Season { get; set; }
        }

        private void ComboBoxSeasons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MatchesController.SeasonChangedByUser();
        }
    }
}
