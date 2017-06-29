using System;

namespace Tippspiel_Server.Sources
{
    public class Home
    {
        public static bool Debug { get; } = false;

        private static void Main()
        {
            Console.WriteLine("Server booting...");

            Database.Database.InitializeDatabase();
            Service.Service.InitializeService();

            Console.WriteLine("Server booted, press <Enter> To Exit");
            Console.Read();

            Service.Service.ShutdownService();
        }
    }
}