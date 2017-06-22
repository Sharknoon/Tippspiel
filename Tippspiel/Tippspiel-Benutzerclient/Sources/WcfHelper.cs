using System.ComponentModel;
using Tippspiel_Benutzerclient.ServiceReference;

namespace Tippspiel_Benutzerclient.Sources
{
    public static class WcfHelper
    {
        public static ServiceClient ServiceClient { get; } = new ServiceClient();
    }
}