﻿using System.Linq;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Validators
{
    public class BettorValidator
    {
        public static string CreateBettor(string nickname, string firstName, string lastName)
        {
            var errors = "";
            if (string.IsNullOrEmpty(nickname) || nickname.Length < 4)
                errors += "Der Spitzname ist null oder zu kurz (mind. 4 Zeichen)\n";
            else if (Database.Database.Bettors.GetAll()
                .Any(bettor => bettor.Nickname.ToLower().Equals(nickname.ToLower())))
                errors += "Der Spitzname " + nickname + " wird bereits verwendet\n";
            if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
                errors += "Der Vorname ist null oder zu kurz (mind. 3 Zeichen)\n";
            if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
                errors += "Der Nachname ist null oder zu kurz (mind. 3 Zeichen)\n";
            return errors;
        }

        public static string EditBettor(Bettor bettor, string nickname, string firstName, string lastName)
        {
            var errors = "";
            if (bettor == null)
            {
                errors += "Der zu bearbeitende Tipper ist null\n";
            }
            else if (!nickname.Equals(bettor.Nickname))
            {
                if (string.IsNullOrEmpty(nickname) || nickname.Length < 4)
                    errors += "Der Spitzname ist null oder zu kurz (mind. 4 Zeichen)\n";
                else if (Database.Database.Bettors.GetAll()
                    .Any(bettor1 => bettor1.Nickname.ToLower().Equals(nickname.ToLower())))
                    errors += "Der Spitzname " + nickname + " wird bereits verwendet\n";

                if (!firstName.Equals(bettor.Firstname))
                    if (string.IsNullOrEmpty(firstName) || firstName.Length < 3)
                        errors += "Der Vorname ist null oder zu kurz (mind. 3 Zeichen)\n";
                if (!lastName.Equals(bettor.Lastname))
                    if (string.IsNullOrEmpty(lastName) || lastName.Length < 3)
                        errors += "Der Nachname ist null oder zu kurz (mind. 3 Zeichen)\n";
            }
            return errors;
        }

        public static string DeleteBettor(Bettor bettor)
        {
            var errors = "";
            if (bettor == null)
            {
                errors += "Der zu löschende Tipper ist null\n";
            }
            else if (Database.Database.Bets.GetAll().Any(bet => bet.Bettor.Nickname.Equals(bettor.Nickname)))
            {
                var betsOfBettor = Database.Database.Bets.GetAll()
                    .FindAll(bet => bet.Bettor.Nickname.Equals(bettor.Nickname));
                errors += betsOfBettor.Aggregate(
                    "Der Tipper " + bettor.Nickname +
                    " kann nicht gelöscht werden, da es noch folgende Wetten von ihm gibt:\n",
                    (current, bet) => current + "   -  " + bet.Match.HomeTeam.Name + " : " + bet.Match.AwayTeam.Name +
                                      "  (" +
                                      bet.HomeTeamScore + ":" + bet.AwayTeamScore + ")\n");
            }
            return errors;
        }
    }
}