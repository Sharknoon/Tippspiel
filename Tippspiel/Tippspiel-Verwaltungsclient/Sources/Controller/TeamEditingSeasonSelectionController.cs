using System.Linq;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class TeamEditingSeasonSelectionController
    {
        public static TeamEditingSeasonSelectionWindow TeamEditingSeasonSelectionWindow;
        public static TeamMessage Team;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void Start(TeamMessage team)
        {
            Team = team;
            TeamEditingSeasonSelectionWindow = new TeamEditingSeasonSelectionWindow
            {
                ListItems = Service.GetAllSeasons()
                    .Select(season => new ListItem
                    {
                        Id = season.Id,
                        Text = season.Name,
                        IsChecked = team.SeasonIDs.Contains(season.Id)
                    })
                    .ToList()
            };

            TeamEditingSeasonSelectionWindow.ShowDialog();
        }

        public static void FinishSelection()
        {
            Team.SeasonIDs = TeamEditingSeasonSelectionWindow.ListItems.Where(item => item.IsChecked)
                .Select(item => item.Id).ToArray();
            TeamEditingSeasonSelectionWindow.Close();
        }

        public static void CancelSelection()
        {
            TeamEditingSeasonSelectionWindow.Close();
        }
    }
}