using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
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

        public string Ping()
        {
            return new StringBuilder(Database.Database.PingString+" ").ToString();
        }

        public List<BetMessage> GetAllBets(int bettorId)
        {
            return Database.Database.BetMessages;
        }

        public IValidationMessage CreateBet(DateTime dateTime, int homeTeamScore, int awayTeamScore, int matchId, Bettor bettor)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage EditBet(int betId, DateTime dateTime, int homeTeamScore, int awayTeamScore, int matchId,
            Bettor bettor)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage DeleteBet(int betId)
        {
            throw new NotImplementedException();
        }

        public List<BettorsMessage> GetAllBettors()
        {
            return Database.Database.BettorsMessages;
        }

        public IValidationMessage CreateBettor(string nickname, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage EditBettor(int bettorId, string nickname, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage DeleteBettor(int bettorId)
        {
            throw new NotImplementedException();
        }

        public List<MatchMessage> GetAllMatches()
        {
            return Database.Database.MatchMessages;
        }

        public IValidationMessage CreateMatch(int matchDay, DateTime dateTime, int homeTeamId, int awayTeamId, int seasonId)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage EditMatch(int matchId, int matchDay, DateTime dateTime, int homeTeamId, int awayTeamId,
            Season season)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage DeleteMatch(int matchId)
        {
            throw new NotImplementedException();
        }

        public List<SeasonMessage> GetAllSeasons()
        {
            var toReturn = new List<SeasonMessage>();
            Database.Database.SeasonMessages.ForEach(season => toReturn.Add(season));
            return toReturn;
        }

        public IValidationMessage CreateSeason(string name, string description, int sequence)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage EditSeason(int seasonId, string name, string description, int sequence)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage DeleteSeason(int seasonId)
        {
            throw new NotImplementedException();
        }

        public List<TeamMessage> GetAllTeams()
        {
            return Database.Database.TeamMessages;
        }

        public IValidationMessage CreateTeam(string name)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage EditTeam(int teamId, string name)
        {
            throw new NotImplementedException();
        }

        public IValidationMessage DeleteTeaMessage(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}
