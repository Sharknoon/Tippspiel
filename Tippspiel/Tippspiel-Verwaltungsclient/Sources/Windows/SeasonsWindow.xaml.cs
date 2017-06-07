using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Tippspiel_Server;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for SeasonsWindow.xaml
    /// </summary>
    public partial class SeasonsWindow : Window
    {
        public Service Service = new Service();
        public ObservableCollection<Season> Seasons { get; set; } = new ObservableCollection<Season>();

        public SeasonsWindow()
        {
            InitializeComponent();
            DataContext = this;

            LoadSeasons();
        }

        public void LoadSeasons()
        {
            Seasons.Clear();
            foreach (Season season in Service.GetAllSeasons())
            {
                Seasons.Add(season);
            }
        }
    }
}
