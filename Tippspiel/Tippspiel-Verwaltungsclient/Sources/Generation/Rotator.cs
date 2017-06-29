using System.Collections.Generic;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Generation
{
    public class Rotator
    {
        public List<TeamMessage> BottomRow = new List<TeamMessage>(); //8
        public List<TeamMessage> Left = new List<TeamMessage>(); //2
        public List<TeamMessage> Right = new List<TeamMessage>(); //2
        public List<TeamMessage> TopRow = new List<TeamMessage>(); //8

        public static Rotator CreateRotator(List<TeamMessage> teams)
        {
            var bottomRow = teams.GetRange(9, 8);
            bottomRow.Reverse();
            var rot = new Rotator
            {
                TopRow = teams.GetRange(0, 8),
                BottomRow = bottomRow,
                Right = new List<TeamMessage>(2) {teams[8], teams[17]}
            };
            return rot;
        }

        public Dictionary<TeamMessage, TeamMessage> GetTeamPairs()
        {
            var pairs = new Dictionary<TeamMessage, TeamMessage>();
            if (Left.Count == 2)
                pairs.Add(Left[0], Left[1]);

            if (TopRow.Count == 8 && BottomRow.Count == 8)
                for (var i = 0; i < 8; i++)
                    pairs.Add(TopRow[i], BottomRow[i]);

            if (Right.Count == 2)
                pairs.Add(Right[0], Right[1]);
            return pairs;
        }

        public void Rotate()
        {
            if (Right.Count == 2) //Rotate top left
            {
                Left.Add(Right[1]);
                Left.Add(TopRow[0]);
                TopRow.RemoveAt(0);
                TopRow.Add(Right[0]);
                Right.Clear();
            }
            else //Rotate bottom right
            {
                Right.Add(BottomRow[7]);
                Right.Add(Left[0]);
                BottomRow.RemoveAt(7);
                BottomRow.Insert(0, Left[1]);
                Left.Clear();
            }
        }
    }
}