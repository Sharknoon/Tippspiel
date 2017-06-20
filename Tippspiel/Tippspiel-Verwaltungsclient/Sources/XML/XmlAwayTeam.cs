using System.Xml.Serialization;

namespace Tippspiel_Verwaltungsclient.Sources.XML
{
    [XmlType("Auswaerts")]
    public class XmlAwayTeam
    {
        [XmlAttribute]
        public int Tore { get; set; } = 0;

        [XmlText]
        public string Name { get; set; } = "UNBENANNTE_MANNSCHAFT";
    }
}