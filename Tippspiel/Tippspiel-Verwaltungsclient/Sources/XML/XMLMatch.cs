using System;
using System.Xml.Serialization;

namespace Tippspiel_Verwaltungsclient.Sources.XML
{
    [XmlType("Spiel")]
    public class XmlMatch
    {
        [XmlAttribute]
        public string Datum { get; set; }

        [XmlAttribute]
        public string Beginn { get; set; }
        
        [XmlElement]
        public XmlHomeTeam Heim { get; set; }

        [XmlElement]
        public XmlHomeTeam Auswaerts { get; set; }
    }
}