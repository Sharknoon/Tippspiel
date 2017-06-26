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
        public static Repository2T<Team,Season> Teams { get; private set; }

        public static Repository2T<Season,Team> Seasons { get; private set; }

        public static Repository3T<Match, Team, Season> Matches { get; private set; }

        public static Repository3T<Bet, Match, Bettor> Bets { get; private set; }

        public static Repository1T<Bettor> Bettors { get; private set; }

        public static string PingString;

        public static void InitializeDatabase()
        {
            NHibernateHelper.DatabaseFile = "..\\..\\Ressources\\Database\\LigaManager.db3";

            Teams = new Repository2T<Team, Season>();
            Seasons = new Repository2T<Season, Team>();
            Matches = new Repository3T<Match, Team, Season>();
            Bets = new Repository3T<Bet, Match, Bettor>();
            Bettors = new Repository1T<Bettor>();
        }

    }
}