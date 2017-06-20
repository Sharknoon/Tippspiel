using System;
using System.Linq;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class BetValidator
    {
        public static string CreateBet(DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor)
        {
            string errors = "";
            if (match == null || bettor == null)
            {
                if (match == null)
                {
                    errors += "Das Spiel der Wette ist null";
                }
                if (bettor == null)
                {
                    errors += "Der Tipper der Wette ist null";
                }
            }
            else
            {
                if (homeTeamScore < 0)
                {
                    errors += "Der Tipp auf die Heim-Mannschaft ist unter 0";
                }
                if (awayTeamScore < 0)
                {
                    errors += "Der Tipp auf die Gast-Mannschaft ist unter 0";
                }
                if (Database.Database.Bets.GetAll().Any(bet => bet.Bettor.Equals(bettor) && bet.Match.Equals(match)))
                {
                    errors += "Der Tipper " + bettor.Nickname + " hat bereits für das Spiel " + match.HomeTeam.Name +
                              " gegen " + match.AwayTeam.Name + " eine Wette abgegeben";
                }
            }
            return errors;
        }

        public static string EditBet(Bet bet, DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor)
        {
            string errors = "";
            if (bet == null || match == null || bettor == null)
            {
                if (bet == null)
                {
                    errors += "Die zu bearbeitende Wette ist null";
                }
                if (match == null)
                {
                    errors += "Das Spiel der Wette ist null";
                }
                if (bettor == null)
                {
                    errors += "Der Tipper der Wette ist null";
                }
            }
            else
            {
                if (!homeTeamScore.Equals(bet.HomeTeamScore))
                {
                    if (homeTeamScore < 0)
                    {
                        errors += "Der Tipp auf die Heim-Mannschaft ist unter 0";
                    }
                }
                if (!awayTeamScore.Equals(bet.AwayTeamScore))
                {
                    if (awayTeamScore < 0)
                    {
                        errors += "Der Tipp auf die Gast-Mannschaft ist unter 0";
                    }
                }
                if (!match.Equals(bet.Match) || !bettor.Equals(bet.Bettor))
                {
                    if (Database.Database.Bets.GetAll()
                        .Any(bet1 => bet1.Bettor.Equals(bettor) && bet1.Match.Equals(match)))
                    {
                        errors += "Der Tipper " + bettor.Nickname + " hat bereits für das Spiel " +
                                  match.HomeTeam.Name +
                                  " gegen " + match.AwayTeam.Name + " eine Wette abgegeben";
                    }
                }
            }
            return errors;
        }

        public static string DeleteBet(Bet bet)
        {
            string errors = "";
            if (bet == null)
            {
                errors += "Die zu löschende Wette ist null";
            }
            return errors;
        }
    }
}