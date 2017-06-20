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
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    /// Interaction logic for XmlFileChooseWindow.xaml
    /// </summary>
    public partial class XmlFileChooseWindow : Window
    {
        public string Text { get; set; }

        public XmlFileChooseWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

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
