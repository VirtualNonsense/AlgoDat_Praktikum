using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AlgoDatConsole
{
    class Menu
    {
        public static void PrintBanner()
        {
            Console.WriteLine(@"  _____  _      _   _                        _");
            Console.WriteLine(@" |  __ \(_)    | | (_)                      (_)          ");
            Console.WriteLine(@" | |  | |_  ___| |_ _  ___  _ __   __ _ _ __ _  ___  ___ ");
            Console.WriteLine(@" | |  | | |/ __| __| |/ _ \| '_ \ / _` | '__| |/ _ \/ __|");
            Console.WriteLine(@" | |__| | | (__| |_| | (_) | | | | (_| | |  | |  __/\__ \");
            Console.WriteLine(@" |_____/|_|\___|\__|_|\___/|_| |_|\__,_|_|  |_|\___||___/");
            Console.WriteLine();
        }

        public static void Printbanner1()
        {
            Console.WriteLine(@"                                ");
            Console.WriteLine(@"     /\                         ");
            Console.WriteLine(@"    /  \   _ __ _ __ __ _ _   _ ");
            Console.WriteLine(@"   / /\ \ | '__| '__/ _` | | | |");
            Console.WriteLine(@"  / ____ \| |  | | | (_| | |_| |");
            Console.WriteLine(@" /_/    \_\_|  |_|  \__,_|\__, |");
            Console.WriteLine(@"                           __/ |");
            Console.WriteLine(@"                          |___/ ");
            Console.WriteLine();
        }

        public static void Printbanner2()
        {

        }
        public static void Printbanner3()
        {

        }
        public static void Printbanner4()
        {

        }
        public static void Printbanner5()
        {

        }
        public static void PrintSuggestions()
        {
            Console.WriteLine("Press 1 for Array program");
            Console.WriteLine("Press 2 for Lists program");
            Console.WriteLine("Press 3 for Binary Tree program");
            Console.WriteLine("Press 4 for AVL Tree program");
            Console.WriteLine("Press 5 for Treaps program");
            Console.WriteLine("Press 6 for Hash Algorithm" );
        }



    }
}
