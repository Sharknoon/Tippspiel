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
        public static List<TeamMessage> TeamMessages { get; private set; }

        public static Repository<Season> Seasons { get; private set; }
        public static List<SeasonMessage> SeasonMessages { get; private set; }

        public static Repository<Match> Matches { get; private set; }
        public static List<MatchMessage> MatchMessages { get; private set; }

        public static Repository<Bet> Bets { get; private set; }
        public static List<BetMessage> BetMessages { get; private set; }

        public static Repository<Bettor> Bettors { get; private set; }
        public static List<BettorsMessage> BettorsMessages { get; private set; }

        public static string PingString;

        public static void InitializeDatabase()
        {
            NHibernateHelper.DatabaseFile = "..\\..\\Ressources\\Database\\LigaManager.db3";
            Console.WriteLine("Starting Initialization...");
            var startDateTime = DateTime.Now;

            Teams = new Repository<Team>();
            InitializeTeams();
            Seasons = new Repository<Season>();
            InitializeSeasons();
            Matches = new Repository<Match>();
            InitializeMatches();
            Bets = new Repository<Bet>();
            InitializeBets();
            Bettors = new Repository<Bettor>();
            InitializeBettors();

            Console.WriteLine("Finished Initialization in " + (DateTime.Now - startDateTime));
        }

        public static void InitializeTeams()
        {
            TeamMessages = Teams.GetAll().Select(team => new TeamMessage()
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                })
                .ToList();
        }

        public static void InitializeSeasons()
        {
            SeasonMessages = Seasons.GetAll().Select(season => new SeasonMessage()
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
            MatchMessages = Matches.GetAll().Select(match => new MatchMessage()
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
            BetMessages = Bets.GetAll().Select(bet => new BetMessage()
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

        public static void InitializeBettors()
        {
            BettorsMessages = Bettors.GetAll().Select(bettor => new BettorsMessage()
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