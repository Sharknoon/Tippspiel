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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMatchService" in both code and config file together.
    [ServiceContract]
    public interface IMatchService
    {
        [OperationContract]
        List<Match> GetAllMatches();

        [OperationContract]
        IValidationMessage CreateMatch(int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam, Season season);

        [OperationContract]
        IValidationMessage EditMatch(Match match, int matchDay, DateTime dateTime, Team homeTeam, Team awayTeam,
            Season season);

        [OperationContract]
        IValidationMessage DeleteMatch(Match match);
    }
}
