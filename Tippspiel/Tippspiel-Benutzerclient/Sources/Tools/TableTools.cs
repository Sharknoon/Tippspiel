using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Tippspiel_Benutzerclient.Sources.Models;
using static System.String;

namespace Tippspiel_Benutzerclient.Sources.Tools
{
    public class TableTools
    {
        public static List<SeasonTableEntry> GetTable()
        {
            var table = new Dictionary<int, SeasonTableEntry>(); //TeamId, TableEntry


            foreach (var matchOfSeason in Tools.MatchesOfSeasonUntilMatchday.Values)
            {
                //Teamname
                if (!table.ContainsKey(matchOfSeason.HomeTeamId))
                    table.Add(matchOfSeason.HomeTeamId, new SeasonTableEntry
                    {
                        Teamname = Tools.TeamsOfSeason[matchOfSeason.HomeTeamId]?.Name
                    });
                if (!table.ContainsKey(matchOfSeason.AwayTeamId))
                    table.Add(matchOfSeason.AwayTeamId, new SeasonTableEntry
                    {
                        Teamname = Tools.TeamsOfSeason[matchOfSeason.AwayTeamId]?.Name
                    });
                if (matchOfSeason.DateTime >= DateTime.Now) continue;
                //Amount Matches
                table[matchOfSeason.HomeTeamId].AmountMatches++;
                table[matchOfSeason.AwayTeamId].AmountMatches++;
                //Amount Wons, Draws, Looses, Point
                var homeTeam = matchOfSeason.HomeTeamScore - matchOfSeason.AwayTeamScore;
                if (homeTeam > 0) //HomeTeam has won
                {
                    table[matchOfSeason.HomeTeamId].AmountWon++;
                    table[matchOfSeason.HomeTeamId].TempGoalDifference += homeTeam;
                    table[matchOfSeason.HomeTeamId].TempPoints += 3;
                    table[matchOfSeason.AwayTeamId].AmountLost++;
                    table[matchOfSeason.AwayTeamId].TempGoalDifference -= homeTeam;
                }
                else if (homeTeam < 0) //HomeTeam has lost
                {
                    table[matchOfSeason.AwayTeamId].AmountWon++;
                    table[matchOfSeason.AwayTeamId].TempGoalDifference -= homeTeam;
                    table[matchOfSeason.AwayTeamId].TempPoints += 3;
                    table[matchOfSeason.HomeTeamId].AmountLost++;
                    table[matchOfSeason.HomeTeamId].TempGoalDifference += homeTeam;
                }
                else //Draw
                {
                    table[matchOfSeason.HomeTeamId].AmountDraw++;
                    table[matchOfSeason.HomeTeamId].TempPoints++;
                    table[matchOfSeason.AwayTeamId].AmountDraw++;
                    table[matchOfSeason.AwayTeamId].TempPoints++;
                }

                if (table[matchOfSeason.HomeTeamId].TempGoalDifference < 0)
                {
                    table[matchOfSeason.HomeTeamId].GoalDifference = "- " +
                                                                     table[matchOfSeason.HomeTeamId]
                                                                         .TempGoalDifference * -1;
                    if (table[matchOfSeason.HomeTeamId].TempGoalDifference == -1)
                        table[matchOfSeason.HomeTeamId].GoalDifference += " Tor";
                    else
                        table[matchOfSeason.HomeTeamId].GoalDifference += " Tore";
                }
                else
                {
                    table[matchOfSeason.HomeTeamId].GoalDifference = "+ " +
                                                                     table[matchOfSeason.HomeTeamId].TempGoalDifference;
                    if (table[matchOfSeason.HomeTeamId].TempGoalDifference == 1)
                        table[matchOfSeason.HomeTeamId].GoalDifference += " Tor";
                    else
                        table[matchOfSeason.HomeTeamId].GoalDifference += " Tore";
                }

                if (table[matchOfSeason.AwayTeamId].TempGoalDifference < 0)
                {
                    table[matchOfSeason.AwayTeamId].GoalDifference = "- " +
                                                                     table[matchOfSeason.AwayTeamId]
                                                                         .TempGoalDifference * -1;
                    if (table[matchOfSeason.AwayTeamId].TempGoalDifference == -1)
                        table[matchOfSeason.AwayTeamId].GoalDifference += " Tor";
                    else
                        table[matchOfSeason.AwayTeamId].GoalDifference += " Tore";
                }
                else
                {
                    table[matchOfSeason.AwayTeamId].GoalDifference = "+ " +
                                                                     table[matchOfSeason.AwayTeamId].TempGoalDifference;
                    if (table[matchOfSeason.AwayTeamId].TempGoalDifference == 1)
                        table[matchOfSeason.AwayTeamId].GoalDifference += " Tor";
                    else
                        table[matchOfSeason.AwayTeamId].GoalDifference += " Tore";
                }

                if (table[matchOfSeason.HomeTeamId].TempPoints != 1)
                    table[matchOfSeason.HomeTeamId].Points = table[matchOfSeason.HomeTeamId].TempPoints + " Punkte";
                else
                    table[matchOfSeason.HomeTeamId].Points = table[matchOfSeason.HomeTeamId].TempPoints + " Punkt";

                if (table[matchOfSeason.AwayTeamId].TempPoints != 1)
                    table[matchOfSeason.AwayTeamId].Points = table[matchOfSeason.AwayTeamId].TempPoints + " Punkte";
                else
                    table[matchOfSeason.AwayTeamId].Points = table[matchOfSeason.AwayTeamId].TempPoints + " Punkt";
            }
            var values = table.Values.ToList();
            values.Sort((e1, e2) =>
            {
                var ret = e2.TempPoints.CompareTo(e1.TempPoints);
                if (ret == 0) ret = e2.TempGoalDifference.CompareTo(e1.TempGoalDifference);
                if (ret == 0) ret = CompareOrdinal(e1.Teamname,e2.Teamname);
                return ret;
            });
            for (var i = 1; i <= values.Count; i++)
            {
                values[i - 1].Placement = i;

                values[i - 1].WonRatio =
                    new GridLength(values[i - 1].AmountWon, GridUnitType.Star);
                values[i - 1].DrawRatio =
                    new GridLength(values[i - 1].AmountDraw, GridUnitType.Star);
                values[i - 1].LostRatio =
                    new GridLength(values[i - 1].AmountLost, GridUnitType.Star);
                if (values[i - 1].AmountMatches < 1)
                {
                    values[i - 1].MatchesRatio =
                        new GridLength(1, GridUnitType.Star);
                    values[i - 1].ZeroMatch = "0";
                }
            }
            return values;
        }
    }
}