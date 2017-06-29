using Tippspiel_Verwaltungsclient.ServiceReference;

namespace Tippspiel_Verwaltungsclient.Sources
{
    public static class WcfHelper
    {
        public static ServiceClient ServiceClient { get; } = new ServiceClient();
    }
}