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
            Dictionary<int, TeamMessage> teams = Tools.TeamsOfSeason;
            Dictionary<int, MatchMessage> matches = Tools.MatchesOfMatchdayOfSeason;

            return Tools.BetsOfMatchdayOfSeason.Values
                .Where(bet => bet.BettorId.Equals(bettorId))
                .Select(bet =>
                    {
                        string hometeamName = "";
                        string awayteamName = "";
                        bool matchUpcoming = matches[bet.MatchId]?.DateTime > DateTime.Now.AddMinutes(-30);
                        string hometeamScore = "";
                        string awayteamScore = "";

                        if (matches.ContainsKey(bet.MatchId))
                        {
                            MatchMessage match = matches[bet.MatchId];
                            if (teams.ContainsKey(match.HomeTeamId))
                            {
                                hometeamName = teams[match.HomeTeamId].Name;
                            }
                            if (teams.ContainsKey(match.AwayTeamId))
                            {
                                awayteamName = teams[match.AwayTeamId].Name;
                            }
                            hometeamScore = matchUpcoming
                                ? bet.HomeTeamScore + ""
                                : match.HomeTeamScore + " (" + bet.HomeTeamScore + ")";
                            awayteamScore = matchUpcoming
                                ? bet.AwayTeamScore + ""
                                : match.AwayTeamScore + " (" + bet.AwayTeamScore + ")";
                        }
                        return new SeasonBetEntry
                        {
                            Hometeam = hometeamName,
                            Awayteam = awayteamName,
                            MatchUpcoming = matchUpcoming ? Visibility.Visible : Visibility.Hidden,
                            HometeamScore = hometeamScore,
                            AwayteamScore = awayteamScore,
                            DateTime = bet.DateTime.ToLongDateString()+" "+bet.DateTime.ToShortTimeString()
                        };
                    }
                ).ToList();
        }
    }
}