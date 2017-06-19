using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for TeamEditingSeasonSelection.xaml
    /// </summary>
    public partial class TeamEditingSeasonSelection : Window
    {
        public List<ListItem> ListItems { get; set; }
        public TeamMessage Team;
        public ServiceClient Service = WcfHelper.ServiceClient;

        public TeamEditingSeasonSelection(TeamMessage team)
        {
            InitializeComponent();
            DataContext = this;

            Team = team;
            ListItems = Service.GetAllSeasons().Select(season => new ListItem()
            {
                Id = season.Id,
                Text = season.Name,
                IsChecked = team.SeasonIDs.Contains(season.Id)
            }).ToList();
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            Team.SeasonIDs = ListItems.Where(item => item.IsChecked).Select(item => item.Id).ToArray();
            Close();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class ListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
}
