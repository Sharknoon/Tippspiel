

using System;
using System.Collections.Generic;
using System.Linq;
using Tippspiel_Server.Sources.Database.Helper;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;

namespace Tippspiel_Server.Sources
{
    public class Home
    {
        public static bool DEBUG { get; } = false;

        private static void Main()
        {
            Console.WriteLine("Server booting...");

            Database.Database.InitializeDatabase();
            Service.Service.InitializeService();

            //TEMP
            const int seasonId = 1;
            var teams = Database.Database.Teams
                .GetAll().Where(team => team.Seasons.Any(season => season.Id.Equals(seasonId)))
                .Select(team => new TeamMessage()
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                }).ToList();
            Console.WriteLine("Seasongröße " + teams.Count+" Teams");


            using (var session = NHibernateHelper.OpenSession())
            {
                /*
                Team alias = null;
                teams = session.QueryOver<Team>(() => alias)
                    .JoinQueryOver(team => team.Seasons)
                    .Where(season => season.)

                teams = session.QueryOver<Team>().Left.JoinQueryOver(t => t.Seasons, () => alias, s => s.Id == seasonId).List<Team>()
                    .Select(team => new TeamMessage()
                    {
                        Id = team.Id,
                        Name = team.Name,
                        SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                    }).ToList();*/
            }

            Console.WriteLine("Seasongröße " + teams.Count + " Teams");
            //TEMP

            Console.WriteLine("Server booted, press <Enter> To Exit");
            Console.Read();

            Service.Service.ShutdownService();
        }
    }
}