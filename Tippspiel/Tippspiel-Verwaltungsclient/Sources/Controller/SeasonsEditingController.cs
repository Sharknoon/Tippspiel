using System.Text.RegularExpressions;
using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class SeasonsEditingController
    {
        public static SeasonEditingWindow SeasonEditingWindow;
        public static bool NewSeason;
        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void StartAsNewSeason()
        {
            NewSeason = true;
            var newSeason = new SeasonMessage();
            SeasonEditingWindow = new SeasonEditingWindow {Season = newSeason};
            SeasonEditingWindow.ShowDialog();
        }

        public static void StartAsEditedSeason(SeasonMessage season)
        {
            NewSeason = false;
            SeasonEditingWindow = new SeasonEditingWindow {Season = season};
            SeasonEditingWindow.ShowDialog();
        }

        public static void FinishEditing()
        {
            var errors = NewSeason
                ? Service.CreateSeason(SeasonEditingWindow.Season)
                : Service.EditSeason(SeasonEditingWindow.Season);
            if (errors.IsNotEmpty())
                MessageBox.Show("Es sind folgende Fehler bei der Saisonbearbeitung aufgetreten:\n" + errors,
                    "Fehler bei der Saisonbearbeitung", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                SeasonEditingWindow.Close();
        }

        public static void CancelEditing()
        {
            SeasonEditingWindow.Close();
        }

        public static bool IsNumeric(string toCheck)
        {
            var regex = new Regex("[^0-9]+");
            return regex.IsMatch(toCheck);
        }
    }
}