using System;
using Tippspiel_Server.Models;

namespace Tippspiel_Server.Database
{
    public class Database
    {
        public static void InitializeDatabase()
        {
            NHibernateHelper.DatabaseFile = "..\\..\\Ressources\\Database\\LigaManager.db3";
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Team>().List();
                foreach (var team in returnList)
                {
                    Console.WriteLine(team.Name);
                }
                Console.Read();
            }
        }
    }
}