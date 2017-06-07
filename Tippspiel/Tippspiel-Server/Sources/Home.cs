

using System;

namespace Tippspiel_Server.Sources
{
    public class Home
    {

        public static bool DEBUG { get; } = false;

        static void Main()
        {
            Database.Database.InitializeDatabase();
            Service.Service.InitializeService();

            Console.WriteLine("Press Any Key To Exit");
            Console.Read();

            Service.Service.ShutdownService();
        }

    }
}