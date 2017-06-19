using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FluentNHibernate.Conventions;
using Tippspiel_Server.Sources.Validators.Helper;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for SeasonsWindow.xaml
    /// </summary>
    public partial class SeasonsWindow : Window
    {
        public ServiceClient Service = WcfHelper.ServiceClient;
        public ObservableCollection<SeasonMessage> Seasons { get; set; } = new ObservableCollection<SeasonMessage>();

        public SeasonsWindow()
        {
            InitializeComponent();
            DataContext = this;

            LoadSeasons();
        }

        public void LoadSeasons()
        {
            Seasons.Clear();
            var orderedSeasons = Service.GetAllSeasons().OrderBy(season => season.Sequence).ToList();
            foreach (var seasonMessage in orderedSeasons)
            {
                Seasons.Add(seasonMessage);
            }
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonMessage newSeason = new SeasonMessage();
            SeasonsEditingWindow seasonsEditingWindow = new SeasonsEditingWindow(newSeason, true);
            seasonsEditingWindow.ShowDialog();
            LoadSeasons();

        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SeasonMessage season = button.DataContext as SeasonMessage;
            string errors = Service.DeleteSeason(season);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Saisonlöschung aufgetreten:\n" + errors,
                    "Fehler bei der Saisonlöschung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                LoadSeasons();
            }
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            SeasonMessage season = button.DataContext as SeasonMessage;
            SeasonsEditingWindow seasonsEditingWindow = new SeasonsEditingWindow(season, false);
            seasonsEditingWindow.ShowDialog();
            LoadSeasons();
        }
    }
}
