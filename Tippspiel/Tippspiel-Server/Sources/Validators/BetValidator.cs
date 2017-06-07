﻿using System;
using System.Linq;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Validators
{
    public class BetValidator
    {
        public static IValidationMessage CreateBet(DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match, Bettor bettor)
        {
            if (match == null)
            {
                return new ValidationError("Das Spiel der Wette ist null");
            }
            if (bettor == null)
            {
                return new ValidationError("Der Tipper der Wette ist null");
            }
            if (homeTeamScore < 0)
            {
                return new ValidationError("Der Tipp auf die Heim-Mannschaft ist unter 0");
            }
            if (awayTeamScore < 0)
            {
                return new ValidationError("Der Tipp auf die Gast-Mannschaft ist unter 0");
            }
            if (Database.Database.Bets.Any(bet => bet.Bettor.Equals(bettor) && bet.Match.Equals(match)))
            {
                return new ValidationError("Der Tipper "+bettor.Nickname+" hat bereits für das Spiel "+match.HomeTeam.Name+" gegen "+match.AwayTeam.Name+" eine Wette abgegeben");
            }
            return new ValidationSuccess();
        }

        public static IValidationMessage DeleteBet(Bet bet)
        {
            if (bet == null)
            {
                return new ValidationError("Die zu löschende Wette ist null");
            }
            return new ValidationSuccess();
        }
    }
}