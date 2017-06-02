

using System;

namespace Tippspiel_Server.Sources
{
    public class Home
    {
        static void Main()
        {
            Database.Database.InitializeDatabase();
            Console.Read();
        }

    }
}