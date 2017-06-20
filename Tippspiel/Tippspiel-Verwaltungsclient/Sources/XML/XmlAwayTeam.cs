using System.Xml.Serialization;

namespace Tippspiel_Verwaltungsclient.Sources.XML
{
    [XmlType("Auswaerts")]
    public class XmlAwayTeam
    {
        [XmlAttribute]
        public int Tore { get; set; }

        [XmlText]
        public string Name { get; set; }
    }
}