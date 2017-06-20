using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
