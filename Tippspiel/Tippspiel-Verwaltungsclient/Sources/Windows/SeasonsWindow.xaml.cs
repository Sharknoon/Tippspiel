using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for SeasonsWindow.xaml
    /// </summary>
    public partial class SeasonsWindow : Window
    {
        public ServiceClient Service = new ServiceReference.ServiceClient();
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
            Console.Write(Service.Ping());
            foreach (var seasonMessage in Service.GetAllSeasons())
            {
                Seasons.Add(seasonMessage);
            }
        }
    }
}
