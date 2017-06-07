using System.Collections.Generic;

namespace Tippspiel_Server.Sources.Service.Models
{
    public class TeamMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> SeasonIDs { get; set; }
    }
}