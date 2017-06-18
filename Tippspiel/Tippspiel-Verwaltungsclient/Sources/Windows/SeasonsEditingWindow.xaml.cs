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
using System.Windows.Shapes;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for SeasonsEditingWindow.xaml
    /// </summary>
    public partial class SeasonsEditingWindow : Window
    {
        public ServiceClient Service = WcfHelper.ServiceClient;
        public SeasonMessage Season;

        public SeasonsEditingWindow(SeasonMessage season)
        {
            InitializeComponent();
            DataContext = this;

            Season = season;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
