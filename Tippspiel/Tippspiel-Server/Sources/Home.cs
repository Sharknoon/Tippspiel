

using System;

namespace Tippspiel_Server.Sources
{
    public class Home
    {

        public static bool DEBUG { get; } = false;

        static void Main()
        {
            Database.Database.InitializeDatabase();
            Console.Read();
        }

    }
}