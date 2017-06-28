using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Tippspiel_Benutzerclient.ServiceReference;
using Tippspiel_Benutzerclient.Sources.Models;

namespace Tippspiel_Benutzerclient.Sources.Tools
{
    public class BetTools
    {
        public static List<SeasonBetEntry> GetBets(int bettorId)
        {
            var teams = Tools.TeamsOfSeason;
            var matches = Tools.MatchesOfMatchdayOfSeason;
            var bets = Tools.BetsOfMatchdayOfSeason.Values
                .Where(bet => bet.BettorId == bettorId)
                .ToDictionary(bet => bet.MatchId, bet => bet);//Matchid, Bet

            return matches.Values
                .OrderBy(match=> match.DateTime)
                .Select(match =>
                    {
                        var hometeamName = teams[match.HomeTeamId]?.Name;
                        var awayteamName = teams[match.AwayTeamId]?.Name;
                        var matchUpcoming = match.DateTime > DateTime.Now.AddMinutes(-30);
                        string hometeamScore;
                        int tempHometeamScore;
                        string awayteamScore;
                        int tempAwayteamScore;
                        var hometeamBet = "-";
                        var tempHometeamBet = -1;
                        var awayteamBet = "-";
                        var tempAwayteamBet = -1;
                        var betId = -1;

                        if (match.DateTime.AddMinutes(135) > DateTime.Now)
                        {
                            hometeamScore = "-";
                            tempHometeamScore = -1;
                            awayteamScore = "-";
                            tempAwayteamScore = -1;
                        }
                        else
                        {
                            hometeamScore = match.HomeTeamScore.ToString();
                            tempHometeamScore = match.HomeTeamScore;
                            awayteamScore = match.AwayTeamScore.ToString();
                            tempAwayteamScore = match.AwayTeamScore;
                        }

                        if (bets.ContainsKey(match.Id))
                        {
                            var bet = bets[match.Id];
                            hometeamBet =  bet.HomeTeamScore.ToString();
                            tempHometeamBet = bet.HomeTeamScore;
                            awayteamBet = bet.AwayTeamScore.ToString();
                            tempAwayteamBet = bet.AwayTeamScore;
                            betId = bet.Id;
                        }
                        return new SeasonBetEntry
                        {
                            BetId = betId,
                            MatchId = match.Id,
                            Hometeam = hometeamName,
                            Awayteam = awayteamName,
                            MatchUpcoming = matchUpcoming ? Visibility.Visible : Visibility.Hidden,
                            ButtonsHeight = matchUpcoming ? 55 : 0,
                            HometeamScore = hometeamScore,
                            AwayteamScore = awayteamScore,
                            HometeamBet = hometeamBet,
                            AwayteamBet = awayteamBet,
                            TempHometeamScore = tempHometeamScore,
                            TempAwayteamScore = tempAwayteamScore,
                            TempHometeamBet = tempHometeamBet,
                            TempAwayteamBet = tempAwayteamBet,
                            DateTime = match.DateTime.ToLongDateString()+" "+match.DateTime.ToShortTimeString()
                        };
                    }
                ).ToList();
        }

        public static bool IsMatchdayBettable()
        {
            var matches = Tools.MatchesOfMatchdayOfSeason;
            return matches.Any(match => match.Value.DateTime > DateTime.Now.AddMinutes(-30));
        }
    }
}