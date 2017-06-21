using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class SeasonDateChooseController
    {
        public static SeasonDateChooseWindow SeasonDateChooseWindow;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void Start(SeasonMessage season)
        {
            var matches = Service.GetMatchesForSeason(season).ToList();
            var teams = Service.GetAllTeams().ToList().Where(team => team.SeasonIDs.Contains(season.Id)).ToList();
            if (matches.Count > 0 || teams.Count() != 18)
            {
                var errors = "";
                if (matches.Count > 0)
                {
                    var matchDays = matches.GroupBy(match => match.MatchDay).Aggregate("", (prev, current) => prev + current.Key + ", ");
                    matchDays = matchDays.Substring(0, matchDays.Length - 2);
                    errors += "In der Saison " + season.Name + " befinden sich noch Spiele (Spieltag(e): " + matchDays +
                              "). Eine Saison muss leer ein, um Spiele zu generieren.\n";
                }
                if (teams.Count != 18)
                {
                    errors += "Die Saison " + season.Name + " hat nicht genau 18 Mannschaften (" + teams.Count +
                              "). Es können nur Saisons generiert werden, die genau 18 Mannschaften haben!";
                }

                MessageBox.Show("Bei der Spielegenerierung sind Fehler aufgetreten:\n"+errors,
                    "Fehler bei der Spielegeneration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SeasonDateChooseWindow = new SeasonDateChooseWindow();

                SeasonDateChooseWindow.ShowDialog();
            }
        }

        public static void FinsihDateChoose()
        {
            DateTime date = SeasonDateChooseWindow.Date;

            
                List<TeamMessage> allTeams = Service.GetAllTeams().ToList();

            for (int i = 1; i <= allTeams.Count-1; i++)//AllTeams.count-1 = anzahl spieltag / runde (hin bzw rückrunde) PRO RUNDE, für jeden Spieltag
            {
                for (int j = 0; j < allTeams.Count/2; j++)//PRO SPIELTAG, Für Jedes Spiel
                {
                    
                }

            }
            

            SeasonDateChooseWindow.Close();
        }

        public static void CancelDateChoose()
        {
            SeasonDateChooseWindow.Close();
        }
    }
}