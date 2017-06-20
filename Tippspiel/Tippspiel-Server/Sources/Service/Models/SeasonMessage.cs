using System.Collections.Generic;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Service.Models
{
    public class SeasonMessage
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public List<int> TeamIds { get; set; } = new List<int>();
    }
}