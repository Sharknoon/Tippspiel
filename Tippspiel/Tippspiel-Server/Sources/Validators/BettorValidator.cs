using System.Linq;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class BettorValidator
    {
        public static IValidationMessage CreateBettor(string nickname, string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(nickname) || nickname.Length<4)
            {
                return new ValidationError("Der Spitzname ist null oder zu kurz (mind. 4 Zeichen)");
            }
            if (Database.Database.Bettors.GetAll().Any(bettor => bettor.Nickname.ToLower().Equals(nickname.ToLower())))
            {
                return new ValidationError("Der Spitzname "+nickname+" wird bereits verwendet");
            }
            if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
            {
                return new ValidationError("Der Vorname ist null oder zu kurz (mind. 3 Zeichen)");
            }
            if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
            {
                return new ValidationError("Der Nachname ist null oder zu kurz (mind. 3 Zeichen)");
            }
            return new ValidationSuccess();
        }

        public static IValidationMessage EditBettor(Bettor bettor, string nickname, string firstName, string lastName)
        {
            if (bettor == null)
            {
                return new ValidationError("Der zu bearbeitende Tipper ist null");
            }
            if (!nickname.Equals(bettor.Nickname))
            {
                if (string.IsNullOrEmpty(nickname) || nickname.Length < 4)
                {
                    return new ValidationError("Der Spitzname ist null oder zu kurz (mind. 4 Zeichen)");
                }
                if (Database.Database.Bettors.GetAll().Any(bettor1 => bettor1.Nickname.ToLower().Equals(nickname.ToLower())))
                {
                    return new ValidationError("Der Spitzname " + nickname + " wird bereits verwendet");
                }
            }
            if (!firstName.Equals(bettor.Firstname))
            {
                if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
                {
                    return new ValidationError("Der Vorname ist null oder zu kurz (mind. 3 Zeichen)");
                }
            }
            if (!lastName.Equals(bettor.Lastname))
            {
                if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
                {
                    return new ValidationError("Der Nachname ist null oder zu kurz (mind. 3 Zeichen)");
                }
            }
            return new ValidationSuccess();
        }

        public static IValidationMessage DeleteBettor(Bettor bettor)
        {
            if (bettor == null)
            {
                return new ValidationError("Der zu löschende Tipper ist null");
            }
            if (Database.Database.Bets.GetAll().Any(bet => bet.Bettor.Equals(bettor)))
            {
                var betsOfBettor = Database.Database.Bets.GetAll().FindAll(bet => bet.Bettor.Equals(bettor));
                var errorMsg = betsOfBettor.Aggregate(
                    "Der Tipper " + bettor.Nickname + " kann nicht gelöscht werden, da es noch Wetten (",
                    (current, bet) => current + "Spiel " + bet.Match.MatchDay + ", ");
                errorMsg = errorMsg.Substring(0, errorMsg.Length - 2) + ") von ihm gibt";
                return new ValidationError(errorMsg);
            }
            return new ValidationSuccess();
        }

    }
}