using System;
using System.Collections.Generic;
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
        public static int SeasonId;

        public static List<MatchMessage> XmlContent = new List<MatchMessage>();

        public static void Start(int matchDay, int seasonId)
        {
            MatchDay = matchDay;
            SeasonId = seasonId;
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
                XmlContent = XmlController.ReadXml(FileName);
                if (XmlContent.IsNotEmpty())
                {
                    var errors = "";
                    foreach (var matchMessage in XmlContent)
                    {
                        matchMessage.MatchDay = MatchDay;
                        matchMessage.SeasonId = SeasonId;
                        errors += WcfHelper.ServiceClient.CreateMatch(matchMessage);
                    }
                    if (errors.IsNotEmpty())
                    {
                        MessageBox.Show("Es sind folgende Fehler bei dem XML-Import aufgetreten:\n" + errors,
                            "Fehler bei dem XML-Import", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
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