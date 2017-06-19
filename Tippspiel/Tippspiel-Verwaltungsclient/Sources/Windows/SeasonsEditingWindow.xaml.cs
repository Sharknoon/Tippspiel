using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for SeasonsEditingWindow.xaml
    /// </summary>
    public partial class SeasonsEditingWindow : Window
    {
        public ServiceClient Service = WcfHelper.ServiceClient;
        public SeasonMessage Season { get; set; }
        public bool NewSeason;

        public SeasonsEditingWindow(SeasonMessage season, bool newSeason)
        {
            InitializeComponent();
            DataContext = this;

            Season = season;
            NewSeason = newSeason;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            string errors;
            errors = NewSeason ? Service.CreateSeason(Season) : Service.EditSeason(Season);
            if (errors.IsNotEmpty())
            {
                MessageBox.Show("Es sind folgende Fehler bei der Saisonbearbeitung aufgetreten:\n" + errors,
                    "Fehler bei der Saisonbearbeitung", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Close();
            }
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBoxSeasonSequence_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
