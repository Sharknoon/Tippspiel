using System.ComponentModel;
using Tippspiel_Server.Sources.Service;

namespace Tippspiel_Verwaltungsclient.Sources
{
    public static class WcfHelper
    {
        public static ServiceReference.ServiceClient ServiceClient { get; } = new ServiceReference.ServiceClient();
    }
}