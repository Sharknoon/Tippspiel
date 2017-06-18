using System.Linq;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class TeamValidator
    {
        public static IValidationMessage CreateTeam(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3)
            {
                return new ValidationError("Der Name der Mannschaft ist null oder zu kurz (mind. 3 Zeichen)");
            }
            if (Database.Database.Teams.GetAll().Any(team => team.Name.ToLower().Equals(name.ToLower())))
            {
                return new ValidationError("Eine Mannschaft mit diesem Namen existiert bereits");
            }
            return new ValidationSuccess();
        }

        public static IValidationMessage EditTeam(Team team, string name)
        {
            if (team == null)
            {
                return new ValidationError("Die zu bearbeitende Mannschaft ist null");
            }
            if (!name.Equals(team.Name))
            {
                if (string.IsNullOrEmpty(name) || name.Length < 3)
                {
                    return new ValidationError("Der Name der Mannschaft ist null oder zu kurz (mind. 3 Zeichen)");
                }
                if (Database.Database.Teams.GetAll().Any(team1 => team1.Name.ToLower().Equals(name.ToLower())))
                {
                    return new ValidationError("Eine Mannschaft mit diesem Namen existiert bereits");
                }
            }
            return new ValidationSuccess();
        }

        public static IValidationMessage DeleteTeam(Team team)
        {
            if (team == null)
            {
                return new ValidationError("Die zu löschende Mannschaft ist null");
            }
            return new ValidationSuccess();
        }
    }
}