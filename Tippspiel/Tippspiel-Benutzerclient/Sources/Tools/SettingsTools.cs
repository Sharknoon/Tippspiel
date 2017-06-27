using System.Collections.Generic;
using System.Linq;
using Tippspiel_Benutzerclient.ServiceReference;

namespace Tippspiel_Benutzerclient.Sources.Tools
{
    public class SettingsTools
    {
        public static List<SeasonMessage> GetSeasons()
        {
            return Tools.Seasons.Values.ToList();
        }
    }
}