using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Tippspiel_Verwaltungsclient.Sources.Controller;
using Tippspiel_Verwaltungsclient.Sources.Windows;
using Tippspiel_Verwaltungsclient.Sources.XML;

namespace Tippspiel_Verwaltungsclient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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
                {
                    SeasonsController.Start();
                }
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
                {
                    TeamsController.Start();
                }
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
                {
                    MatchesController.Start();
                }
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
                {
                    BettorsController.Start();
                }
            }
            catch (Exception exception)
            {
                MainController.OnUnexpectedError(exception);
            }
        }
    }
}
