using System;
using System.Linq;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class MatchValidator
    {
        public static string CreateMatch(int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam, Season season)
        {
            string errors = "";
            if (matchDay < 1)
            {
                errors += "Der Spieltag darf nicht kleiner als 1 sein\n";
            }
            if (homeTeam == null || awayTeam == null || season == null)
            {
                if (homeTeam == null)
                {
                    errors += "Die Heim-Mannschaft ist null\n";
                }
                if (awayTeam == null)
                {
                    errors += "Die Auswärts-Manschaft ist null\n";
                }
                if (season == null)
                {
                    errors += "Die Saison ist null\n";
                }
            }
            else
            {
                if (Database.Database.Matches.GetAll()
                    .Any(match => match.Season.Equals(season) && match.AwayTeam.Equals(awayTeam) &&
                                  match.HomeTeam.Equals(homeTeam)))
                {
                    errors += homeTeam.Name + " (Heim) spielt bereits in der Saison " + season.Name + " gegen " +
                              awayTeam.Name + " (Auswärts)\n";
                }
                if (homeTeam.Id.Equals(awayTeam.Id))
                {
                    errors += "Eine Mannschaft kann nicht gegen sich selbst spielen\n";
                }
            }
            return errors;
        }

        public static string EditMatch(Match match, int matchDay, DateTime dateTime, Team homeTeam,
            Team awayTeam, Season season)
        {
            string errors = "";
            if (match == null || homeTeam == null || awayTeam == null || season == null)
            {
                if (match == null)
                {
                    errors += "Das zu bearbeitende Spiel ist null\n";
                }
                if (homeTeam == null)
                {
                    errors += "Die Heim-Mannschaft ist null\n";
                }
                if (awayTeam == null)
                {
                    errors += "Die Auswärts-Manschaft ist null\n";
                }
                if (season == null)
                {
                    errors += "Die Saison ist null\n";
                }
            }
            else
            {
                if (!matchDay.Equals(match.MatchDay))
                {
                    if (matchDay < 1)
                    {
                        errors += "Der Spieltag darf nicht kleiner als 1 sein\n";
                    }
                }
                if (!homeTeam.Equals(match.HomeTeam) || !awayTeam.Equals(match.AwayTeam) ||
                    !season.Equals(match.Season))
                {
                    if (Database.Database.Matches.GetAll()
                        .Any(match1 => match1.Season.Equals(season) && match1.AwayTeam.Equals(awayTeam) &&
                                       match1.HomeTeam.Equals(homeTeam)))
                    {
                        errors += homeTeam.Name + " (Heim) spielt bereits in der Saison " + season.Name + " gegen " +
                                  awayTeam.Name + " (Auswärts)\n";
                    }
                    if (homeTeam.Id.Equals(awayTeam.Id))
                    {
                        errors += "Eine Mannschaft kann nicht gegen sich selbst spielen\n";
                    }
                }
            }
            return errors;
        }

        public static string DeleteMatch(Match match)
        {
            string errors = "";
            if (match == null)
            {
                errors += "Das zu löschende Spiel ist null\n";
            }
            return errors;
        }
    }
}