using System;
using System.Windows;
using Tippspiel_Benutzerclient.Sources.Controller;

namespace Tippspiel_Benutzerclient
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                MainController.Init();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "Ein unerwarteter Fehler ist aufgetreten :/\nBitte seien Sie gnädig und geben Sie nicht zu viel Punktabzug\n" +
                    e, "Unerwarteter Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}