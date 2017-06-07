using System;
using System.Collections.Generic;
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
using Tippspiel_Verwaltungsclient.Sources.Windows;

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
            SeasonsWindow seasonsWindow = new SeasonsWindow();
            bool result = seasonsWindow.ShowDialog().Value;
        }

        private void ButtonTeams_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonMatches_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonBettors_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
