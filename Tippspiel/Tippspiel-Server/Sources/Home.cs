using System;
using Tippspiel_Server.Database;

namespace Tippspiel_Server
{
    public class Home
    {
        static void Main(string[] args)
        {
            Database.Database.InitializeDatabase();
        }

    }
}