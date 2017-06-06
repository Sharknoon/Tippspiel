using System;
using System.Collections.Generic;
using Tippspiel_Server.Sources.Database.Helper;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Utils;

namespace Tippspiel_Server.Sources.Database
{
    public class Database
    {
        public static List<Team> Teams { get; private set; }
        public static List<Season> Seasons { get; private set; }
        public static List<Match> Matches { get; private set; }
        public static List<Bet> Bets { get; private set; }
        public static List<Bettor> Bettors { get; private set; }


        public static void InitializeDatabase()
        {
            NHibernateHelper.DatabaseFile = "..\\..\\Ressources\\Database\\LigaManager.db3";
            Console.WriteLine("Starting Initialization...");
            DateTime startDateTime = DateTime.Now;
            InitializeTeams();
            InitializeSeasons();
            InitializeMatches();
            InitializeBets();
            InitializeBettors();
            Console.WriteLine("Finished Initialization in "+(DateTime.Now - startDateTime));
        }

        public static void InitializeTeams()
        {
            Logger.WriteLine("******************************");
            Logger.WriteLine("******Initializing Teams******");
            Logger.WriteLine("******************************");
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Team>().List();
                Teams = returnList as List<Team>;
                foreach (var team in returnList)
                {
                    Logger.WriteLine("----------------Team-----------------");
                    Logger.WriteLine(team.Name);
                    foreach (var teamSeason in team.Seasons)
                    {
                        Logger.WriteLine("--"+teamSeason.Name);
                        Logger.WriteLine("--Beschreibung:  " + teamSeason.Description);
                        Logger.WriteLine("--Spieltag:      " + teamSeason.Sequence);
                        Logger.WriteLine("--Teamanzahl:    " + teamSeason.Teams.Count+" Teams");
                    }
                }
            }
        }

        public static void InitializeSeasons()
        {
            Logger.WriteLine("******************************");
            Logger.WriteLine("*****Initializing Seasons*****");
            Logger.WriteLine("******************************");
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Season>().List();
                Seasons = returnList as List<Season>;
                foreach (var season in returnList)
                {
                    Logger.WriteLine("---------------Season----------------");
                    Logger.WriteLine("Name:          "+season.Name);
                    Logger.WriteLine("Beschreibung:  " + season.Description);
                    Logger.WriteLine("Spieltag:      " + season.Sequence);
                    Logger.WriteLine("Teamanzahl:    " + season.Teams.Count + " Teams");
                    foreach (var seasonTeam in season.Teams)
                    {
                        Logger.WriteLine("--"+seasonTeam.Name);
                    }
                }
            }
        }

        public static void InitializeMatches()
        {
            Logger.WriteLine("******************************");
            Logger.WriteLine("*****Initializing Matches*****");
            Logger.WriteLine("******************************");
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Match>().List();
                Matches = returnList as List<Match>;
                foreach (var match in returnList)
                {
                    Logger.WriteLine("---------------Match-----------------");
                    Logger.WriteLine("Spieltag:          " + match.MatchDay);
                    Logger.WriteLine("Datum des Spieles: "+ match.DateTime);
                    Logger.WriteLine("HeimTeamScore:     " + match.HomeTeamScore);
                    Logger.WriteLine("GastTeamScore:     " + match.AwayTeamScore);
                    Logger.WriteLine("HeimTeam:          " + match.HomeTeam.Name);
                    Logger.WriteLine("GastTeam:          " + match.AwayTeam.Name);
                    Logger.WriteLine("Season:            " + match.Season.Name);
                }
            }
        }

        public static void InitializeBets()
        {
            Logger.WriteLine("******************************");
            Logger.WriteLine("*****Initializing Bets********");
            Logger.WriteLine("******************************");
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Bet>().List();
                Bets = returnList as List<Bet>;
                foreach (var bet in returnList)
                {
                    Logger.WriteLine("----------------Bet------------------");
                    Logger.WriteLine("Datum der Wette:   " + bet.DateTime);
                    Logger.WriteLine("HeimTeamScore:     " + bet.HomeTeamScore);
                    Logger.WriteLine("GastTeamScore:     " + bet.AwayTeamScore);
                    Logger.WriteLine("Spiel:             " + bet.Match.MatchDay);
                    Logger.WriteLine("Wetter:            " + bet.Bettor.Nickname);
                }
            }
        }

        public static void InitializeBettors()
        {
            Logger.WriteLine("******************************");
            Logger.WriteLine("****Initializing Bettors******");
            Logger.WriteLine("******************************");
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.QueryOver<Bettor>().List();
                Bettors = returnList as List<Bettor>;
                foreach (var bettor in returnList)
                {
                    Logger.WriteLine("---------------Bettor----------------");
                    Logger.WriteLine("Vorname:           " + bettor.Firstname);
                    Logger.WriteLine("Nachname:          " + bettor.Lastname);
                    Logger.WriteLine("Benutzername:      " + bettor.Nickname);
                }
            }
        }
    }
}