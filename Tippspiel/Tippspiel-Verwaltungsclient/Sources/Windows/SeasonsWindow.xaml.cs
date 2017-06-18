using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            SeasonsEditingWindow seasonsEditingWindow = new SeasonsEditingWindow(new SeasonMessage());
            seasonsEditingWindow.ShowDialog();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var id = ((Button) sender).Tag;
            
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var id = ((Button)sender).Tag;
        }
    }
}
