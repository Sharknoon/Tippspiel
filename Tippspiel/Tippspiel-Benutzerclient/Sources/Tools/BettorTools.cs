using System;
using System.Collections.Generic;
using System.Linq;
using Tippspiel_Benutzerclient.ServiceReference;
using Tippspiel_Benutzerclient.Sources.Models;

namespace Tippspiel_Benutzerclient.Sources.Tools
{
    public class BettorTools
    {
        public static List<SeasonBettorEntry> GetBettors()
        {


            //General bettorentry setup
            Dictionary<int, SeasonBettorEntry> bettorEntries = Tools.Bettors.Values.ToDictionary(bettor => bettor.Id,
                bettor => new SeasonBettorEntry
                {
                    Name = bettor.Firstname+" "+bettor.Lastname,
                    Nickname = bettor.Nickname
                });
            //Fill in the points of the bettors
            foreach (var bet in Tools.BetsOfMatchdayOfSeason.Values)
            {
                if (!bettorEntries.ContainsKey(bet.BettorId)) continue;
                if (!Tools.MatchesOfMatchdayOfSeason.ContainsKey(bet.MatchId)) continue;
                var matchOfBet = Tools.MatchesOfMatchdayOfSeason[bet.MatchId];
                if (matchOfBet.HomeTeamScore.Equals(bet.HomeTeamScore) &&
                    matchOfBet.AwayTeamScore.Equals(bet.AwayTeamScore))
                {
                    bettorEntries[bet.BettorId].TempPoints += 4;
                }
                else
                {
                    if (matchOfBet.HomeTeamScore.Equals(matchOfBet.AwayTeamScore)) //Draw
                    {
                        if (bet.HomeTeamScore.Equals(bet.AwayTeamScore))
                        {
                            bettorEntries[bet.BettorId].TempPoints += 3;
                        }
                        //No Goal difference at a draw
                    }
                    else //Win or Loose
                    {
                        var realWinner = matchOfBet.HomeTeamScore > matchOfBet.AwayTeamScore
                            ? matchOfBet.HomeTeamId
                            : matchOfBet.AwayTeamId;
                        var suggestedWinner = bet.HomeTeamScore > bet.AwayTeamScore
                            ? matchOfBet.HomeTeamId
                            : matchOfBet.AwayTeamId;
                        var realGoalDifference = matchOfBet.HomeTeamScore - matchOfBet.AwayTeamScore;
                        if (realGoalDifference < 0)
                        {
                            realGoalDifference *= -1;
                        }
                        var suggestedGoalDifference = bet.HomeTeamScore - bet.AwayTeamScore;
                        if (suggestedGoalDifference < 0)
                        {
                            suggestedGoalDifference *= -1;
                        }

                        if (suggestedGoalDifference.Equals(realGoalDifference) && suggestedWinner.Equals(realWinner))
                        {
                            bettorEntries[bet.BettorId].TempPoints += 3;
                        }
                        else if (suggestedWinner.Equals(realWinner))
                        {
                            bettorEntries[bet.BettorId].TempPoints += 2;
                        }
                    }
                }
            }
            List<SeasonBettorEntry> values = bettorEntries.Values.ToList();
            values.Sort((e1, e2) => e2.TempPoints.CompareTo(e1.TempPoints));
            for (var i = 1; i <= values.Count; i++)
            {
                values[i - 1].Placement = i;
                if (values[i - 1].TempPoints != 1)
                {
                    values[i - 1].Points = values[i - 1].TempPoints + " Punkte";
                }
                else
                {
                    values[i - 1].Points = values[i - 1].TempPoints + " Punkt";
                }
            }
            return values;
        }
    }
}