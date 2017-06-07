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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISeasonService" in both code and config file together.
    [ServiceContract]
    public interface ISeasonService
    {
        [OperationContract]
        List<Season> GetAllSeasons();

        [OperationContract]
        IValidationMessage CreateSeason(string name, string description, int sequence);

        [OperationContract]
        IValidationMessage EditSeason(Season season, string name, string description, int sequence);

        [OperationContract]
        IValidationMessage DeleteSeason(Season season);
    }
}
