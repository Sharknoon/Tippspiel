using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tippspiel_Benutzerclient.Sources.Controller;

namespace Tippspiel_Benutzerclient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            //try
            //{
                MainController.Init();
            /*}
            catch (Exception e)
            {
                MessageBox.Show(
                    "Ein unerwarteter Fehler ist aufgetreten :/\nBitte seien Sie gnädig und geben Sie nicht zu viel Punktabzug\n" +
                    e, "Unerwarteter Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            */
        }
    }
}
