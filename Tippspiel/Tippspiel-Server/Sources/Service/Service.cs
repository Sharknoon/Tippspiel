using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using FluentNHibernate.Conventions;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
using Tippspiel_Server.Sources.Validators;

namespace Tippspiel_Server.Sources.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in both code and config file together.
    public class Service : IService
    {
        private static ServiceHost _service;

        public string Ping()
        {
            return new StringBuilder(Database.Database.PingString + " ").ToString();
        }

        public List<BetMessage> GetAllBets(int bettorId)
        {
            return Database.Database.Bets.GetAll()
                .Select(bet => new BetMessage
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

        public string CreateBet(BetMessage b)
        {
            var originalMatch = Database.Database.Matches.GetById(b.MatchId);
            var originalBettor = Database.Database.Bettors.GetById(b.BettorId);
            var validation = BetValidator.CreateBet(b.DateTime, b.HomeTeamScore, b.AwayTeamScore, originalMatch,
                originalBettor);
            if (validation.IsEmpty())
                Database.Database.Bets.Save(new Bet
                {
                    AwayTeamScore = b.AwayTeamScore,
                    Bettor = originalBettor,
                    DateTime = b.DateTime,
                    HomeTeamScore = b.HomeTeamScore,
                    Match = originalMatch
                });
            return validation;
        }

        public string EditBet(BetMessage b)
        {
            var originalBet = Database.Database.Bets.GetById(b.Id);
            var newMatch = Database.Database.Matches.GetById(b.MatchId);
            var newBettor = Database.Database.Bettors.GetById(b.BettorId);
            var validation = BetValidator.EditBet(originalBet, b.DateTime, b.HomeTeamScore, b.AwayTeamScore,
                newMatch, newBettor);
            if (!validation.IsEmpty()) return validation;
            originalBet.Match = newMatch;
            originalBet.AwayTeamScore = b.AwayTeamScore;
            originalBet.Bettor = newBettor;
            originalBet.DateTime = b.DateTime;
            originalBet.HomeTeamScore = b.HomeTeamScore;
            Database.Database.Bets.Update(originalBet);
            return validation;
        }

        public string DeleteBet(BetMessage b)
        {
            var originalBet = Database.Database.Bets.GetById(b.Id);
            var validation = BetValidator.DeleteBet(originalBet);
            if (validation.IsEmpty())
                Database.Database.Bets.Delete(originalBet);
            return validation;
        }

        public List<BettorMessage> GetAllBettors()
        {
            return Database.Database.Bettors.GetAll()
                .Select(bettor => new BettorMessage
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
            var validation = BettorValidator.CreateBettor(b.Nickname, b.Firstname, b.Lastname);
            if (validation.IsEmpty())
                Database.Database.Bettors.Save(new Bettor
                {
                    Firstname = b.Firstname,
                    Lastname = b.Lastname,
                    Nickname = b.Nickname
                });
            return validation;
        }

        public string EditBettor(BettorMessage b)
        {
            var originalBettor = Database.Database.Bettors.GetById(b.Id);
            var validation = BettorValidator.EditBettor(originalBettor, b.Nickname, b.Firstname, b.Lastname);
            if (!validation.IsEmpty()) return validation;
            originalBettor.Firstname = b.Firstname;
            originalBettor.Lastname = b.Lastname;
            originalBettor.Nickname = b.Nickname;
            Database.Database.Bettors.Update(originalBettor);
            return validation;
        }

        public string DeleteBettor(BettorMessage b)
        {
            var originalBettor = Database.Database.Bettors.GetById(b.Id);
            var validation = BettorValidator.DeleteBettor(originalBettor);
            if (validation.IsEmpty())
                Database.Database.Bettors.Delete(originalBettor);
            return validation;
        }

        public List<MatchMessage> GetAllMatches()
        {
            return Database.Database.Matches.GetAll()
                .Select(match => new MatchMessage
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

        public List<MatchMessage> GetAllMatchesForMatchDayInSeason(int seasonId, int matchDay)
        {
            return Database.Database.Matches.GetByExpressionOnReference(match => match.MatchDay == matchDay,
                    match => match.Season, season => season.Id == seasonId)
                .Select(match => new MatchMessage
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
            var originalHomeTeam = Database.Database.Teams.GetById(m.HomeTeamId);
            var originalAwayTeam = Database.Database.Teams.GetById(m.AwayTeamId);
            var originalSeason = Database.Database.Seasons.GetById(m.SeasonId);
            var validation = MatchValidator.CreateMatch(m.MatchDay, m.DateTime, originalHomeTeam, originalAwayTeam,
                originalSeason);
            if (validation.IsEmpty())
                Database.Database.Matches.Save(new Match
                {
                    AwayTeam = originalAwayTeam,
                    AwayTeamScore = m.AwayTeamScore,
                    DateTime = m.DateTime,
                    Season = originalSeason,
                    HomeTeam = originalHomeTeam,
                    HomeTeamScore = m.HomeTeamScore,
                    MatchDay = m.MatchDay
                });
            return validation;
        }

        public string EditMatch(MatchMessage m)
        {
            var originalMatch = Database.Database.Matches.GetById(m.Id);
            var newHomeTeam = Database.Database.Teams.GetById(m.HomeTeamId);
            var newAwayTeam = Database.Database.Teams.GetById(m.AwayTeamId);
            var newSeason = Database.Database.Seasons.GetById(m.SeasonId);
            var validation = MatchValidator.EditMatch(originalMatch, m.MatchDay, m.DateTime, newHomeTeam,
                newAwayTeam, newSeason);
            if (!validation.IsEmpty()) return validation;
            originalMatch.Season = newSeason;
            originalMatch.AwayTeam = newAwayTeam;
            originalMatch.AwayTeamScore = m.AwayTeamScore;
            originalMatch.HomeTeam = newHomeTeam;
            originalMatch.HomeTeamScore = m.HomeTeamScore;
            originalMatch.DateTime = m.DateTime;
            originalMatch.MatchDay = m.MatchDay;
            Database.Database.Matches.Update(originalMatch);
            return validation;
        }

        public string DeleteMatch(MatchMessage m)
        {
            var originalMatch = Database.Database.Matches.GetById(m.Id);
            var validation = MatchValidator.DeleteMatch(originalMatch);
            if (validation.IsEmpty())
                Database.Database.Matches.Delete(originalMatch);
            return validation;
        }

        public List<SeasonMessage> GetAllSeasons()
        {
            return Database.Database.Seasons.GetAll()
                .Select(season => new SeasonMessage
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
            var validation = SeasonValidator.CreateSeason(s.Name, s.Description, s.Sequence);
            if (validation.IsEmpty())
                Database.Database.Seasons.Save(new Season
                {
                    Description = s.Description,
                    Name = s.Name,
                    Sequence = s.Sequence,
                    Teams = new List<Team>()
                });
            return validation;
        }

        public string EditSeason(SeasonMessage s)
        {
            var originalSeason = Database.Database.Seasons.GetById(s.Id);
            var validation = SeasonValidator.EditSeason(originalSeason, s.Name, s.Description,
                s.Sequence);
            if (!validation.IsEmpty()) return validation;
            originalSeason.Description = s.Description;
            originalSeason.Name = s.Name;
            originalSeason.Sequence = s.Sequence;

            Database.Database.Seasons.Update(originalSeason);
            return validation;
        }

        public string DeleteSeason(SeasonMessage s)
        {
            var originalSeason = Database.Database.Seasons.GetById(s.Id);
            var validation = SeasonValidator.DeleteSeason(originalSeason);
            if (validation.IsEmpty())
                Database.Database.Seasons.Delete(originalSeason);
            return validation;
        }

        public List<TeamMessage> GetAllTeams()
        {
            return Database.Database.Teams.GetAll()
                .Select(team => new TeamMessage
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                })
                .ToList();
        }

        public string CreateTeam(TeamMessage t)
        {
            var validation = TeamValidator.CreateTeam(t.Name);
            if (validation.IsEmpty())
                Database.Database.Teams.Save(new Team
                {
                    Name = t.Name,
                    Seasons = t.SeasonIDs.Select(id => Database.Database.Seasons.GetById(id)).ToList()
                });
            return validation;
        }

        public string EditTeam(TeamMessage t)
        {
            var originalTeam = Database.Database.Teams.GetById(t.Id);
            var validation = TeamValidator.EditTeam(originalTeam, t.Name, t.SeasonIDs);
            if (!validation.IsEmpty()) return validation;
            originalTeam.Name = t.Name;
            originalTeam.Seasons.Clear();
            foreach (var teamSeasonId in t.SeasonIDs)
                originalTeam.Seasons.Add(Database.Database.Seasons.GetById(teamSeasonId));

            Database.Database.Teams.Update(originalTeam);
            return validation;
        }

        public string DeleteTeam(TeamMessage t)
        {
            var originalTeam = Database.Database.Teams.GetById(t.Id);
            var validation = TeamValidator.DeleteTeam(originalTeam);
            if (validation.IsEmpty())
                Database.Database.Teams.Delete(originalTeam);
            return validation;
        }

        public List<SeasonMessage> GetSeasonsById(List<int> seasonIds)
        {
            return seasonIds.Select(seasonId => Database.Database.Seasons.GetById(seasonId))
                .Select(season => new SeasonMessage
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
                .Select(team => new TeamMessage
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                })
                .ToList();
        }

        public List<TeamMessage> GetTeamByName(string name)
        {
            var team = Database.Database.Teams.GetByExpression(t => t.Name == name).FirstOrDefault();
            if (team == null) return new List<TeamMessage>();
            var teamm = new TeamMessage
            {
                Id = team.Id,
                Name = team.Name,
                SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
            };
            return new List<TeamMessage> {teamm};
        }

        public List<MatchMessage> GetMatchesById(List<int> matchIds)
        {
            return Database.Database.Matches.GetByExpression(match => matchIds.Contains(match.Id))
                .Select(match => new MatchMessage
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
            return Database.Database.Matches.GetByExpressionOnReference(match => match.Season, s => s.Id == season.Id)
                .Select(match => new MatchMessage
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

            var validations = matches.Aggregate("",
                (current, match) => current + MatchValidator.CreateMatch(match.MatchDay, match.DateTime,
                                        teams[match.HomeTeamId], teams[match.AwayTeamId], seasons[match.SeasonId]));
            if (validations.IsEmpty())
                Database.Database.Matches.Save(matches.Select(match => new Match
                {
                    AwayTeam = teams[match.AwayTeamId],
                    AwayTeamScore = match.AwayTeamScore,
                    DateTime = match.DateTime,
                    Season = seasons[match.SeasonId],
                    HomeTeam = teams[match.HomeTeamId],
                    HomeTeamScore = match.HomeTeamScore,
                    MatchDay = match.MatchDay
                }).ToList());
            return validations;
        }

        public List<TeamMessage> GetAllTeamsForSeason(int seasonId)
        {
            return Database.Database.Teams
                .GetByExpressionOnReference(team => team.Seasons, season => season.Id == seasonId)
                .Select(team => new TeamMessage
                {
                    Id = team.Id,
                    Name = team.Name,
                    SeasonIDs = team.Seasons.Select(season => season.Id).ToList()
                }).ToList();
        }

        public List<MatchMessage> GetAllMatchesForSeason(int seasonId)
        {
            return Database.Database.Matches
                .GetByExpressionOnReference(match => match.Season, season => season.Id == seasonId)
                .Select(match => new MatchMessage
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
            return Database.Database.Bets
                .GetByExpressionOnReference(bet => bet.Match, match => match.Season.Id == seasonId)
                .Select(bet => new BetMessage
                {
                    Id = bet.Id,
                    DateTime = bet.DateTime,
                    HomeTeamScore = bet.HomeTeamScore,
                    AwayTeamScore = bet.AwayTeamScore,
                    BettorId = bet.Bettor.Id,
                    MatchId = bet.Match.Id
                }).ToList();
        }

        //Only from one bettor allowed
        public string UpdateOrCreateBetsForSeason(int seasonId, List<BetMessage> bets)
        {
            if (bets.IsEmpty()) return "";
            var matchesOfSeason =
                Database.Database.Matches.GetByExpressionOnReference(match => match.Season,
                    season => season.Id == seasonId).ToDictionary(match => match.Id, match => match);
            var originalBettor = Database.Database.Bettors.GetById(bets[0].BettorId);

            var betsToSave = new List<Bet>();
            foreach (var bet in bets)
                betsToSave.Add(new Bet
                {
                    AwayTeamScore = bet.AwayTeamScore,
                    Bettor = originalBettor,
                    DateTime = bet.DateTime,
                    HomeTeamScore = bet.HomeTeamScore,
                    Match = matchesOfSeason[bet.MatchId]
                });
            Database.Database.Bets.Save(betsToSave);
            return "";
        }

        public static void InitializeService()
        {
            _service = new ServiceHost(typeof(Service));
            _service.Open();
        }

        public static void ShutdownService()
        {
            if (_service != null && _service.State.Equals(CommunicationState.Opened))
                _service.Close();
        }
    }
}