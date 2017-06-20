using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources.XML
{
    public class XmlController
    {

        public static ServiceClient Service = WcfHelper.ServiceClient;

        public static List<MatchMessage> ReadXml(string path)
        {
            List<MatchMessage> matches = new List<MatchMessage>();

            XmlMatchDay matchDay;

            var serializer = new XmlSerializer(typeof(XmlMatchDay));

            using (var stream = new FileStream(path, FileMode.Open))
            {
                matchDay = serializer.Deserialize(stream) as XmlMatchDay;
            }

            if (matchDay == null)
            {
                OnError("Das XML ist null oder leer");
            }
            else
            {
                foreach (var xmlMatch in matchDay.Spiel)
                {
                    TeamMessage homeTeam = Service.GetTeamByName(xmlMatch.Heim.Name);
                    if (homeTeam == null)
                    {
                        OnError("Die Heimmannschaft "+xmlMatch.Heim.Name+ "existiert nicht!");
                        break;
                    }
                    TeamMessage awayTeam = Service.GetTeamByName(xmlMatch.Auswaerts.Name);
                    if (awayTeam == null)
                    {
                        OnError("Die Auswärtsmannschaft " + xmlMatch.Auswaerts.Name + "existiert nicht!");
                        break;
                    }
                    MatchMessage match = new MatchMessage()
                    {
                        AwayTeamId = awayTeam.Id,
                        AwayTeamScore = xmlMatch.Auswaerts.Tore,
                        DateTime = DateTime.Parse(xmlMatch.Datum+"T"+xmlMatch.Beginn),
                        HomeTeamId = homeTeam.Id,
                        HomeTeamScore = xmlMatch.Heim.Tore
                    };
                    matches.Add(match);
                }
            }
            

            return matches;
        }

        public static void OnError(string errorMsg)
        {
            MessageBox.Show("Es sind folgende Fehler bei dem XML einlesen aufgetreten:\n" + errorMsg,
                "Fehler beim XML Einlesen", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}