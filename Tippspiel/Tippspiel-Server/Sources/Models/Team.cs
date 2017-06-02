using System.Collections.Generic;

namespace Tippspiel_Server.Sources.Models
{
    public class Team
    {
        //DB Identifier and Locking
        public int Id { get; set; }
        public int Version { get; set; }

        //Informations from the DB
        public string Name { get; set; }
        public IList<Season> Seasons { get; set; }

    }
}