using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Tippspiel_Benutzerclient.ServiceReference;
using Tippspiel_Benutzerclient.Sources.Models;

namespace Tippspiel_Benutzerclient.Sources.Tools
{
    public class TableTools
    {
        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static List<SeasonTableEntry> GetTableFor(SeasonMessage season, int matchDay)
        {
            Dictionary<int, SeasonTableEntry> table = new Dictionary<int, SeasonTableEntry>(); //TeamId, TableEntry

            List<MatchMessage> matchesOfSeason = Service.GetAllMatchesForSeason(season.Id)
                .Where(match => match.MatchDay <= matchDay).ToList();
            Dictionary<int, TeamMessage> teamsOfSeason = Service.GetAllTeamsForSeason(season.Id)
                .ToDictionary(team => team.Id, team => team);

            foreach (var matchOfSeason in matchesOfSeason)
            {
                //Teamname
                if (!table.ContainsKey(matchOfSeason.HomeTeamId))
                {
                    table.Add(matchOfSeason.HomeTeamId, new SeasonTableEntry()
                    {
                        Teamname = teamsOfSeason[matchOfSeason.HomeTeamId]?.Name
                    });
                }
                if (!table.ContainsKey(matchOfSeason.AwayTeamId))
                {
                    table.Add(matchOfSeason.AwayTeamId, new SeasonTableEntry()
                    {
                        Teamname = teamsOfSeason[matchOfSeason.AwayTeamId]?.Name
                    });
                }
                //Amount Matches
                table[matchOfSeason.HomeTeamId].AmountMatches++;
                table[matchOfSeason.AwayTeamId].AmountMatches++;
                //Amount Wons, Draws, Looses, Point
                int homeTeam = matchOfSeason.HomeTeamScore - matchOfSeason.AwayTeamScore;
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
                                                                     (table[matchOfSeason.HomeTeamId]
                                                                          .TempGoalDifference * -1);
                    if (table[matchOfSeason.HomeTeamId].TempGoalDifference == -1)
                    {
                        table[matchOfSeason.HomeTeamId].GoalDifference += " Tor";
                    }
                    else
                    {
                        table[matchOfSeason.HomeTeamId].GoalDifference += " Tore";
                    }
                }
                else
                {
                    table[matchOfSeason.HomeTeamId].GoalDifference = "+ " +
                                                                     table[matchOfSeason.HomeTeamId].TempGoalDifference;
                    if (table[matchOfSeason.HomeTeamId].TempGoalDifference == 1)
                    {
                        table[matchOfSeason.HomeTeamId].GoalDifference += " Tor";
                    }
                    else
                    {
                        table[matchOfSeason.HomeTeamId].GoalDifference += " Tore";
                    }
                }

                if (table[matchOfSeason.AwayTeamId].TempGoalDifference < 0)
                {
                    table[matchOfSeason.AwayTeamId].GoalDifference = "- " +
                                                                     (table[matchOfSeason.AwayTeamId]
                                                                          .TempGoalDifference * -1);
                    if (table[matchOfSeason.AwayTeamId].TempGoalDifference == -1)
                    {
                        table[matchOfSeason.AwayTeamId].GoalDifference += " Tor";
                    }
                    else
                    {
                        table[matchOfSeason.AwayTeamId].GoalDifference += " Tore";
                    }
                }
                else
                {
                    table[matchOfSeason.AwayTeamId].GoalDifference = "+ " +
                                                                     table[matchOfSeason.AwayTeamId].TempGoalDifference;
                    if (table[matchOfSeason.AwayTeamId].TempGoalDifference == 1)
                    {
                        table[matchOfSeason.AwayTeamId].GoalDifference += " Tor";
                    }
                    else
                    {
                        table[matchOfSeason.AwayTeamId].GoalDifference += " Tore";
                    }
                }

                if (table[matchOfSeason.HomeTeamId].TempPoints != 1)
                {
                    table[matchOfSeason.HomeTeamId].Points = table[matchOfSeason.HomeTeamId].TempPoints + " Punkte";
                }
                else
                {
                    table[matchOfSeason.HomeTeamId].Points = table[matchOfSeason.HomeTeamId].TempPoints + " Punkt";
                }

                if (table[matchOfSeason.AwayTeamId].TempPoints != 1)
                {
                    table[matchOfSeason.AwayTeamId].Points = table[matchOfSeason.AwayTeamId].TempPoints + " Punkte";
                }
                else
                {
                    table[matchOfSeason.AwayTeamId].Points = table[matchOfSeason.AwayTeamId].TempPoints + " Punkt";
                }
                table[matchOfSeason.HomeTeamId].WonRatio =
                    new GridLength(table[matchOfSeason.HomeTeamId].AmountWon, GridUnitType.Star);
                table[matchOfSeason.HomeTeamId].DrawRatio =
                    new GridLength(table[matchOfSeason.HomeTeamId].AmountDraw, GridUnitType.Star);
                table[matchOfSeason.HomeTeamId].LostRatio =
                    new GridLength(table[matchOfSeason.HomeTeamId].AmountLost, GridUnitType.Star);
                table[matchOfSeason.AwayTeamId].WonRatio =
                    new GridLength(table[matchOfSeason.AwayTeamId].AmountWon, GridUnitType.Star);
                table[matchOfSeason.AwayTeamId].DrawRatio =
                    new GridLength(table[matchOfSeason.AwayTeamId].AmountDraw, GridUnitType.Star);
                table[matchOfSeason.AwayTeamId].LostRatio =
                    new GridLength(table[matchOfSeason.AwayTeamId].AmountLost, GridUnitType.Star);
            }
            List<SeasonTableEntry> values = table.Values.ToList();
            values.Sort((e1, e2) =>
            {
                var ret = e2.TempPoints.CompareTo(e1.TempPoints);
                if (ret == 0) ret = e2.TempGoalDifference.CompareTo(e1.TempGoalDifference);
                return ret;
            });
            for (var i = 1; i <= values.Count; i++)
            {
                values[i - 1].Placement = i;
            }
            return values;
        }
    }
}