using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Utils;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in both code and config file together.
    public class Service : IService
    {
        private static ServiceHost _service;

        public static void InitializeService()
        {
          _service = new ServiceHost(typeof(Service));
                _service.Open();

            Logger.WriteLine("Service is up and running");
        }

        public static void ShutdownService()
        {
            if (_service != null && _service.State.Equals(CommunicationState.Opened))
            {
                _service.Close();
            }
        }

        public List<Bet> GetAllBets(Bettor bettor)
        {
            return Database.Database.Bets;
        }

        public IValidationMessage CreateBet(DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage EditBet(Bet bet, DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage DeleteBet(Bet bet)
        {
            return new ValidationSuccess();
        }

        public List<Bettor> GetAllBettors()
        {
            return Database.Database.Bettors;
        }

        public IValidationMessage CreateBettor(string nickname, string firstName, string lastName)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage EditBettor(Bettor bettor, string nickname, string firstName, string lastName)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage DeleteBettor(Bettor bettor)
        {
            return new ValidationSuccess();
        }

        public List<Match> GetAllMatches()
        {
            return Database.Database.Matches;
        }

        public IValidationMessage CreateMatch(int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam,
            Season season)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage EditMatch(Match match, int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam,
            Season season)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage DeleteMatch(Match match)
        {
            return new ValidationSuccess();
        }

        public List<Season> GetAllSeasons()
        {
            Console.WriteLine("Erfolgreich in getAllSeaons angekommen!!");
            var Season1 = new Season()
            {
                Name = "Season1",
                Sequence = 1,
                Description = "blaaa",
                Teams = new List<Team>(),
                Id = 0,
                Version = 0
            };
            var Season2 = new Season()
            {
                Name = "Season1",
                Sequence = 1,
                Description = "blaaa",
                Teams = new List<Team>(),
                Id = 0,
                Version = 0
            };
            List<Season> Seasons = new List<Season> {Season1, Season2};
            return Seasons;
        }

        public IValidationMessage CreateSeason(string name, string description, int sequence)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage EditSeason(Season season, string name, string description, int sequence)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage DeleteSeason(Season season)
        {
            return new ValidationSuccess();
        }

        public List<Team> GetAllTeams()
        {
            return Database.Database.Teams;
        }

        public IValidationMessage CreateTeam(string name)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage EditTeam(Team team, string name)
        {
            return new ValidationSuccess();
        }

        public IValidationMessage DeleteTeaMessage(Team team)
        {
            return new ValidationSuccess();
        }
    }
}
