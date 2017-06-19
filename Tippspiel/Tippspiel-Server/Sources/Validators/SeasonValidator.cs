using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Conventions;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class SeasonValidator
    {
        public static string CreateSeason(string name, string description, int sequence)
        {
            string errors = "";
            if (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                errors += "Der Name der Saison ist null oder zu kurz (mind. 3 Zeichen)\n";
            }
            else if (Database.Database.Seasons.GetAll().Any(season => season.Name.ToLower().Equals(name.ToLower())))
            {
                errors += "Der Name der Saison ist bereits vergeben\n";
            }
            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                errors += "Die Beschreibung der Saison ist null oder zu kurz (mind. 5 Zeichen)\n";
            }
            if (Database.Database.Seasons.GetAll().Any(season => season.Sequence == sequence))
            {
                errors += "Die Sortierreihenfolge gibt es bereits\n";
            }
            return errors;
        }

        public static string EditSeason(Season season, string name,
            string description, int sequence)
        {
            string errors = "";
            if (season == null)
            {
                errors += "Die zu bearbeitende Saison ist null";
            }
            else
            {
                if (!name.Equals(season.Name))
                {
                    if (string.IsNullOrEmpty(name) || name.Length < 3)
                    {
                        errors += "Der Name der Saison ist null oder zu kurz (mind. 3 Zeichen)";
                    }
                    else if (Database.Database.Seasons.GetAll()
                        .Any(season1 => season1.Name.ToLower().Equals(name.ToLower())))
                    {
                        errors += "Der Name der Saison ist bereits vergeben";
                    }
                }

                if (!description.Equals(season.Description))
                {
                    if (string.IsNullOrEmpty(description) || description.Length < 5)
                    {
                        errors +=
                            "Die Beschreibung der Saison ist null oder zu kurz (mind. 5 Zeichen)";
                    }
                }
                if (!sequence.Equals(season.Sequence))
                {
                    if (Database.Database.Seasons.GetAll().Any(season1 => season1.Sequence == sequence))
                    {
                        errors += "Die Sortierreihenfolge gibt es bereits";
                    }
                }
            }
            return errors;
        }


        public static string DeleteSeason(Season season)
        {
            string errors = "";
            if (season == null)
            {
                errors += "Die zu löschende Saison ist null";
            }
            else
            {
                if (Database.Database.Teams.GetAll().Any(team => team.Seasons.Select(seasonL => seasonL.Id).Contains(season.Id)))
                {
                    var teamsInSeason = Database.Database.Teams.GetAll().FindAll(team => team.Seasons.Select(seasonL => seasonL.Id).Contains(season.Id));
                    var errorMsg = teamsInSeason.Aggregate("Die Teams ", (current, team) => current + team.Name + ", ");
                    errorMsg = errorMsg.Substring(0, errorMsg.Length - 2) +
                               " befinden sich noch in der zu löschenden Saison, Saison kann nicht gelöscht werden";
                    errors += errorMsg;
                }

                if (Database.Database.Matches.GetAll().Any(match => match.Season.Id.Equals(season.Id)))
                {
                    var matchesInSeason = Database.Database.Matches.GetAll()
                        .FindAll(match => match.Season.Id.Equals(season.Id));
                    var errorMsg = matchesInSeason.Aggregate("Die Spiele der Spieltage ",
                        (current, match) => current + match.MatchDay + ", ");
                    errorMsg = errorMsg.Substring(0, errorMsg.Length - 2) +
                               " befinden sich noch in der zu löschenden Saison, Saison kann nicht gelöscht werden";
                    errors += errorMsg;
                }
            }
            return errors;
        }
    }
}