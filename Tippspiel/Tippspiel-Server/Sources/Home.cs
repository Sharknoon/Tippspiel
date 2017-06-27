

using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Transform;
using Tippspiel_Server.Sources.Database.Helper;
using Tippspiel_Server.Sources.Models;
using Tippspiel_Server.Sources.Service.Models;

namespace Tippspiel_Server.Sources
{
    public class Home
    {
        public static bool DEBUG { get; } = false;

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