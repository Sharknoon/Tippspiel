using System;
using System.Windows;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class MainController
    {
        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static bool CheckConnection()
        {
            try
            {
                Service.Ping();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Der Server ist unerreichbar, bitte kontaktieren Sie den Administrator", "Server unerreichbar",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }

        public static void OnUnexpectedError(Exception ex)
        {
            MessageBox.Show(
                "Oh nein, es sind unerwartete Fehler aufgetreten :/ \nBitte seien Sie gnädig und geben Sie nicht zu viel Punktabzug\nException: " +
                ex + "\nInner Exception: " + ex.InnerException,
                "Unerwarteter Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}