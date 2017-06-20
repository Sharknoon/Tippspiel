using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FluentNHibernate.Conventions;
using Tippspiel_Server.Sources.Validators.Helper;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for SeasonsWindow.xaml
    /// </summary>
    public partial class SeasonsWindow : Window
    {
        public ObservableCollection<SeasonMessage> Seasons { get; set; } = new ObservableCollection<SeasonMessage>();

        public SeasonsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonsController.AddSeason();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                SeasonMessage season = button.DataContext as SeasonMessage;
                SeasonsController.DeleteSeason(season);
            }
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                SeasonMessage season = button.DataContext as SeasonMessage;
                SeasonsController.EditSeason(season);
            }
        }
    }
}
