using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<Bet> GetAllBets(Bettor bettor);

        [OperationContract]
        IValidationMessage CreateBet(DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor);

        [OperationContract]
        IValidationMessage EditBet(Bet bet, DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor);

        [OperationContract]
        IValidationMessage DeleteBet(Bet bet);

        [OperationContract]
        List<Bettor> GetAllBettors();

        [OperationContract]
        IValidationMessage CreateBettor(string nickname, string firstName, string lastName);

        [OperationContract]
        IValidationMessage EditBettor(Bettor bettor, string nickname, string firstName, string lastName);

        [OperationContract]
        IValidationMessage DeleteBettor(Bettor bettor);

        [OperationContract]
        List<Match> GetAllMatches();

        [OperationContract]
        IValidationMessage CreateMatch(int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam, Season season);

        [OperationContract]
        IValidationMessage EditMatch(Match match, int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam,
            Season season);

        [OperationContract]
        IValidationMessage DeleteMatch(Match match);

        [OperationContract]
        List<Season> GetAllSeasons();

        [OperationContract]
        IValidationMessage CreateSeason(string name, string description, int sequence);

        [OperationContract]
        IValidationMessage EditSeason(Season season, string name, string description, int sequence);

        [OperationContract]
        IValidationMessage DeleteSeason(Season season);

        [OperationContract]
        List<Team> GetAllTeams();

        [OperationContract]
        IValidationMessage CreateTeam(string name);

        [OperationContract]
        IValidationMessage EditTeam(Team team, string name);

        [OperationContract]
        IValidationMessage DeleteTeaMessage(Team team);


    }
}
