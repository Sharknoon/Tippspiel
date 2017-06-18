using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
using Tippspiel_Server.Sources.Validators.Helper;
using Match = System.Text.RegularExpressions.Match;

namespace Tippspiel_Server.Sources.Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Ping();

        [OperationContract]
        List<BetMessage> GetAllBets(int bettorId);

        [OperationContract]
        IValidationMessage CreateBet(DateTime dateTime, int homeTeamScore, int awayTeamScore, int matchId,
            Bettor bettor);

        [OperationContract]
        IValidationMessage EditBet(int betId, DateTime dateTime, int homeTeamScore, int awayTeamScore, int matchId,
            Bettor bettor);

        [OperationContract]
        IValidationMessage DeleteBet(int betId);

        [OperationContract]
        List<BettorsMessage> GetAllBettors();

        [OperationContract]
        IValidationMessage CreateBettor(string nickname, string firstName, string lastName);

        [OperationContract]
        IValidationMessage EditBettor(int bettorId, string nickname, string firstName, string lastName);

        [OperationContract]
        IValidationMessage DeleteBettor(int bettorId);

        [OperationContract]
        List<MatchMessage> GetAllMatches();

        [OperationContract]
        IValidationMessage CreateMatch(int matchDay, DateTime dateTime, int homeTeamId, int awayTeamId, int seasonId);

        [OperationContract]
        IValidationMessage EditMatch(int matchId, int matchDay, DateTime dateTime, int homeTeamId, int awayTeamId,
            Season season);

        [OperationContract]
        IValidationMessage DeleteMatch(int matchId);

        [OperationContract]
        List<SeasonMessage> GetAllSeasons();

        [OperationContract]
        IValidationMessage CreateSeason(string name, string description, int sequence);

        [OperationContract]
        IValidationMessage EditSeason(int seasonId, string name, string description, int sequence);

        [OperationContract]
        IValidationMessage DeleteSeason(int seasonId);

        [OperationContract]
        List<TeamMessage> GetAllTeams();

        [OperationContract]
        IValidationMessage CreateTeam(string name);

        [OperationContract]
        IValidationMessage EditTeam(int teamId, string name);

        [OperationContract]
        IValidationMessage DeleteTeaMessage(int teamId);


    }
}
