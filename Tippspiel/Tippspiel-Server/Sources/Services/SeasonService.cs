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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SeasonService" in both code and config file together.
    public class SeasonService : ISeasonService
    {
        public List<Season> GetAllSeasons()
        {
            return Database.Database.Seasons;
        }

        public IValidationMessage RemoveSeason()
        {
            //TODO
            return new ValidationSuccess();
        }
    }
}
