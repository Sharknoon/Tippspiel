using System;
using System.ServiceModel;

namespace Tippspiel_Server.Sources.Services
{
    public class Service
    {
        private static ServiceHost host;

        public static void InitializeServices()
        {
            host = new ServiceHost(typeof(SeasonService));

            host.Open();

            Console.WriteLine("Service is up and running");
        }

        public static void ShutdownServices()
        {
            host.Close();
        }
    }
}