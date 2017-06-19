using System;
using System.Collections.Generic;
using System.Linq;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class TeamValidator
    {
        public static string CreateTeam(string name)
        {
            string errors = "";
            if (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                errors += "Der Name der Mannschaft ist null oder zu kurz (mind. 3 Zeichen)";
            }
            else if (Database.Database.Teams.GetAll().Any(team => team.Name.ToLower().Equals(name.ToLower())))
            {
                errors += "Eine Mannschaft mit diesem Namen existiert bereits";
            }
            return errors;
        }

        public static string EditTeam(Team team, string name, List<int> seasonIDs)
        {
            string errors = "";
            if (team == null)
            {
                errors += "Die zu bearbeitende Mannschaft ist null";
            }
            else if (!name.Equals(team.Name))
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3)
                {
                    errors += "Der Name der Mannschaft ist null oder zu kurz (mind. 3 Zeichen)";
                }
                if (Database.Database.Teams.GetAll().Any(team1 => team1.Name.ToLower().Equals(name.ToLower())))
                {
                    errors += "Eine Mannschaft mit diesem Namen existiert bereits";
                }
                if (seasonIDs.GroupBy(s => s).Any(c => c.Count() > 1))
                {
                    errors += "Eine oder mehrere Saisons sind mehrfach für diese Mannschaft eingetragen";
                }
            }
            return errors;
        }

        public static string DeleteTeam(Team team)
        {
            string errors = "";
            if (team == null)
            {
                errors += "Die zu löschende Mannschaft ist null";
            }
            return errors;
        }

    }
}