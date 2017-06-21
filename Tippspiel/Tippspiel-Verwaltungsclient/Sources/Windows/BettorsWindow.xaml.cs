using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for BettorsWindow.xaml
    /// </summary>
    public partial class BettorsWindow : Window
    {
        public ObservableCollection<BettorMessage> Bettors { get; set; }= new ObservableCollection<BettorMessage>();

        public BettorsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            BettorsController.AddBettor();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var bettor = button.DataContext as BettorMessage;
            BettorsController.DeleteBettor(bettor);
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            var bettor = button.DataContext as BettorMessage;
            BettorsController.EditBettor(bettor);
        }
    }
}
