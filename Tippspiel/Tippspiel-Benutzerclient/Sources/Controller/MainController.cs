using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tippspiel_Benutzerclient.ServiceReference;

namespace Tippspiel_Benutzerclient.Sources.Controller
{
    class MainController
    {
        public static MainWindow Window;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void OnLogin()
        {
            var username = Window.Username;
            BettorMessage[] bettors = Service.LoginBettor(username);
            if (bettors.Length < 1)
            {
                MessageBox.Show(
                    "Der Benutzer " + username +
                    " existiert nicht, der Admin legt aber gerne einen neuen Benutzer für Sie an.",
                    "Fehler beim Anmelden", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Window.FadeOutLoginContent();
            }
        }


        public static void Init(MainWindow window)
        {
            Window = window;
            List<SeasonMessage> seasons = Service.GetAllSeasons().ToList();
            foreach (var season in seasons)
            {
                Window.Seasons.Add(season);
            }
            Window.CurrentSeason = seasons.FirstOrDefault();
            //window.ComboBoxSeasons.Items.Refresh();
        }
    }
}
