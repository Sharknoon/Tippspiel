using System;
using System.Collections.Generic;
using System.Linq;
using Tippspiel_Server.Sources.Database.Helper;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
using Tippspiel_Server.Sources.Utils;

namespace Tippspiel_Server.Sources.Database
{
    public class Database
    {
        public static Repository<Team> Teams { get; private set; }

        public static Repository<Season> Seasons { get; private set; }

        public static Repository<Match> Matches { get; private set; }

        public static Repository<Bet> Bets { get; private set; }

        public static Repository<Bettor> Bettors { get; private set; }

        public static string PingString;

        public static void InitializeDatabase()
        {
            NHibernateHelper.DatabaseFile = "..\\..\\Ressources\\Database\\LigaManager.db3";
            Console.WriteLine("Starting Initialization...");
            var startDateTime = DateTime.Now;

            Teams = new Repository<Team>();
            Seasons = new Repository<Season>();
            Matches = new Repository<Match>();
            Bets = new Repository<Bet>();
            Bettors = new Repository<Bettor>();

            Console.WriteLine("Finished Initialization in " + (DateTime.Now - startDateTime));
        }

    }
}