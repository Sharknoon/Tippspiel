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
        string CreateBet(BetMessage b);

        [OperationContract]
        string EditBet(BetMessage b);

        [OperationContract]
        string DeleteBet(BetMessage b);

        [OperationContract]
        List<BettorMessage> GetAllBettors();

        [OperationContract]
        string CreateBettor(BettorMessage b);

        [OperationContract]
        string EditBettor(BettorMessage b);

        [OperationContract]
        string DeleteBettor(BettorMessage b);

        [OperationContract]
        List<MatchMessage> GetAllMatches();

        [OperationContract]
        List<MatchMessage> GetAllMatchesForMatchDayInSeason(int seasonId, int matchDay);

        [OperationContract]
        string CreateMatch(MatchMessage m);

        [OperationContract]
        string EditMatch(MatchMessage m);

        [OperationContract]
        string DeleteMatch(MatchMessage m);

        [OperationContract]
        List<SeasonMessage> GetAllSeasons();

        [OperationContract]
        string CreateSeason(SeasonMessage s);

        [OperationContract]
        string EditSeason(SeasonMessage s);

        [OperationContract]
        string DeleteSeason(SeasonMessage s);

        [OperationContract]
        List<TeamMessage> GetAllTeams();

        [OperationContract]
        string CreateTeam(TeamMessage t);

        [OperationContract]
        string EditTeam(TeamMessage t);

        [OperationContract]
        string DeleteTeam(TeamMessage t);

        [OperationContract]
        List<SeasonMessage> GetSeasonsById(List<int> seasonIds);

        [OperationContract]
        List<TeamMessage> GetTeamsById(List<int> teamIds);

        [OperationContract]
        List<TeamMessage> GetTeamByName(string name);

        [OperationContract]
        List<MatchMessage> GetMatchesById(List<int> matchIds);

        [OperationContract]
        List<MatchMessage> GetMatchesForSeason(SeasonMessage season);

        [OperationContract]
        string CreateMatches(List<MatchMessage> matches);

        [OperationContract]
        List<BettorMessage> LoginBettor(string username);

        [OperationContract]
        List<TeamMessage> GetAllTeamsForSeason(int seasonId);

        [OperationContract]
        List<MatchMessage> GetAllMatchesForSeason(int seasonId);

        [OperationContract]
        List<BetMessage> GetAllBetsForBettorInSeason(int bettorId, int seasonId);
    }
}
