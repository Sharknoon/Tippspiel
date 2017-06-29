using System;
using System.Windows;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSaisons_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainController.CheckConnection())
                    SeasonsController.Start();
            }
            catch (Exception exception)
            {
                MainController.OnUnexpectedError(exception);
            }
        }

        private void ButtonTeams_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainController.CheckConnection())
                    TeamsController.Start();
            }
            catch (Exception exception)
            {
                MainController.OnUnexpectedError(exception);
            }
        }

        private void ButtonMatches_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainController.CheckConnection())
                    MatchesController.Start();
            }
            catch (Exception exception)
            {
                MainController.OnUnexpectedError(exception);
            }
        }

        private void ButtonBettors_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainController.CheckConnection())
                    BettorsController.Start();
            }
            catch (Exception exception)
            {
                MainController.OnUnexpectedError(exception);
            }
        }
    }
}