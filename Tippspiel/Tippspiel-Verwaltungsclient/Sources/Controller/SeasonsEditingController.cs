using System.Text.RegularExpressions;
using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class SeasonsEditingController
    {
        public static SeasonsEditingWindow SeasonsEditingWindow;
        public static bool NewSeason;
        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void StartAsNewSeason()
        {
            NewSeason = true;
            var newSeason = new SeasonMessage();
            SeasonsEditingWindow = new SeasonsEditingWindow(newSeason);
            SeasonsEditingWindow.ShowDialog();
        }

        public static void StartAsEditedSeason(SeasonMessage season)
        {
            NewSeason = false;
            SeasonsEditingWindow = new SeasonsEditingWindow(season);
            SeasonsEditingWindow.ShowDialog();
        }

        public static void FinishEditing()
        {
            var errors = NewSeason ? Service.CreateSeason(SeasonsEditingWindow.Season) : Service.EditSeason(SeasonsEditingWindow.Season);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Saisonbearbeitung aufgetreten:\n" + errors,
                    "Fehler bei der Saisonbearbeitung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SeasonsEditingWindow.Close();
            }
        }

        public static void CancelEditing()
        {
            SeasonsEditingWindow.Close();
        }

        public static bool IsNumeric(string toCheck)
        {
            Regex regex = new Regex("[^0-9]+");
            return regex.IsMatch(toCheck);
        }
    }
}