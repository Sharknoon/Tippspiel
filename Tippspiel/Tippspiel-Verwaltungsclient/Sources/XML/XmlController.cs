using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
using FluentNHibernate.Conventions;
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
                    List<TeamMessage> homeTeamList = Service.GetTeamByName(xmlMatch.Heim.Name).ToList();
                    if (homeTeamList.IsEmpty())
                    {
                        OnError("Die Heimmannschaft " + xmlMatch.Heim.Name + " existiert nicht!");
                        continue;
                    }
                    List<TeamMessage> awayTeamList = Service.GetTeamByName(xmlMatch.Auswaerts.Name).ToList();
                    if (awayTeamList.IsEmpty())
                    {
                        OnError("Die Auswärtsmannschaft " + xmlMatch.Auswaerts.Name + " existiert nicht!");
                        continue;
                    }
                    if (xmlMatch.Auswaerts.Tore < 0 || xmlMatch.Heim.Tore < 0)
                    {
                        if (xmlMatch.Auswaerts.Tore < 0)
                        {
                            OnError("Die Toranzahl von " + xmlMatch.Auswaerts.Name +
                                    " (Auswärts) darf nicht negativ sein!");
                        }
                        if (xmlMatch.Heim.Tore < 0)
                        {
                            OnError("Die Toranzahl von " + xmlMatch.Heim.Name + " (Heim) darf nicht negativ sein!");
                        }
                        continue;
                    }
                    var dateString = xmlMatch.Datum + "T" + xmlMatch.Beginn;
                    var date = DateTime.Now;
                    try
                    {
                        date = DateTime.Parse(dateString);
                    }
                    catch (Exception e)
                    {
                        OnError("Das Datum oder die Uhrzeit des Spieles " + xmlMatch.Heim.Name + " gegen " +
                                xmlMatch.Auswaerts.Name +
                                " ist falsch, Datumsformat: 'yyyy-mm-dd', Zeitformat: 'hh:mm'");
                        continue;
                    }
                    MatchMessage match = new MatchMessage()
                    {
                        AwayTeamId = awayTeamList.First().Id,
                        AwayTeamScore = xmlMatch.Auswaerts.Tore,
                        DateTime = date,
                        HomeTeamId = homeTeamList.First().Id,
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