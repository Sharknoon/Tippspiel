using System.Collections.Generic;
using System.Windows;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for TeamEditingSeasonSelectionWindow.xaml
    /// </summary>
    public partial class TeamEditingSeasonSelectionWindow
    {
        public TeamEditingSeasonSelectionWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public List<ListItem> ListItems { get; set; }

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