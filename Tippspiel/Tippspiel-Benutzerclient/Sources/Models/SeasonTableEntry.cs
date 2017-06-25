using System.Windows;
using Tippspiel_Benutzerclient.ServiceReference;

namespace Tippspiel_Benutzerclient.Sources.Models
{
    public class SeasonTableEntry
    {
        public int Placement { get; set; } = 0;
        public string Teamname { get; set; } = "";
        public int AmountMatches { get; set; } = 0;
        public int AmountWon { get; set; } = 0;
        public GridLength WonRatio { get; set; } = GridLength.Auto;
        public int AmountDraw { get; set; } = 0;
        public GridLength DrawRatio { get; set; } = GridLength.Auto;
        public int AmountLost { get; set; } = 0;
        public GridLength LostRatio { get; set; }  = GridLength.Auto;
        public int TempGoalDifference { get; set; } = 0;
        public string GoalDifference { get; set; } = "";
        public int TempPoints { get; set; } = 0;
        public string Points { get; set; } = "";
    }
}