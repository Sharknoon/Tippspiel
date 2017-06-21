using System;
using System.Collections.Generic;
using System.Linq;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Generation
{
    public class SeasonGeneration
    {
        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static void GenerateSeason(DateTime date)
        {
            List<TeamMessage> allTeams = Service.GetAllTeams().ToList();

            Random random = new Random();
            List<TeamMessage> shuffeledTeams = allTeams.OrderBy(item => random.Next()).ToList();

            Rotator rot = FillRotator(shuffeledTeams);
        }

        public static Rotator FillRotator(List<TeamMessage> shuffeledTeams)
        {
            Rotator rot = new Rotator();
            rot.TopRow = shuffeledTeams.GetRange(0, 8);
            rot.BottomRow = shuffeledTeams.GetRange(9, 8);
            List<TeamMessage> right = new List<TeamMessage>(2);
            right.Add(shuffeledTeams[8]);
            right.Add(shuffeledTeams[17]);
            rot.Right = right;
            return rot;
        }
    }
}