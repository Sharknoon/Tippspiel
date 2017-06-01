using System.Collections.Generic;

namespace Tippspiel_Server.Models
{
    public class Season
    {
        public int Id { get; set; }
        public int Version { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public List<Team> Teams { get; set; }
    }
}