using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using FluentNHibernate.Conventions;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
using Tippspiel_Server.Sources.Utils;
using Tippspiel_Server.Sources.Validators;
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
            return Database.Database.Bets.GetAll().Select(bet => new BetMessage()
                {
                    Id = bet.Id,
                    DateTime = bet.DateTime,
                    HomeTeamScore = bet.HomeTeamScore,
                    AwayTeamScore = bet.AwayTeamScore,
                    BettorId = bet.Bettor.Id,
                    MatchId = bet.Match.Id
                })
                .ToList(); ;
        }

        public string CreateBet(BetMessage bet)
        {
            throw new NotImplementedException();
        }

        public string EditBet(BetMessage bet)
        {
            throw new NotImplementedException();
        }

        public string DeleteBet(int betId)
        {
            throw new NotImplementedException();
        }

        public List<BettorMessage> GetAllBettors()
        {
            return Database.Database.Bettors.GetAll().Select(bettor => new BettorMessage()
                {
                    Nickname = bettor.Nickname,
                    Id = bettor.Id,
                    Firstname = bettor.Firstname,
                    Lastname = bettor.Lastname
                })
                .ToList();
        }

        public string CreateBettor(string nickname, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public string EditBettor(int bettorId, string nickname, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public string DeleteBettor(int bettorId)
        {
            throw new NotImplementedException();
        }

        public List<MatchMessage> GetAllMatches()
        {
            return Database.Database.Matches.GetAll().Select(match => new MatchMessage()
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
                .ToList(); ;
        }

        public List<MatchMessage> GetAllMatchesForMatchDay(int matchDay)
        {
            return Database.Database.Matches.GetByPropertyCaseSensitive("MatchDay", matchDay)
                .Select(match => new MatchMessage()
                {
                    MatchDay = match.MatchDay,
                    Id = match.Id,
                    DateTime = match.DateTime,
                    AwayTeamScore = match.AwayTeamScore,
                    HomeTeamScore = match.HomeTeamScore,
                    AwayTeamId = match.AwayTeam.Id,
                    HomeTeamId = match.HomeTeam.Id,
                    SeasonId = match.Season.Id
                }).ToList();
        }

        public string CreateMatch(int matchDay, DateTime dateTime, int homeTeamId, int awayTeamId, int seasonId)
        {
            throw new NotImplementedException();
        }

        public string EditMatch(int matchId, int matchDay, DateTime dateTime, int homeTeamId, int awayTeamId,
            Season season)
        {
            throw new NotImplementedException();
        }

        public string DeleteMatch(int matchId)
        {
            throw new NotImplementedException();
        }

        public List<SeasonMessage> GetAllSeasons()
        {
            return Database.Database.Seasons.GetAll().Select(season => new SeasonMessage()
                {
                    Id = season.Id,
                    Name = season.Name,
                    Sequence = season.Sequence,
                    Description = season.Description,
                    TeamIds = season.Teams.Select(team => team.Id).ToList()
                })
                .ToList();
        }

        public string CreateSeason(SeasonMessage season)
        {
            string validation = SeasonValidator.CreateSeason(season.Name, season.Description, season.Sequence);
            if (validation.IsEmpty())
            {
                Database.Database.Seasons.Save(new Season()
                {
                    Description = season.Description,
                    Name = season.Name,
                    Sequence = season.Sequence,
                    Teams = new List<Team>()
                });
            }
            return validation;
        }

        public string EditSeason(SeasonMessage season)
        {
            Season originalSeason = Database.Database.Seasons.GetById(season.Id);
            string validation = SeasonValidator.EditSeason(originalSeason, season.Name, season.Description,
                season.Sequence);
            if (validation.IsEmpty())
            {
                originalSeason.Description = season.Description;
                originalSeason.Name = season.Name;
                originalSeason.Sequence = season.Sequence;

                Database.Database.Seasons.Update(originalSeason);
            }
            return validation;
        }

        public string DeleteSeason(SeasonMessage season)
        {
            Season originalSeason = Database.Database.Seasons.GetById(season.Id);
            string validation = SeasonValidator.DeleteSeason(originalSeason);
            if (validation.IsEmpty())
            {
                Database.Database.Seasons.Delete(originalSeason);
            }
            return validation;
        }

        public List<TeamMessage> GetAllTeams()
        {
            return Database.Database.Teams.GetAll().Select(team => new TeamMessage()
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                })
                .ToList();
        }

        public string CreateTeam(TeamMessage team)
        {
            string validation = TeamValidator.CreateTeam(team.Name);
            if (validation.IsEmpty())
            {
                Database.Database.Teams.Save(new Team()
                {
                    Name = team.Name,
                    Seasons = team.SeasonIDs.Select(Id => Database.Database.Seasons.GetById(Id)).ToList()
                });
            }
            return validation;
        }

        public string EditTeam(TeamMessage team)
        {
            Team originalTeam = Database.Database.Teams.GetById(team.Id);
            string validation = TeamValidator.EditTeam(originalTeam, team.Name, team.SeasonIDs);
            if (validation.IsEmpty())
            {
                originalTeam.Name = team.Name;
                originalTeam.Seasons.Clear();
                foreach (var teamSeasonID in team.SeasonIDs)
                {
                    originalTeam.Seasons.Add(Database.Database.Seasons.GetById(teamSeasonID));
                }
                
                Database.Database.Teams.Update(originalTeam);
            }
            return validation;
        }

        public string DeleteTeam(TeamMessage team)
        {
            Team originalTeam = Database.Database.Teams.GetById(team.Id);
            string validation = TeamValidator.DeleteTeam(originalTeam);
            if (validation.IsEmpty())
            {
                Database.Database.Teams.Delete(originalTeam);
            }
            return validation;
        }

        public List<SeasonMessage> GetSeasonsById(List<int> seasonIds)
        {
            return seasonIds.Select(seasonId => Database.Database.Seasons.GetById(seasonId))
                .Select(season => new SeasonMessage()
                {
                    Description = season.Description,
                    Id = season.Id,
                    Name = season.Name,
                    Sequence = season.Sequence,
                    TeamIds = season.Teams.Select(team => team.Id).ToList()
                })
                .ToList();
        }

        public List<TeamMessage> GetTeamsById(List<int> teamIds)
        {
            return teamIds.Select(teamId => Database.Database.Teams.GetById(teamId))
                .Select(team => new TeamMessage()
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                })
                .ToList();
        }

        public List<MatchMessage> GetMatchesById(List<int> matchIds)
        {
            return matchIds.Select(matchId => Database.Database.Matches.GetById(matchId))
                .Select(match => new MatchMessage()
                {
                    Id = match.Id,
                    MatchDay = match.MatchDay,
                    DateTime = match.DateTime,
                    AwayTeamScore = match.AwayTeamScore,
                    HomeTeamScore = match.HomeTeamScore,
                    SeasonId = match.Season.Id,
                    AwayTeamId = match.AwayTeam.Id,
                    HomeTeamId = match.HomeTeam.Id
                })
                .ToList();
        }
    }
}
