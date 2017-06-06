using System;
using System.Linq;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class MatchValidator
    {
        public static IValidationMessage CreateMatch(int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam, Season season)
        {
            if (matchDay < 1)
            {
                return new ValidationError("Der Spieltag darf nicht kleiner als 1 sein");
            }
            if (homeTeam == null)
            {
                return new ValidationError("Die Heim-Mannschaft ist null");
            }
            if (awayTeam == null)
            {
                return new ValidationError("Die Auswärts-Manschaft ist null");
            }
            if (season == null)
            {
                return new ValidationError("Die Saison ist null");
            }
            if (Database.Database.Matches.Any(match => match.Season.Equals(season) && match.AwayTeam.Equals(awayTeam) && match.HomeTeam.Equals(homeTeam)))
            {
                return new ValidationError(homeTeam.Name+" (Heim) spielt bereits in der Saison "+season.Name+" gegen "+awayTeam.Name+" (Auswärts)");
            }
            return new ValidationSuccess();
        }

        public static IValidationMessage EditMatch(Match match, int matchDay, DateTime dateTime, Team homeTeam,
            Team awayTeam, Season season)
        {
            if (match == null)
            {
                return new ValidationError("Das zu bearbeitende Spiel ist null");
            }
            if (homeTeam == null)
            {
                return new ValidationError("Die Heim-Mannschaft ist null");
            }
            if (awayTeam == null)
            {
                return new ValidationError("Die Auswärts-Manschaft ist null");
            }
            if (season == null)
            {
                return new ValidationError("Die Saison ist null");
            }
            if (!matchDay.Equals(match.MatchDay))
            {
                if (matchDay < 1)
                {
                    return new ValidationError("Der Spieltag darf nicht kleiner als 1 sein");
                }
            }
            if (!homeTeam.Equals(match.HomeTeam) || !awayTeam.Equals(match.AwayTeam) || !season.Equals(match.Season))
            {
                if (Database.Database.Matches.Any(match1 => match1.Season.Equals(season) && match1.AwayTeam.Equals(awayTeam) && match1.HomeTeam.Equals(homeTeam)))
                {
                    return new ValidationError(homeTeam.Name + " (Heim) spielt bereits in der Saison " + season.Name + " gegen " + awayTeam.Name + " (Auswärts)");
                }
            }
            return new ValidationSuccess();
        }

        public IValidationMessage DeleteMatch(Match match)
        {
            if (match == null)
            {
                return new ValidationError("Das zu löschende Spiel ist null");
            }
            return new ValidationSuccess();
        }
    }
}