using System.Windows;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for BettorEditingWindow.xaml
    /// </summary>
    public partial class BettorEditingWindow
    {
        public BettorEditingWindow(BettorMessage bettor)
        {
            InitializeComponent();
            DataContext = this;

            Bettor = bettor;
        }

        public BettorMessage Bettor { get; set; }

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