using System;
using System.Collections.Generic;
using System.Linq;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.Generation
{
    public class Rotator
    {
        public List<TeamMessage> TopRow = new List<TeamMessage>(8);
        public List<TeamMessage> BottomRow = new List<TeamMessage>(8);
        public List<TeamMessage> Left = new List<TeamMessage>(2);
        public List<TeamMessage> Right = new List<TeamMessage>(2);
    }
}