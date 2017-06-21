using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using FluentNHibernate.Conventions;
using Tippspiel_Verwaltungsclient.ServiceReference;
using Tippspiel_Verwaltungsclient.Sources.Windows;
using Tippspiel_Verwaltungsclient.Sources.XML;

namespace Tippspiel_Verwaltungsclient.Sources.Controller
{
    public class XmlFileChooseController
    {
        public static XmlFileChooseWindow XmlFileChooseWindow;
        public static string FileName;
        public static int MatchDay;
        public static SeasonMessage Season;

        public static List<MatchMessage> XmlContent = new List<MatchMessage>();

        public static void Start(int matchDay, SeasonMessage season)
        {
            MatchDay = matchDay;
            Season = season;
            XmlFileChooseWindow = new XmlFileChooseWindow();
            XmlFileChooseWindow.ShowDialog();
        }

        public static void ChooseFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".xml",
                Filter =
                    "XML Dateien (*.xml)|*.xml"
            };

            var result = dialog.ShowDialog();
 
            if (result != true) return;

            FileName = dialog.FileName;

            XmlFileChooseWindow.Text = FileName;
        }

        public static void CancelChoosing()
        {
            XmlFileChooseWindow.Close();
        }

        public static void FinsishChoosing()
        {
            if (FileName != null)
            {
                WaitingWindow waiting = new WaitingWindow();
                waiting.Show();
                XmlContent = XmlController.ReadXml(FileName);
                if (XmlContent.IsNotEmpty())
                {
                    Dictionary<int, TeamMessage> teams = WcfHelper.ServiceClient.GetAllTeams()
                        .ToDictionary(team => team.Id, team => team);

                    var errors = "";
                    foreach (var matchMessage in XmlContent)
                    {
                        if (!teams[matchMessage.AwayTeamId].SeasonIDs.Contains(Season.Id) ||
                            !teams[matchMessage.HomeTeamId].SeasonIDs.Contains(Season.Id))
                        {
                            if (!teams[matchMessage.AwayTeamId].SeasonIDs.Contains(Season.Id))
                            {
                                errors += "Die Auswärtsmannschaft "+teams[matchMessage.AwayTeamId].Name+" befindet sich nicht in der Saison "+Season.Name+"\n";
                            }
                            if (!teams[matchMessage.HomeTeamId].SeasonIDs.Contains(Season.Id))
                            {
                                errors += "Die Heimmannschaft " + teams[matchMessage.HomeTeamId].Name + " befindet sich nicht in der Saison " + Season.Name + "\n";
                            }
                            continue;
                        }
                        matchMessage.MatchDay = MatchDay;
                        matchMessage.SeasonId = Season.Id;
                        errors += WcfHelper.ServiceClient.CreateMatch(matchMessage);
                    }
                    waiting.Close();
                    if (errors.IsNotEmpty())
                    {
                        MessageBox.Show("Es sind folgende Fehler bei dem XML-Import aufgetreten:\n" + errors,
                            "Fehler bei dem XML-Import", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                waiting.Close();
                XmlFileChooseWindow.Close();
            }
            else
            {
                MessageBox.Show("Bitte vorher eine XML-Datei auswählen!",
                    "Fehler bei dem XML-Import", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}