using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class SeasonDateChooseController
    {
        public static SeasonDateChooseWindow SeasonDateChooseWindow;

        public static void Start()
        {
            SeasonDateChooseWindow = new SeasonDateChooseWindow();

            SeasonDateChooseWindow.ShowDialog();
        }
    }
}