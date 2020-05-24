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
            //Ascii Art Lists
            Console.WriteLine(@"<ASCII LISTS here>");
        }
        public static void Printbanner3()
        {
            //Ascii Art binary tree
            Console.WriteLine(@"<ASCII BinaryTree here>");
        }
        public static void Printbanner4()
        {
            //Ascii Art AVL Tree
            Console.WriteLine(@"<ASCII AVLTree here>");
        }
        public static void Printbanner5()
        {
            //Ascii Art Treap
            Console.WriteLine(@"<ASCII TREAP here>");
        }
        public static void Printbanner6()
        {
            //Ascii Art Hash Algorithm
            Console.WriteLine(@"<ASCII Hash here>");
        }
        public static void PrintDicSuggestions()
        {
            Console.WriteLine("Press 1 for Array program");
            Console.WriteLine("Press 2 for Lists program");
            Console.WriteLine("Press 3 for Binary Tree program");
            Console.WriteLine("Press 4 for AVL Tree program");
            Console.WriteLine("Press 5 for Treaps program");
            Console.WriteLine("Press 6 for Hash Algorithm" );
        }

        public static void PrintTypeSuggestion()
        {
            Console.WriteLine("Press 1 for MultiSet sorted");
            Console.WriteLine("Press 2 for MultiSet unsorted");
            Console.WriteLine("Press 3 for Set Sorted");
            Console.WriteLine("Press 4 for Set unsorted");
        }
        public static void PrintOperationSuggestions()
        {
            Console.WriteLine("Press S to search");
            Console.WriteLine("Press I to insert");
            Console.WriteLine("Press D to delete");
            Console.WriteLine("Press P to print");
        }
        public static void PrintSearchSuggestions()
        {
            Console.WriteLine("-- You selected Search --");
            Console.WriteLine("please enter the Integer you want to search:");
            Console.WriteLine();
        }
        public static void PrintInsertSuggestions()
        {
            Console.WriteLine("-- You selected Insert --");
            Console.WriteLine("please enter the Integer you want to insert:");
            Console.WriteLine();
        }
        public static void PrintDeleteSuggestions()
        {
            Console.WriteLine("-- You selected Delete --");
            Console.WriteLine("please enter the integer you want to delete");
            Console.WriteLine();
        }
        public static void PrintPrintMessage()
        {
            Console.WriteLine("-- You selected Print --");
        }

    }
}
