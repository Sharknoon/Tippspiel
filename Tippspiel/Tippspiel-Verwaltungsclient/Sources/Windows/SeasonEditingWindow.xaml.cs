using System.Windows;
using System.Windows.Input;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for SeasonEditingWindow.xaml
    /// </summary>
    public partial class SeasonEditingWindow
    {
        public SeasonEditingWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public SeasonMessage Season { get; set; }

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