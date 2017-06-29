using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for BettorsWindow.xaml
    /// </summary>
    public partial class BettorsWindow
    {
        public BettorsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<BettorMessage> Bettors { get; set; } = new ObservableCollection<BettorMessage>();

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