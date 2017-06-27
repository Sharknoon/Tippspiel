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
            CurrentUser = Tools.Tools.Bettors.Values.ToList().Find(b => b.Nickname.ToLower().Equals(username.ToLower()));

            if (CurrentUser == null)
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


        public static void Init()
        {
            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.Show();

            if (CheckConnection())
            {
                Window = new MainWindow();
                Tools.Tools.Init();
                ReloadSettings();
                if (Window.CurrentSeason != null)
                {
                    Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay, -1);
                    ReloadTable();
                    ReloadBettors();
                }

                Window.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Der Server ist unerreichbar, bitte kontaktieren Sie den Administrator", "Server unerreichbar", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LoadingWindow.Close();
        }

        public static bool CheckConnection()
        {
            try
            {
                Service.Ping();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void ReloadSettings()
        {
            if (Window == null) return;
            Window.Seasons.Clear();
            List<SeasonMessage> seasons = SettingsTools.GetSeasons();
            foreach (var season in seasons)
            {
                Window.Seasons.Add(season);
            }
            Window.CurrentSeason = seasons.FirstOrDefault();
            Window.ComboBoxSeasons.SelectedItem = Window.CurrentSeason;
            Window.CurrentMatchDay = 1;
            Window.Slider.Value = 1;
        }

        public static void ReloadTable()
        {
            if (Window == null) return;
            Window.Teams.Clear();
            foreach (var seasonTableEntry in TableTools.GetTableFor(Window.CurrentSeason, Window.CurrentMatchDay))
            {
                Window.Teams.Add(seasonTableEntry);
            }
            Window.InitScrollBarPaddings();
        }

        public static void ReloadBettors()
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
            Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay, CurrentUser.Id);
            ReloadTable();
            ReloadBettors();
        }

        public static void OnSeasonChanged()
        {
            if (Window == null || CurrentUser == null) return;
            Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay, CurrentUser.Id);
            ReloadTable();
            ReloadBettors();
        }

        public static void OnLogout()
        {
            LoadingWindow LoadingWindow = new LoadingWindow();
            LoadingWindow.Show();

            CurrentUser = null;
            ReloadSettings();

            if (Window.CurrentSeason != null)
            {
                Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay, -1);
                ReloadTable();
                ReloadBettors();
            }
            LoadingWindow.Close();
            Window.FadeOutMainContent();
        }
    }
}
