using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using FluentNHibernate.Conventions;
using NHibernate.Util;
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
            return new StringBuilder(Database.Database.PingString + " ").ToString();
        }

        public List<BetMessage> GetAllBets(int bettorId)
        {
            return Database.Database.Bets.GetAll()
                .Select(bet => new BetMessage()
                {
                    Id = bet.Id,
                    DateTime = bet.DateTime,
                    HomeTeamScore = bet.HomeTeamScore,
                    AwayTeamScore = bet.AwayTeamScore,
                    BettorId = bet.Bettor.Id,
                    MatchId = bet.Match.Id
                })
                .ToList();
            ;
        }

        public string CreateBet(BetMessage b)
        {
            Match originalMatch = Database.Database.Matches.GetById(b.MatchId);
            Bettor originalBettor = Database.Database.Bettors.GetById(b.BettorId);
            string validation = BetValidator.CreateBet(b.DateTime, b.HomeTeamScore, b.AwayTeamScore, originalMatch,
                originalBettor);
            if (validation.IsEmpty())
            {
                Database.Database.Bets.Save(new Bet()
                {
                    AwayTeamScore = b.AwayTeamScore,
                    Bettor = originalBettor,
                    DateTime = b.DateTime,
                    HomeTeamScore = b.HomeTeamScore,
                    Match = originalMatch
                });
            }
            return validation;
        }

        public string EditBet(BetMessage b)
        {
            Bet originalBet = Database.Database.Bets.GetById(b.Id);
            Match newMatch = Database.Database.Matches.GetById(b.MatchId);
            Bettor newBettor = Database.Database.Bettors.GetById(b.BettorId);
            string validation = BetValidator.EditBet(originalBet, b.DateTime, b.HomeTeamScore, b.AwayTeamScore,
                newMatch, newBettor);
            if (validation.IsEmpty())
            {
                originalBet.Match = newMatch;
                originalBet.AwayTeamScore = b.AwayTeamScore;
                originalBet.Bettor = newBettor;
                originalBet.DateTime = b.DateTime;
                originalBet.HomeTeamScore = b.HomeTeamScore;
                Database.Database.Bets.Update(originalBet);
            }
            return validation;
        }

        public string DeleteBet(BetMessage b)
        {
            Bet originalBet = Database.Database.Bets.GetById(b.Id);
            string validation = BetValidator.DeleteBet(originalBet);
            if (validation.IsEmpty())
            {
                Database.Database.Bets.Delete(originalBet);
            }
            return validation;
        }

        public List<BettorMessage> GetAllBettors()
        {
            return Database.Database.Bettors.GetAll()
                .Select(bettor => new BettorMessage()
                {
                    Nickname = bettor.Nickname,
                    Id = bettor.Id,
                    Firstname = bettor.Firstname,
                    Lastname = bettor.Lastname
                })
                .ToList();
        }

        public string CreateBettor(BettorMessage b)
        {
            string validation = BettorValidator.CreateBettor(b.Nickname, b.Firstname, b.Lastname);
            if (validation.IsEmpty())
            {
                Database.Database.Bettors.Save(new Bettor()
                {
                    Firstname = b.Firstname,
                    Lastname = b.Lastname,
                    Nickname = b.Nickname
                });
            }
            return validation;
        }

        public string EditBettor(BettorMessage b)
        {
            Bettor originalBettor = Database.Database.Bettors.GetById(b.Id);
            string validation = BettorValidator.EditBettor(originalBettor, b.Nickname, b.Firstname, b.Lastname);
            if (validation.IsEmpty())
            {
                originalBettor.Firstname = b.Firstname;
                originalBettor.Lastname = b.Lastname;
                originalBettor.Nickname = b.Nickname;
                Database.Database.Bettors.Update(originalBettor);
            }
            return validation;
        }

        public string DeleteBettor(BettorMessage b)
        {
            Bettor originalBettor = Database.Database.Bettors.GetById(b.Id);
            string validation = BettorValidator.DeleteBettor(originalBettor);
            if (validation.IsEmpty())
            {
                Database.Database.Bettors.Delete(originalBettor);
            }
            return validation;
        }

        public List<MatchMessage> GetAllMatches()
        {
            return Database.Database.Matches.GetAll()
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
                })
                .ToList();
            ;
        }

        public List<MatchMessage> GetAllMatchesForMatchDayInSeason(int seasonId, int matchDay)
        {
            return Database.Database.Matches.GetByPropertyCaseSensitive("MatchDay", matchDay)
                .Where(match => match.Season.Id.Equals(seasonId))
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
                })
                .ToList();
        }

        public string CreateMatch(MatchMessage m)
        {
            Team originalHomeTeam = Database.Database.Teams.GetById(m.HomeTeamId);
            Team originalAwayTeam = Database.Database.Teams.GetById(m.AwayTeamId);
            Season originalSeason = Database.Database.Seasons.GetById(m.SeasonId);
            string validation = MatchValidator.CreateMatch(m.MatchDay, m.DateTime, originalHomeTeam, originalAwayTeam,
                originalSeason);
            if (validation.IsEmpty())
            {
                Database.Database.Matches.Save(new Match()
                {
                    AwayTeam = originalAwayTeam,
                    AwayTeamScore = m.AwayTeamScore,
                    DateTime = m.DateTime,
                    Season = originalSeason,
                    HomeTeam = originalHomeTeam,
                    HomeTeamScore = m.HomeTeamScore,
                    MatchDay = m.MatchDay
                });
            }
            return validation;
        }

        public string EditMatch(MatchMessage m)
        {
            Match originalMatch = Database.Database.Matches.GetById(m.Id);
            Team newHomeTeam = Database.Database.Teams.GetById(m.HomeTeamId);
            Team newAwayTeam = Database.Database.Teams.GetById(m.AwayTeamId);
            Season newSeason = Database.Database.Seasons.GetById(m.SeasonId);
            string validation = MatchValidator.EditMatch(originalMatch, m.MatchDay, m.DateTime, newHomeTeam,
                newAwayTeam, newSeason);
            if (validation.IsEmpty())
            {
                originalMatch.Season = newSeason;
                originalMatch.AwayTeam = newAwayTeam;
                originalMatch.AwayTeamScore = m.AwayTeamScore;
                originalMatch.HomeTeam = newHomeTeam;
                originalMatch.HomeTeamScore = m.HomeTeamScore;
                originalMatch.DateTime = m.DateTime;
                originalMatch.MatchDay = m.MatchDay;
                Database.Database.Matches.Update(originalMatch);
            }
            return validation;
        }

        public string DeleteMatch(MatchMessage m)
        {
            Match originalMatch = Database.Database.Matches.GetById(m.Id);
            string validation = MatchValidator.DeleteMatch(originalMatch);
            if (validation.IsEmpty())
            {
                Database.Database.Matches.Delete(originalMatch);
            }
            return validation;
        }

        public List<SeasonMessage> GetAllSeasons()
        {
            return Database.Database.Seasons.GetAll()
                .Select(season => new SeasonMessage()
                {
                    Id = season.Id,
                    Name = season.Name,
                    Sequence = season.Sequence,
                    Description = season.Description,
                    TeamIds = season.Teams.Select(team => team.Id).ToList()
                })
                .ToList();
        }

        public string CreateSeason(SeasonMessage s)
        {
            string validation = SeasonValidator.CreateSeason(s.Name, s.Description, s.Sequence);
            if (validation.IsEmpty())
            {
                Database.Database.Seasons.Save(new Season()
                {
                    Description = s.Description,
                    Name = s.Name,
                    Sequence = s.Sequence,
                    Teams = new List<Team>()
                });
            }
            return validation;
        }

        public string EditSeason(SeasonMessage s)
        {
            Season originalSeason = Database.Database.Seasons.GetById(s.Id);
            string validation = SeasonValidator.EditSeason(originalSeason, s.Name, s.Description,
                s.Sequence);
            if (validation.IsEmpty())
            {
                originalSeason.Description = s.Description;
                originalSeason.Name = s.Name;
                originalSeason.Sequence = s.Sequence;

                Database.Database.Seasons.Update(originalSeason);
            }
            return validation;
        }

        public string DeleteSeason(SeasonMessage s)
        {
            Season originalSeason = Database.Database.Seasons.GetById(s.Id);
            string validation = SeasonValidator.DeleteSeason(originalSeason);
            if (validation.IsEmpty())
            {
                Database.Database.Seasons.Delete(originalSeason);
            }
            return validation;
        }

        public List<TeamMessage> GetAllTeams()
        {
            return Database.Database.Teams.GetAll()
                .Select(team => new TeamMessage()
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                })
                .ToList();
        }

        public string CreateTeam(TeamMessage t)
        {
            string validation = TeamValidator.CreateTeam(t.Name);
            if (validation.IsEmpty())
            {
                Database.Database.Teams.Save(new Team()
                {
                    Name = t.Name,
                    Seasons = t.SeasonIDs.Select(Id => Database.Database.Seasons.GetById(Id)).ToList()
                });
            }
            return validation;
        }

        public string EditTeam(TeamMessage t)
        {
            Team originalTeam = Database.Database.Teams.GetById(t.Id);
            string validation = TeamValidator.EditTeam(originalTeam, t.Name, t.SeasonIDs);
            if (validation.IsEmpty())
            {
                originalTeam.Name = t.Name;
                originalTeam.Seasons.Clear();
                foreach (var teamSeasonID in t.SeasonIDs)
                {
                    originalTeam.Seasons.Add(Database.Database.Seasons.GetById(teamSeasonID));
                }

                Database.Database.Teams.Update(originalTeam);
            }
            return validation;
        }

        public string DeleteTeam(TeamMessage t)
        {
            Team originalTeam = Database.Database.Teams.GetById(t.Id);
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

        public List<TeamMessage> GetTeamByName(string name)
        {
            Team team = Database.Database.Teams.GetByPropertyIgnoreCase("Name", name).FirstOrDefault();
            if (team != null)
            {
                TeamMessage teamm = new TeamMessage()
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                };
                return new List<TeamMessage>() {teamm};
            }
            return new List<TeamMessage>();
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

        public List<MatchMessage> GetMatchesForSeason(SeasonMessage season)
        {
            return Database.Database.Matches.GetAll()
                .Where(match => match.Season.Id.Equals(season.Id))
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

        public string CreateMatches(List<MatchMessage> matches)
        {
            var teams = Database.Database.Teams.GetAll().ToDictionary(team => team.Id, team => team);
            var seasons = Database.Database.Seasons.GetAll()
                .ToDictionary(season => season.Id, season => season);

            var validations = "";
            foreach (var match in matches)
            {
                validations = validations + MatchValidator.CreateMatch(match.MatchDay, match.DateTime,
                                  teams[match.HomeTeamId], teams[match.AwayTeamId], seasons[match.SeasonId]);
            }
            if (validations.IsEmpty())
            {
                Database.Database.Matches.Save(matches.Select(match => new Match()
                {
                    AwayTeam = teams[match.AwayTeamId],
                    AwayTeamScore = match.AwayTeamScore,
                    DateTime = match.DateTime,
                    Season = seasons[match.SeasonId],
                    HomeTeam = teams[match.HomeTeamId],
                    HomeTeamScore = match.HomeTeamScore,
                    MatchDay = match.MatchDay
                }).ToList());
            }
            return validations;
        }

        public List<BettorMessage> LoginBettor(string username)
        {
            var bettors = Database.Database.Bettors.GetByPropertyIgnoreCase("Nickname", username);
            var bettor = bettors.FirstOrDefault();
            if (bettor == null) return new List<BettorMessage>();
            return new List<BettorMessage>()
            {
                new BettorMessage()
                {
                    Firstname = bettor.Firstname,
                    Lastname = bettor.Lastname,
                    Nickname = bettor.Nickname
                }
            };
        }

        public List<TeamMessage> GetAllTeamsForSeason(int seasonId)
        {
            return Database.Database.Teams.GetAll()
                .Where(team => team.Seasons.Any(season => season.Id.Equals(seasonId))).Select(team => new TeamMessage()
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                }).ToList();
        }

        public List<MatchMessage> GetAllMatchesForSeason(int seasonId)
        {
            return Database.Database.Matches.GetAll().FindAll(match => match.Season.Id.Equals(seasonId)).Select(match => new MatchMessage()
            {
                Id = match.Id,
                MatchDay = match.MatchDay,
                DateTime = match.DateTime,
                AwayTeamScore = match.AwayTeamScore,
                HomeTeamScore = match.HomeTeamScore,
                SeasonId = match.Season.Id,
                AwayTeamId = match.AwayTeam.Id,
                HomeTeamId = match.HomeTeam.Id
            }).ToList();
        }

        public List<BetMessage> GetAllBetsForSeason(int seasonId)
        {
            return Database.Database.Bets.GetAll().FindAll(bet => bet.Match.Season.Id.Equals(seasonId))
                .Select(bet => new BetMessage()
                {
                    Id = bet.Id,
                    DateTime = bet.DateTime,
                    HomeTeamScore = bet.HomeTeamScore,
                    AwayTeamScore = bet.AwayTeamScore,
                    BettorId = bet.Bettor.Id,
                    MatchId = bet.Match.Id
                }).ToList();
        }
    }
}
