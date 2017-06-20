using System;
using System.Collections.Generic;
using System.Linq;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class SeasonDateChooseController
    {
        public static SeasonDateChooseWindow SeasonDateChooseWindow;

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void Start()
        {
            SeasonDateChooseWindow = new SeasonDateChooseWindow();

            SeasonDateChooseWindow.ShowDialog();
        }

        public static void FinsihDateChoose()
        {
            DateTime date = SeasonDateChooseWindow.Date;

            List<TeamMessage> allTeams = Service.GetAllTeams().ToList();
            Random random = new Random();
            List<TeamMessage> shuffeledTeams = allTeams.OrderBy(item => random.Next()).ToList();
            for (int i = 1; i <= allTeams.Count-1; i++)//AllTeams.count-1 = anzahl spieltag / runde (hin bzw rückrunde) PRO RUNDE, für jeden Spieltag
            {
                for (int j = 0; j < allTeams.Count/2; j++)//PRO SPIELTAG, Für Jedes Spiel
                {
                    
                }

            }
            

            SeasonDateChooseWindow.Close();
        }

        public static void CancelDateChoose()
        {
            SeasonDateChooseWindow.Close();
        }
    }
}