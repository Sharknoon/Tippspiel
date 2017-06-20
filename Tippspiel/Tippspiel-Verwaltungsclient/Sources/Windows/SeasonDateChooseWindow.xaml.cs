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
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for SeasonDateChooseWindow.xaml
    /// </summary>
    public partial class SeasonDateChooseWindow : Window
    {
        public DateTime Date { get; set; }

        public SeasonDateChooseWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonDateChooseController.FinsihDateChoose();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonDateChooseController.CancelDateChoose();
        }
    }
}
