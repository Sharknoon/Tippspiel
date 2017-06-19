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
        string CreateBet(BetMessage bet);

        [OperationContract]
        string EditBet(BetMessage bet);

        [OperationContract]
        string DeleteBet(int betId);

        [OperationContract]
        List<BettorMessage> GetAllBettors();

        [OperationContract]
        string CreateBettor(string nickname, string firstName, string lastName);

        [OperationContract]
        string EditBettor(int bettorId, string nickname, string firstName, string lastName);

        [OperationContract]
        string DeleteBettor(int bettorId);

        [OperationContract]
        List<MatchMessage> GetAllMatches();

        [OperationContract]
        string CreateMatch(int matchDay, DateTime dateTime, int homeTeamId, int awayTeamId, int seasonId);

        [OperationContract]
        string EditMatch(int matchId, int matchDay, DateTime dateTime, int homeTeamId, int awayTeamId,
            Season season);

        [OperationContract]
        string DeleteMatch(int matchId);

        [OperationContract]
        List<SeasonMessage> GetAllSeasons();

        [OperationContract]
        string CreateSeason(SeasonMessage season);

        [OperationContract]
        string EditSeason(SeasonMessage season);

        [OperationContract]
        string DeleteSeason(SeasonMessage season);

        [OperationContract]
        List<TeamMessage> GetAllTeams();

        [OperationContract]
        string CreateTeam(TeamMessage team);

        [OperationContract]
        string EditTeam(TeamMessage team);

        [OperationContract]
        string DeleteTeam(TeamMessage team);

        [OperationContract]
        List<SeasonMessage> GetSeasonsById(List<int> seasonIds);
    }
}
