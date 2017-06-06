using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Conventions;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class SeasonValidator
    {
        public static IValidationMessage CreateSeason(string name, string description, int sequence)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                return new ValidationError("Der Name der Saison ist null oder zu kurz (mind. 3 Zeichen)");
            }
            if (Database.Database.Seasons.Any(season => season.Name.ToLower().Equals(name.ToLower())))
            {
                return new ValidationError("Der Name der Saison ist bereits vergeben");
            }
            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                return new ValidationError("Die Beschreibung der Saison ist null oder zu kurz (mind. 5 Zeichen)");
            }
            if (Database.Database.Seasons.Any(season => season.Sequence == sequence))
            {
                return new ValidationError("Die Sortierreihenfolge gibt es bereits");
            }
            return new ValidationSuccess();
        }

        public static IValidationMessage EditSeason(Season season, string name ,
            string description, int sequence)
        {
            if (season == null)
            {
                return new ValidationError("Die zu bearbeitende Saison ist null");
            }
            if (!name.Equals(season.Name))
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3)
                {
                    return new ValidationError("Der Name der Saison ist null oder zu kurz (mind. 3 Zeichen)");
                }
                if (Database.Database.Seasons.Any(season1 => season1.Name.ToLower().Equals(name.ToLower())))
                {
                    return new ValidationError("Der Name der Saison ist bereits vergeben");
                }                
            }
            if (!description.Equals(season.Description))
            {
                if (string.IsNullOrEmpty(description) || description.Length < 5)
                {
                    return new ValidationError("Die Beschreibung der Saison ist null oder zu kurz (mind. 5 Zeichen)");
                }
            }
            if (!sequence.Equals(season.Sequence))
            {
                if (Database.Database.Seasons.Any(season1 => season1.Sequence == sequence))
                {
                    return new ValidationError("Die Sortierreihenfolge gibt es bereits");
                }
            }
            return new ValidationSuccess();
        }

        public static IValidationMessage DeleteSeason(Season season)
        {
            if (season == null)
            {
                return new ValidationError("Die zu löschende Saison ist null");
            }
            if (Database.Database.Teams.Any(team => team.Seasons.Contains(season)))
            {
                var teamsInSeason = Database.Database.Teams.FindAll(team => team.Seasons.Contains(season));
                var errorMsg = teamsInSeason.Aggregate("Die Teams ", (current, team) => current + team.Name + ", ");
                errorMsg = errorMsg.Substring(0, errorMsg.Length - 2) +
                           " befinden sich noch in der zu löschenden Saison, Saison kann nicht gelöscht werden";
                return new ValidationError(errorMsg);
            }
            if (Database.Database.Matches.Any(match => match.Season.Equals(season)))
            {
                var matchesInSeason = Database.Database.Matches.FindAll(match => match.Season.Equals(season));
                var errorMsg = matchesInSeason.Aggregate("Die Spiele der Spieltage ",
                    (current, match) => current + match.MatchDay + ", ");
                errorMsg = errorMsg.Substring(0, errorMsg.Length - 2) +
                           " befinden sich noch in der zu löschenden Saison, Saison kann nicht gelöscht werden";
                return new ValidationError(errorMsg);
            }
            return new ValidationSuccess();
        }
    }
}