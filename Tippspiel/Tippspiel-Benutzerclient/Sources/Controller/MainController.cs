using System;
using System.Linq;
using System.Windows;
using Tippspiel_Benutzerclient.ServiceReference;
using Tippspiel_Benutzerclient.Sources.Models;
using Tippspiel_Benutzerclient.Sources.Tools;
using Tippspiel_Benutzerclient.Sources.Windows;

namespace Tippspiel_Benutzerclient.Sources.Controller
{
    internal class MainController
    {
        public static MainWindow Window;
        public static BettorMessage CurrentUser;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void OnLogin()
        {
            var username = Window.Username;
            CurrentUser = Tools.Tools.Bettors.Values.ToList()
                .Find(b => b.Nickname.ToLower().Equals(username.ToLower()));
            if (CurrentUser == null)
            {
                MessageBox.Show(
                    "Der Benutzer " + username +
                    " existiert nicht, der Admin legt aber gerne einen neuen Benutzer für Sie an.",
                    "Fehler beim Anmelden", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
                ReloadBets();
                Window.FadeOutLoginContent();
            }
        }


        public static void Init()
        {
            var loadingWindow = new LoadingWindow();
            loadingWindow.Show();

            if (CheckConnection())
            {
                Window = new MainWindow();
                Tools.Tools.Init();
                ReloadSettings();
                if (Window.CurrentSeason != null)
                {
                    Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
                    ReloadTable();
                    ReloadBettors();
                }
                loadingWindow.Close();
                Window.ShowDialog();
            }
            else
            {
                loadingWindow.Close();
                MessageBox.Show(
                    "Der Server ist unerreichbar, bitte kontaktieren Sie den Administrator", "Server unerreichbar",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static bool CheckConnection()
        {
            try
            {
                Service.Ping();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void ReloadSettings()
        {
            if (Window == null) return;
            Window.Seasons.Clear();
            var seasons = SettingsTools.GetSeasons();
            foreach (var season in seasons)
                Window.Seasons.Add(season);
            Window.CurrentSeason = seasons.FirstOrDefault();
            Window.ComboBoxSeasons.SelectedItem = Window.CurrentSeason;
            Window.CurrentMatchDay = 1;
            Window.Slider.Value = 1;
        }

        public static void ReloadTable()
        {
            if (Window == null) return;
            Window.Teams.Clear();
            foreach (var seasonTableEntry in TableTools.GetTable())
                Window.Teams.Add(seasonTableEntry);
            Window.InitScrollBarPaddings();
        }

        public static void ReloadBettors()
        {
            if (Window == null) return;
            Window.Bettors.Clear();
            foreach (var seasonBettorEntry in BettorTools.GetBettors())
                Window.Bettors.Add(seasonBettorEntry);
            Window.InitScrollBarPaddings();
        }

        public static void ReloadBets()
        {
            if (Window == null) return;
            Window.Bets.Clear();
            foreach (var seasonBetEntry in BetTools.GetBets(CurrentUser.Id))
                Window.Bets.Add(seasonBetEntry);
            Window.ButtonSaveBets.Height = BetTools.IsMatchdayBettable() ? 40 : 0;
            Window.InitScrollBarPaddings();
        }

        public static void OnMatchDayChanged()
        {
            if (Window == null || CurrentUser == null) return;
            Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
            ReloadTable();
            ReloadBettors();
            ReloadBets();
        }

        public static void OnSeasonChanged()
        {
            if (Window == null || CurrentUser == null) return;
            Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
            ReloadTable();
            ReloadBettors();
            ReloadBets();
        }

        public static void OnLogout()
        {
            CurrentUser = null;
            ReloadSettings();

            if (Window.CurrentSeason != null)
            {
                Tools.Tools.Reload(Window.CurrentSeason.Id, Window.CurrentMatchDay);
                ReloadTable();
                ReloadBettors();
            }
            Window.FadeOutMainContent();
        }

        public static void OnBetButtonClicked(bool hometeam, bool upvote, SeasonBetEntry betEntry)
        {
            if (!upvote && hometeam && betEntry.TempHometeamBet < 1 ||
                !upvote && !hometeam && betEntry.TempAwayteamBet < 1) return;
            var index = Window.Bets.IndexOf(betEntry);
            Window.Bets.Remove(betEntry);
            if (hometeam)
            {
                betEntry.TempHometeamBet = upvote ? betEntry.TempHometeamBet + 1 : betEntry.TempHometeamBet - 1;
                betEntry.HometeamBet = betEntry.TempHometeamBet.ToString();
            }
            else
            {
                betEntry.TempAwayteamBet = upvote ? betEntry.TempAwayteamBet + 1 : betEntry.TempAwayteamBet - 1;
                betEntry.AwayteamBet = betEntry.TempAwayteamBet.ToString();
            }
            betEntry.Changed = true;
            Window.Bets.Insert(index, betEntry);
        }

        public static void OnSaveButtonClicked()
        {
            var allBetsOfSeason = Window.Bets.ToList();
            var changedBets = allBetsOfSeason.FindAll(bet => bet.Changed);
            var changedBetMessages = changedBets.Select(bet => new BetMessage
            {
                AwayTeamScore = bet.TempAwayteamBet,
                BettorId = CurrentUser.Id,
                DateTime = DateTime.Now,
                HomeTeamScore = bet.TempHometeamBet,
                MatchId = bet.MatchId
            }).ToArray();
            Service.UpdateOrCreateBetsForSeason(Window.CurrentSeason.Id, changedBetMessages);
        }
    }
}