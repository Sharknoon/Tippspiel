using System.Windows;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for XmlFileChooseWindow.xaml
    /// </summary>
    public partial class XmlFileChooseWindow
    {
        public XmlFileChooseWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Text { get; set; }

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            XmlFileChooseController.FinsishChoosing();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            XmlFileChooseController.CancelChoosing();
        }


        private void ButtonChoose_OnClick(object sender, RoutedEventArgs e)
        {
            XmlFileChooseController.ChooseFile();
        }

        public void SetText(string text)
        {
            Text = text;
        }
    }
}