using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class BettorEditingController
    {
        public static BettorEditingWindow BettorEditingWindow;
        public static bool NewBettor;
        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void StartAsNewTipper()
        {
            NewBettor = true;
            var newBettor = new BettorMessage();
            BettorEditingWindow = new BettorEditingWindow(newBettor);
            BettorEditingWindow.ShowDialog();
        }

        public static void StartAsEditedTipper(BettorMessage bettor)
        {
            NewBettor = false;
            BettorEditingWindow = new BettorEditingWindow(bettor);
            BettorEditingWindow.ShowDialog();
        }

        public static void FinishedEditing()
        {
            var errors = NewBettor ? Service.CreateBettor(BettorEditingWindow.Bettor) : Service.EditBettor(BettorEditingWindow.Bettor);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Tipperbearbeitung aufgetreten:\n" + errors,
                    "Fehler bei der Tipperbearbeitung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BettorEditingWindow.Close();
            }
        }

        public static void CancelEditing()
        {
            BettorEditingWindow.Close();
        }
    }
}