using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class BettorsController
    {
        public static BettorsWindow BettorsWindow;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void Start()
        {
            BettorsWindow = new BettorsWindow();
            LoadBettors();

            BettorsWindow.ShowDialog();
        }

        public static void LoadBettors()
        {
            BettorsWindow.Bettors.Clear();
            foreach (var bettorMessage in Service.GetAllBettors())
            {
                BettorsWindow.Bettors.Add(bettorMessage);
            }
        }

        public static void AddBettor()
        {
            BettorEditingController.StartAsNewTipper();
            LoadBettors();
        }

        public static void EditBettor(BettorMessage bettor)
        {
            BettorEditingController.StartAsEditedTipper(bettor);
            LoadBettors();
        }

        public static void DeleteBettor(BettorMessage bettor)
        {
            var errors = Service.DeleteBettor(bettor);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Tipperlöschung aufgetreten:\n" + errors,
                    "Fehler bei der Tipperlöschung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                LoadBettors();
            }
        }
    }
}