using System.Collections.Generic;

namespace Tippspiel_Server.Sources.Service.Models
{
    public class TeamMessage
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; }
        public List<int> SeasonIDs { get; set; } = new List<int>();
    }
}