using System;

namespace Tippspiel_Server.Sources.Utils
{
    public class Logger
    {
        public static void WriteLine(string stringToPrint)
        {
            if (Home.DEBUG)
            {
                Console.WriteLine(stringToPrint);
            }
        }
    }
}