using System.Linq;
using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class SeasonsController
    {
        public static SeasonsWindow SeasonsWindow;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void Start()
        {
            SeasonsWindow = new SeasonsWindow();

            LoadSeasons();

            SeasonsWindow.ShowDialog();
        }

        public static void LoadSeasons()
        {
            SeasonsWindow.Seasons.Clear();
            var orderedSeasons = Service.GetAllSeasons().OrderBy(season => season.Sequence).ToList();
            foreach (var seasonMessage in orderedSeasons)
            {
                SeasonsWindow.Seasons.Add(seasonMessage);
            }
        }

        public static void AddSeason()
        {
            SeasonsEditingController.StartAsNewSeason();
            LoadSeasons();
        }

        public static void EditSeason(SeasonMessage season)
        {
            SeasonsEditingController.StartAsEditedSeason(season);
            LoadSeasons();
        }

        public static void DeleteSeason(SeasonMessage season)
        {
            var errors = Service.DeleteSeason(season);
            if (errors != null && errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Saisonlöschung aufgetreten:\n" + errors,
                    "Fehler bei der Saisonlöschung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                LoadSeasons();
            }
        }

    }
}