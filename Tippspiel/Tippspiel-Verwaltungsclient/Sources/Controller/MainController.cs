using System;
using System.ServiceModel.Description;
using System.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class MainController
    {
        public static void OnUnexpectedError(Exception ex)
        {
            MessageBox.Show("Oh nein, es sind unerwartete Fehler aufgetreten :/ \nBitte seien Sie gnädig und geben Sie nicht zu viel Punktabzug\nException: "+ ex+"\nInner Exception: "+ex.InnerException,
                "Unerwarteter Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}