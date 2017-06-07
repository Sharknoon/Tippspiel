using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Validators.Helper;

namespace Tippspiel_Server.Sources.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBetService" in both code and config file together.
    [ServiceContract]
    public interface IBetService
    {
        [OperationContract]
        List<Bet> GetAllBets(Bettor bettor);

        [OperationContract]
        IValidationMessage CreateBet(DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor);

        [OperationContract]
        IValidationMessage EditBet(Bet bet, DateTime dateTime, int homeTeamScore, int awayTeamScore, Match match,
            Bettor bettor);

        [OperationContract]
        IValidationMessage DeleteBet(Bet bet);

    }
}
