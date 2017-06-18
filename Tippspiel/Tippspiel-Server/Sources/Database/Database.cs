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
        public static List<Team> Teams { get; private set; }
        public static Dictionary<int, Team> TeamsMap { get; private set; }
        public static List<TeamMessage> TeamMessages { get; private set; }

        public static List<Season> Seasons { get; private set; }
        public static Dictionary<int, Season> SeasonsMap { get; private set; }
        public static List<SeasonMessage> SeasonMessages { get; private set; }

        public static List<Match> Matches { get; private set; }
        public static Dictionary<int, Match> MatchesMap { get; private set; }
        public static List<MatchMessage> MatchMessages { get; private set; }

        public static List<Bet> Bets { get; private set; }
        public static Dictionary<int, Bet> BetsMap { get; private set; }
        public static List<BetMessage> BetMessages { get; private set; }

        public static List<Bettor> Bettors { get; private set; }
        public static Dictionary<int, Bettor> BettorsMap { get; private set; }
        public static List<BettorsMessage> BettorsMessages { get; private set; }

        public static string PingString;

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
                TeamsMap = new Dictionary<int, Team>();
                foreach (var team in returnList)
                {
                    TeamsMap.Add(team.Id, team);
                    Logger.WriteLine("----------------Team-----------------");
                    Logger.WriteLine(team.Name);
                    foreach (var teamSeason in team.Seasons)
                    {
                        Logger.WriteLine("--"+teamSeason.Name);
                        Logger.WriteLine("--Beschreibung:  " + teamSeason.Description);
                        Logger.WriteLine("--Spieltag:      " + teamSeason.Sequence);
                    }
                }
            }
            if (Teams != null)
                TeamMessages = Teams.Select(team => new TeamMessage()
                    {
                        Id = team.Id,
                        Name = team.Name,
                        SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                    })
                    .ToList();
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
                SeasonsMap = new Dictionary<int, Season>();
                foreach (var season in returnList)
                {
                    SeasonsMap.Add(season.Id,season);
                    PingString = season.Name;
                    Logger.WriteLine("---------------Season----------------");
                    Logger.WriteLine("Name:          "+season.Name);
                    Logger.WriteLine("Beschreibung:  " + season.Description);
                    Logger.WriteLine("Spieltag:      " + season.Sequence);
                }
            }
            if (Seasons != null)
                SeasonMessages = Seasons.Select(season => new SeasonMessage()
                    {
                        Id = season.Id,
                        Name = season.Name,
                        Sequence = season.Sequence,
                        Description = season.Description,
                        TeamIds = season.Teams.Select(team => team.Id).ToList()
                    })
                    .ToList();
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
                MatchesMap = new Dictionary<int, Match>();
                foreach (var match in returnList)
                {
                    MatchesMap.Add(match.Id,match);
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
            if (Matches != null)
                MatchMessages = Matches.Select(match => new MatchMessage()
                    {
                        MatchDay = match.MatchDay,
                        Id = match.Id,
                        DateTime = match.DateTime,
                        AwayTeamScore = match.AwayTeamScore,
                        HomeTeamScore = match.HomeTeamScore,
                        AwayTeamId = match.AwayTeam.Id,
                        HomeTeamId = match.HomeTeam.Id,
                        SeasonId = match.Season.Id
                    })
                    .ToList();
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
                BetsMap = new Dictionary<int, Bet>();
                foreach (var bet in returnList)
                {
                    BetsMap.Add(bet.Id, bet);
                    Logger.WriteLine("----------------Bet------------------");
                    Logger.WriteLine("Datum der Wette:   " + bet.DateTime);
                    Logger.WriteLine("HeimTeamScore:     " + bet.HomeTeamScore);
                    Logger.WriteLine("GastTeamScore:     " + bet.AwayTeamScore);
                    Logger.WriteLine("Spiel:             " + bet.Match.MatchDay);
                    Logger.WriteLine("Wetter:            " + bet.Bettor.Nickname);
                }
                if (Bets != null)
                    BetMessages = Bets.Select(bet => new BetMessage()
                        {
                            Id = bet.Id,
                            DateTime = bet.DateTime,
                            HomeTeamScore = bet.HomeTeamScore,
                            AwayTeamScore = bet.AwayTeamScore,
                            BettorId = bet.Bettor.Id,
                            MatchId = bet.Match.Id
                        })
                        .ToList();
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
                BettorsMap = new Dictionary<int, Bettor>();
                foreach (var bettor in returnList)
                {
                    BettorsMap.Add(bettor.Id,bettor);
                    Logger.WriteLine("---------------Bettor----------------");
                    Logger.WriteLine("Vorname:           " + bettor.Firstname);
                    Logger.WriteLine("Nachname:          " + bettor.Lastname);
                    Logger.WriteLine("Benutzername:      " + bettor.Nickname);
                }
            }
            if (Bettors != null)
                BettorsMessages = Bettors.Select(bettor => new BettorsMessage()
                    {
                        Nickname = bettor.Nickname,
                        Id = bettor.Id,
                        Firstname = bettor.Firstname,
                        Lastname = bettor.Lastname
                    })
                    .ToList();
        }
    }
}