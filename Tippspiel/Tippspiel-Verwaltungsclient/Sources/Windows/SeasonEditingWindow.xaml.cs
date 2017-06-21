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
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for SeasonEditingWindow.xaml
    /// </summary>
    public partial class SeasonEditingWindow : Window
    {
        public SeasonMessage Season { get; set; }

        public SeasonEditingWindow(SeasonMessage season)
        {
            InitializeComponent();
            DataContext = this;

            Season = season;
        }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonsEditingController.FinishEditing();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonsEditingController.CancelEditing();
        }

        private void TextBoxSeasonSequence_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = SeasonsEditingController.IsNumeric(e.Text);
        }
    }
}
