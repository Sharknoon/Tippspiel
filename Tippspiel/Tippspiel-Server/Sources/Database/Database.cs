using System;
using System.Collections.Generic;
using Tippspiel_Server.Sources.Database.Helper;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Database
{
    public class Database
    {
        public static List<Team> Teams;
        public static List<Season> Seasons;
        public static List<Match> Matches;


        public static void InitializeDatabase()
        {
            NHibernateHelper.DatabaseFile = "..\\..\\Ressources\\Database\\LigaManager.db3";
            InitializeTeams();
            InitializeSeasons();
            InitializeMatches();
        }

        public static void InitializeTeams()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("******Initializing Teams******");
            Console.WriteLine("******************************");
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Team>().List();
                foreach (var team in returnList)
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine(team.Name);
                    foreach (var teamSeason in team.Seasons)
                    {
                        Console.WriteLine("--"+teamSeason.Name);
                        Console.WriteLine("--Beschreibung:  " + teamSeason.Description);
                        Console.WriteLine("--Spieltag:      " + teamSeason.Sequence);
                        Console.WriteLine("--Teamanzahl:    " + teamSeason.Teams.Count+" Teams");
                    }
                }
            }
        }

        public static void InitializeSeasons()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("*****Initializing Seasons*****");
            Console.WriteLine("******************************");
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Season>().List();
                foreach (var season in returnList)
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Name:          "+season.Name);
                    Console.WriteLine("Beschreibung:  " + season.Description);
                    Console.WriteLine("Spieltag:      " + season.Sequence);
                    Console.WriteLine("Teamanzahl:    " + season.Teams.Count + " Teams");
                    foreach (var seasonTeam in season.Teams)
                    {
                        Console.WriteLine("--"+seasonTeam.Name);
                    }
                }
            }
        }

        public static void InitializeMatches()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("*****Initializing Matches*****");
            Console.WriteLine("******************************");
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Match>().List();
                foreach (var match in returnList)
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Spieltag:          " + match.MatchDay);
                    Console.WriteLine("Datum des Spieles: "+ match.DateTime);
                    Console.WriteLine("HeimTeamScore:     " + match.HomeTeamScore);
                    Console.WriteLine("GastTeamScore:     " + match.AwayTeamScore);
                    Console.WriteLine("HeimTeam:          " + match.HomeTeam.Name);
                    Console.WriteLine("GastTeam:          " + match.AwayTeam.Name);
                    Console.WriteLine("Season:            " + match.Season.Name);
                }
            }
        }

    }
}