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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBettorService" in both code and config file together.
    [ServiceContract]
    public interface IBettorService
    {
        [OperationContract]
        List<Bettor> GetAllBettors();

        [OperationContract]
        IValidationMessage CreateBettor(string nickname, string firstName, string lastName);

        [OperationContract]
        IValidationMessage EditBettor(Bettor bettor, string nickname, string firstName, string lastName);

        [OperationContract]
        IValidationMessage DeleteBettor(Bettor bettor);
    }
}
