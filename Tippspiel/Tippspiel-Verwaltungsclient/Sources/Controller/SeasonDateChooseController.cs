using System.Linq;
using System.Windows;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Generation;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class SeasonDateChooseController
    {
        public static SeasonDateChooseWindow SeasonDateChooseWindow;
        public static SeasonMessage Season;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void Start(SeasonMessage season)
        {
            Season = season;
            var matches = Service.GetMatchesForSeason(Season).ToList();
            var teams = Service.GetAllTeams().ToList().Where(team => team.SeasonIDs.Contains(Season.Id)).ToList();
            if (matches.Count > 0 || teams.Count != 18)
            {
                var errors = "";
                if (matches.Count > 0)
                {
                    var matchDays = matches.GroupBy(match => match.MatchDay)
                        .Aggregate("", (prev, current) => prev + current.Key + ", ");
                    matchDays = matchDays.Substring(0, matchDays.Length - 2);
                    errors += "In der Saison " + Season.Name + " befinden sich noch Spiele (Spieltag(e): " + matchDays +
                              "). Eine Saison muss leer ein, um Spiele zu generieren.\n";
                }
                if (teams.Count != 18)
                    errors += "Die Saison " + Season.Name + " hat nicht genau 18 Mannschaften (" + teams.Count +
                              "). Es können nur Saisons generiert werden, die genau 18 Mannschaften haben!";

                MessageBox.Show("Bei der Spielegenerierung sind Fehler aufgetreten:\n" + errors,
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
            var date = SeasonDateChooseWindow.Date;
            SeasonGeneration.GenerateSeason(date, Season);
            SeasonDateChooseWindow.Close();
        }

        public static void CancelDateChoose()
        {
            SeasonDateChooseWindow.Close();
        }
    }
}