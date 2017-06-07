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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeamService" in both code and config file together.
    [ServiceContract]
    public interface ITeamService
    {
        [OperationContract]
        List<Team> GetAllTeams();

        [OperationContract]
        IValidationMessage CreateTeam(string name);

        [OperationContract]
        IValidationMessage EditTeam(Team team, string name);

        [OperationContract]
        IValidationMessage DeleteTeaMessage(Team team);
    }
}
