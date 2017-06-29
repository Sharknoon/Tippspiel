using System;
using System.Windows;
using Tippspiel_Verwaltungsclient.Sources.Controller;

namespace Tippspiel_Verwaltungsclient.Sources.Windows
{
    /// <summary>
    ///     Interaction logic for SeasonDateChooseWindow.xaml
    /// </summary>
    public partial class SeasonDateChooseWindow
    {
        public SeasonDateChooseWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public DateTime Date { get; set; } = DateTime.Now;

        private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonDateChooseController.FinsihDateChoose();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            SeasonDateChooseController.CancelDateChoose();
        }
    }
}