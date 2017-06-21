﻿using System;
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
                        OnError("Die Heimmannschaft "+xmlMatch.Heim.Name+ " existiert nicht!");
                        break;
                    }
                    List<TeamMessage> awayTeamList = Service.GetTeamByName(xmlMatch.Auswaerts.Name).ToList();
                    if (awayTeamList.IsEmpty())
                    {
                        OnError("Die Auswärtsmannschaft " + xmlMatch.Auswaerts.Name + " existiert nicht!");
                        break;
                    }
                    MatchMessage match = new MatchMessage()
                    {
                        AwayTeamId = awayTeamList.First().Id,
                        AwayTeamScore = xmlMatch.Auswaerts.Tore,
                        DateTime = DateTime.Parse(xmlMatch.Datum+"T"+xmlMatch.Beginn),
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