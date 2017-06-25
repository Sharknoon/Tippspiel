﻿namespace Tippspiel_Benutzerclient.Sources.Models
{
    public class SeasonBettorEntry
    {
        public int Placement { get; set; } = 0;
        public string Nickname { get; set; } = "";
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Points { get; set; } = "";
        public int TempPoints { get; set; } = 0;
    }
}