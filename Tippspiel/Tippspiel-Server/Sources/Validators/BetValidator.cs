using System;
using System.Linq;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Validators
{
    public class BetValidator
    {
        public static string CreateBet(DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor)
        {
            var errors = "";
            if (match == null || bettor == null)
            {
                if (match == null)
                    errors += "Das Spiel der Wette ist null\n";
                if (bettor == null)
                    errors += "Der Tipper der Wette ist null\n";
            }
            else
            {
                if (homeTeamScore < 0)
                    errors += "Der Tipp auf die Heim-Mannschaft ist unter 0\n";
                if (awayTeamScore < 0)
                    errors += "Der Tipp auf die Gast-Mannschaft ist unter 0\n";
                if (Database.Database.Bets.GetAll()
                    .Any(bet => bet.Bettor.Id.Equals(bettor.Id) && bet.Match.Id.Equals(match.Id)))
                    errors += "Der Tipper " + bettor.Nickname + " hat bereits für das Spiel " + match.HomeTeam.Name +
                              " gegen " + match.AwayTeam.Name + " eine Wette abgegeben\n";
            }
            return errors;
        }

        public static string EditBet(Bet bet, DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor)
        {
            var errors = "";
            if (bet == null || match == null || bettor == null)
            {
                if (bet == null)
                    errors += "Die zu bearbeitende Wette ist null\n";
                if (match == null)
                    errors += "Das Spiel der Wette ist null\n";
                if (bettor == null)
                    errors += "Der Tipper der Wette ist null\n";
            }
            else
            {
                if (!homeTeamScore.Equals(bet.HomeTeamScore))
                    if (homeTeamScore < 0)
                        errors += "Der Tipp auf die Heim-Mannschaft ist unter 0\n";
                if (!awayTeamScore.Equals(bet.AwayTeamScore))
                    if (awayTeamScore < 0)
                        errors += "Der Tipp auf die Gast-Mannschaft ist unter 0\n";
                if (!match.Id.Equals(bet.Match.Id) || !bettor.Id.Equals(bet.Bettor.Id))
                    if (Database.Database.Bets.GetAll()
                        .Any(bet1 => bet1.Bettor.Id.Equals(bettor.Id) && bet1.Match.Id.Equals(match.Id)))
                        errors += "Der Tipper " + bettor.Nickname + " hat bereits für das Spiel " +
                                  match.HomeTeam.Name +
                                  " gegen " + match.AwayTeam.Name + " eine Wette abgegeben\n";
            }
            return errors;
        }

        public static string DeleteBet(Bet bet)
        {
            var errors = "";
            if (bet == null)
                errors += "Die zu löschende Wette ist null\n";
            return errors;
        }
    }
}