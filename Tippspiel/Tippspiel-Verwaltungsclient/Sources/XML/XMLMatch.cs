using System.Xml.Serialization;

namespace Tippspiel_Verwaltungsclient.Sources.XML
{
    [XmlType("Spiel")]
    public class XmlMatch
    {
        [XmlAttribute]
        public string Datum { get; set; } = "0001-01-01";

        [XmlAttribute]
        public string Beginn { get; set; } = "00:00";

        [XmlElement]
        public XmlHomeTeam Heim { get; set; }

        [XmlElement]
        public XmlHomeTeam Auswaerts { get; set; }
    }
}