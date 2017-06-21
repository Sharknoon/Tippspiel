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
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for BettorEditingWindow.xaml
    /// </summary>
    public partial class BettorEditingWindow : Window
    {
        public BettorMessage Bettor { get; set; }

        public BettorEditingWindow(BettorMessage bettor)
        {
            InitializeComponent();
            DataContext = this;

            Bettor = bettor;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            BettorEditingController.FinishedEditing();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            BettorEditingController.CancelEditing();
        }
    }
}
