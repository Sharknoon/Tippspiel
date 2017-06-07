

using System;

namespace Tippspiel_Server.Sources
{
    public class Home
    {

        public static bool DEBUG { get; } = false;

        static void Main()
        {
            Database.Database.InitializeDatabase();
            Services.Service.InitializeServices();

            Console.WriteLine("Press Any Key To Exit");
            Console.Read();

            Services.Service.ShutdownServices();
        }

    }
}