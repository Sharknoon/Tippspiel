using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tippspiel_Benutzerclient.ServiceReference;
using Tippspiel_Benutzerclient.Sources.Tools;
using Tippspiel_Benutzerclient.Sources.Windows;

namespace Tippspiel_Benutzerclient.Sources.Controller
{
    class MainController
    {
        public static MainWindow Window;
        public static BettorMessage CurrentUser;

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
                CurrentUser = bettors.FirstOrDefault();
                Window.FadeOutLoginContent();
            }
        }


        public static void Init(MainWindow window)
        {
            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.Show();
            Window = window;
            List<SeasonMessage> seasons = Service.GetAllSeasons().ToList();
            Window.Seasons.Clear();
            foreach (var season in seasons)
            {
                Window.Seasons.Add(season);
            }
            Window.CurrentSeason = seasons.FirstOrDefault();
            Window.ComboBoxSeasons.SelectedItem = Window.CurrentSeason;
            Window.CurrentMatchDay = 1;
            Window.Slider.Value = 1;

            if (Window.CurrentSeason != null)
            {
                Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
                RealoadTable();
                RealoadBettors();
            }
            
            LoadingWindow.Close();
        }

        public static void RealoadTable()
        {
            if (Window == null) return;
            Window.Teams.Clear();
            foreach (var seasonTableEntry in TableTools.GetTableFor(Window.CurrentSeason, Window.CurrentMatchDay))
            {
                Window.Teams.Add(seasonTableEntry);
            }
            Window.InitScrollBarPaddings();
        }

        public static void RealoadBettors()
        {
            if (Window == null) return;
            Window.Bettors.Clear();
            foreach (var seasonBettorEntry in BettorTools.GetBettorsFor(Window.CurrentSeason, Window.CurrentMatchDay))
            {
                Window.Bettors.Add(seasonBettorEntry);
            }
            Window.InitScrollBarPaddings();
        }

        public static void OnMatchDayChanged()
        {
            if (Window == null || CurrentUser == null) return;
            Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
            RealoadTable();
            RealoadBettors();
        }

        public static void OnSeasonChanged()
        {
            if (Window == null || CurrentUser == null) return;
            Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
            RealoadTable();
            RealoadBettors();
        }

        public static void OnLogout()
        {
            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.Show();
            CurrentUser = null;
            Window.CurrentSeason = Window.Seasons.FirstOrDefault();
            Window.ComboBoxSeasons.SelectedItem = Window.CurrentSeason;
            Window.CurrentMatchDay = 1;
            Window.Slider.Value = 1;

            if (Window.CurrentSeason != null)
            {
                Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
                RealoadTable();
                RealoadBettors();
            }
            LoadingWindow.Close();
            Window.FadeOutMainContent();
        }
    }
}
