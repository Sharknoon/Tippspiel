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
                        string awayteamScore;
                        var hometeamBet = "-";
                        var awayteamBet = "-";

                        if (match.DateTime.AddMinutes(135) > DateTime.Now)
                        {
                            hometeamScore = "-";
                            awayteamScore = "-";
                        }
                        else
                        {
                            hometeamScore = match.HomeTeamScore.ToString();
                            awayteamScore = match.AwayTeamScore.ToString();
                        }

                        if (bets.ContainsKey(match.Id))
                        {
                            var bet = bets[match.Id];
                            hometeamBet =  bet.HomeTeamScore.ToString();
                            awayteamBet = bet.AwayTeamScore.ToString();
                        }
                        return new SeasonBetEntry
                        {
                            Hometeam = hometeamName,
                            Awayteam = awayteamName,
                            MatchUpcoming = matchUpcoming ? Visibility.Visible : Visibility.Hidden,
                            ButtonsHeight = matchUpcoming ? 55 : 0,
                            HometeamScore = hometeamScore,
                            AwayteamScore = awayteamScore,
                            HometeamBet = hometeamBet,
                            AwayteamBet = awayteamBet,
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