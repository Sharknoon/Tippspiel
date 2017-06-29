using System;
using System.Linq;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Validators
{
    public class MatchValidator
    {
        public static string CreateMatch(int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam, Season season)
        {
            var errors = "";
            if (matchDay < 1)
                errors += "Der Spieltag darf nicht kleiner als 1 sein\n";
            if (homeTeam == null || awayTeam == null || season == null)
            {
                if (homeTeam == null)
                    errors += "Die Heim-Mannschaft ist null\n";
                if (awayTeam == null)
                    errors += "Die Auswärts-Manschaft ist null\n";
                if (season == null)
                    errors += "Die Saison ist null\n";
            }
            else
            {
                if (Database.Database.Matches.GetAll()
                    .Any(match => match.Season.Id.Equals(season.Id) && match.AwayTeam.Id.Equals(awayTeam.Id) &&
                                  match.HomeTeam.Id.Equals(homeTeam.Id)))
                    errors += homeTeam.Name + " (Heim) spielt bereits in der Saison " + season.Name + " gegen " +
                              awayTeam.Name + " (Auswärts)\n";
                if (homeTeam.Id.Equals(awayTeam.Id))
                    errors += "Eine Mannschaft kann nicht gegen sich selbst spielen\n";
            }
            return errors;
        }

        public static string EditMatch(Match match, int matchDay, DateTime dateTime, Team homeTeam,
            Team awayTeam, Season season)
        {
            var errors = "";
            if (match == null || homeTeam == null || awayTeam == null || season == null)
            {
                if (match == null)
                    errors += "Das zu bearbeitende Spiel ist null\n";
                if (homeTeam == null)
                    errors += "Die Heim-Mannschaft ist null\n";
                if (awayTeam == null)
                    errors += "Die Auswärts-Manschaft ist null\n";
                if (season == null)
                    errors += "Die Saison ist null\n";
            }
            else
            {
                if (!matchDay.Equals(match.MatchDay))
                    if (matchDay < 1)
                        errors += "Der Spieltag darf nicht kleiner als 1 sein\n";
                if (!homeTeam.Id.Equals(match.HomeTeam.Id) || !awayTeam.Id.Equals(match.AwayTeam.Id) ||
                    !season.Id.Equals(match.Season.Id))
                {
                    if (Database.Database.Matches.GetAll()
                        .Any(match1 => match1.Season.Id.Equals(season.Id) && match1.AwayTeam.Id.Equals(awayTeam.Id) &&
                                       match1.HomeTeam.Id.Equals(homeTeam.Id)))
                        errors += homeTeam.Name + " (Heim) spielt bereits in der Saison " + season.Name + " gegen " +
                                  awayTeam.Name + " (Auswärts)\n";
                    if (homeTeam.Id.Equals(awayTeam.Id))
                        errors += "Eine Mannschaft kann nicht gegen sich selbst spielen\n";
                }
            }
            return errors;
        }

        public static string DeleteMatch(Match match)
        {
            var errors = "";
            if (match == null)
                errors += "Das zu löschende Spiel ist null\n";
            return errors;
        }
    }
}