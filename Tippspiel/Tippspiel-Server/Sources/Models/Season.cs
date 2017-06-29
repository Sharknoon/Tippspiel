using System.Collections.Generic;

namespace Tippspiel_Server.Sources.Models
{
    public class Season
    {
        //DB Identifier and Locking
        public int Id { get; set; }

        public int Version { get; set; }

        //Informations from the DB
        public string Name { get; set; }

        public string Description { get; set; }
        public int Sequence { get; set; }
        public IList<Team> Teams { get; set; }
    }
}