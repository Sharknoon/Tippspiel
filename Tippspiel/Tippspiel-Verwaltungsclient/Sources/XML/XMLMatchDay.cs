using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tippspiel_Verwaltungsclient.Sources.XML
{
    [XmlRoot("Spieltag")]
    public class XmlMatchDay
    {
        [XmlElement]
        public List<XmlMatch> Spiel { get; set; }
    }
}