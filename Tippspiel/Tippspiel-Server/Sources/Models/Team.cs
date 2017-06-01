﻿using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Tippspiel_Server.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int Version { get; set; }

        public string Name { get; set; }
        public List<Season> Seasons { get; set; }

    }
}