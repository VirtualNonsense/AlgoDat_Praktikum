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
            Console.WriteLine(" ");
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
            Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine(@"  _      _     _       ");
            Console.WriteLine(@" | |    (_)   | |      ");
            Console.WriteLine(@" | |     _ ___| |_ ___ ");
            Console.WriteLine(@" | |    | / __| __/ __|");
            Console.WriteLine(@" | |____| \__ \ |_\__ \");
            Console.WriteLine(@" |______|_|___/\__|___/");
            Console.WriteLine();
        }
        public static void Printbanner3()
        {
            Console.WriteLine();
            Console.WriteLine(@"  ____  _                     _______            ");
            Console.WriteLine(@" |  _ \(_)                   |__   __|           ");
            Console.WriteLine(@" | |_) |_ _ __   __ _ _ __ _   _| |_ __ ___  ___ ");
            Console.WriteLine(@" |  _ <| | '_ \ / _` | '__| | | | | '__/ _ \/ _ \");
            Console.WriteLine(@" | |_) | | | | | (_| | |  | |_| | | | |  __/  __/");
            Console.WriteLine(@" |____/|_|_| |_|\__,_|_|   \__, |_|_|  \___|\___|");
            Console.WriteLine(@"                            __/ |                ");
            Console.WriteLine(@"                           |___/                 ");
            Console.WriteLine();
        }
        public static void Printbanner4()
        {
            Console.WriteLine();
            Console.WriteLine(@"      __      ___   _______            ");
            Console.WriteLine(@"     /\ \    / / | |__   __|           ");
            Console.WriteLine(@"    /  \ \  / /| |    | |_ __ ___  ___ ");
            Console.WriteLine(@"   / /\ \ \/ / | |    | | '__/ _ \/ _ \");
            Console.WriteLine(@"  / ____ \  /  | |____| | | |  __/  __/");
            Console.WriteLine(@" /_/    \_\/   |______|_|_|  \___|\___|");
            Console.WriteLine();
        }
        public static void Printbanner5()
        {
            Console.WriteLine();
            Console.WriteLine(@"  _______                   ");
            Console.WriteLine(@" |__   __|                  ");
            Console.WriteLine(@"    | |_ __ ___  __ _ _ __  ");
            Console.WriteLine(@"    | | '__/ _ \/ _` | '_ \ ");
            Console.WriteLine(@"    | | | |  __/ (_| | |_) |");
            Console.WriteLine(@"    |_|_|  \___|\__,_| .__/ ");
            Console.WriteLine(@"                     | |    ");
            Console.WriteLine(@"                     |_|    ");
            Console.WriteLine();
        }
        public static void Printbanner6()
        {
            Console.WriteLine();
            Console.WriteLine(@"  _    _           _     ");
            Console.WriteLine(@" | |  | |         | |    ");
            Console.WriteLine(@" | |__| | __ _ ___| |__  ");
            Console.WriteLine(@" |  __  |/ _` / __| '_ \ ");
            Console.WriteLine(@" | |  | | (_| \__ \ | | |");
            Console.WriteLine(@" |_|  |_|\__,_|___/_| |_|");
            Console.WriteLine();
            
        }
        public static void PrintDicSuggestions()
        {
            Console.WriteLine("Press 1 for Array program");
            Console.WriteLine("Press 2 for Lists program");
            Console.WriteLine("Press 3 for Binary Tree program");
            Console.WriteLine("Press 4 for AVL Tree program");
            Console.WriteLine("Press 5 for Treaps program");
            Console.WriteLine("Press 6 for Hash Algorithm" );
            Console.WriteLine();
        }

        public static void PrintTypeSuggestion()
        {
            Console.WriteLine();
            Console.WriteLine("Press 1 for MultiSet sorted");
            Console.WriteLine("Press 2 for MultiSet unsorted");
            Console.WriteLine("Press 3 for Set Sorted");
            Console.WriteLine("Press 4 for Set unsorted");
            Console.WriteLine();
        }

        public static void PrintHashType()
        {
            Console.WriteLine();
            Console.WriteLine("Press 1 for QuadProb");
            Console.WriteLine("Press 2 for SepChain");
            Console.WriteLine();
        }
        public static void PrintOperationSuggestions()
        {
            Console.WriteLine();
            Console.WriteLine("Press S to search");
            Console.WriteLine("Press I to insert");
            Console.WriteLine("Press D to delete");
            Console.WriteLine("Press P to print");
            Console.WriteLine();
        }
        public static void PrintSearchSuggestions()
        {
            Console.WriteLine();
            Console.WriteLine("-- You selected Search --");
            Console.WriteLine("please enter the Integer you want to search:");
            Console.WriteLine();
        }
        public static void PrintInsertSuggestions()
        {
            Console.WriteLine();
            Console.WriteLine("-- You selected Insert --");
            Console.WriteLine("please enter the Integer you want to insert:");
            Console.WriteLine();
        }
        public static void PrintDeleteSuggestions()
        {
            Console.WriteLine();
            Console.WriteLine("-- You selected Delete --");
            Console.WriteLine("please enter the integer you want to delete");
            Console.WriteLine();
        }
        public static void PrintPrintMessage()
        {
            Console.WriteLine();
            Console.WriteLine("-- You selected Print --");
            Console.WriteLine();
        }

        

    }
}
