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
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for TeamEditingSeasonSelectionWindow.xaml
    /// </summary>
    public partial class TeamEditingSeasonSelectionWindow : Window
    {
        public List<ListItem> ListItems { get; set; }

        public TeamEditingSeasonSelectionWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            TeamEditingSeasonSelectionController.FinishSelection();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            TeamEditingSeasonSelectionController.CancelSelection();
        }
    }

    public class ListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
}
