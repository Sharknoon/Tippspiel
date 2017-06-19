using System.Linq;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class BettorValidator
    {
        public static string CreateBettor(string nickname, string firstName, string lastName)
        {
            string errors = "";
            if (string.IsNullOrEmpty(nickname) || nickname.Length < 4)
            {
                errors += "Der Spitzname ist null oder zu kurz (mind. 4 Zeichen)\n";
            }
            else if (Database.Database.Bettors.GetAll()
                .Any(bettor => bettor.Nickname.ToLower().Equals(nickname.ToLower())))
            {
                errors += "Der Spitzname " + nickname + " wird bereits verwendet\n";
            }
            if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
            {
                errors += "Der Vorname ist null oder zu kurz (mind. 3 Zeichen)\n";
            }
            if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
            {
                errors += "Der Nachname ist null oder zu kurz (mind. 3 Zeichen)\n";
            }
            return errors;
        }

        public static string EditBettor(BettorMessage bettor, string nickname, string firstName, string lastName)
        {
            string errors = "";
            if (bettor == null)
            {
                errors += "Der zu bearbeitende Tipper ist null\n";
            }
            else if (!nickname.Equals(bettor.Nickname))
            {
                if (string.IsNullOrEmpty(nickname) || nickname.Length < 4)
                {
                    errors += "Der Spitzname ist null oder zu kurz (mind. 4 Zeichen)\n";
                }
                else if (Database.Database.Bettors.GetAll()
                    .Any(bettor1 => bettor1.Nickname.ToLower().Equals(nickname.ToLower())))
                {
                    errors += "Der Spitzname " + nickname + " wird bereits verwendet\n";
                }

                if (!firstName.Equals(bettor.Firstname))
                {
                    if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
                    {
                        errors += "Der Vorname ist null oder zu kurz (mind. 3 Zeichen)\n";
                    }
                }
                if (!lastName.Equals(bettor.Lastname))
                {
                    if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
                    {
                        errors += "Der Nachname ist null oder zu kurz (mind. 3 Zeichen)\n";
                    }
                }
            }
            return errors;
        }

        public static string DeleteBettor(BettorMessage bettor)
        {
            string errors = "";
            if (bettor == null)
            {
                errors += "Der zu löschende Tipper ist null\n";
            }
            else if (Database.Database.Bets.GetAll().Any(bet => bet.Bettor.Nickname.Equals(bettor.Nickname)))
            {
                var betsOfBettor = Database.Database.Bets.GetAll().FindAll(bet => bet.Bettor.Nickname.Equals(bettor.Nickname));
                var errorMsg = betsOfBettor.Aggregate(
                    "Der Tipper " + bettor.Nickname + " kann nicht gelöscht werden, da es noch Wetten (",
                    (current, bet) => current + "Spiel " + bet.Match.MatchDay + ", ");
                errorMsg = errorMsg.Substring(0, errorMsg.Length - 2) + ") von ihm gibt";
                errors += errorMsg+"\n";
            }
            return errors;
        }
    }
}