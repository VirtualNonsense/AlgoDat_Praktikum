using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AlgoDatConsole
{
    class Banner
    {

        public static string AppBanner()
        {
            var s =   @"  _____  _      _   _                        _" + "\n" +
                      @" |  __ \(_)    | | (_)                      (_)          " + "\n" +
                      @" | |  | |_  ___| |_ _  ___  _ __   __ _ _ __ _  ___  ___ " + "\n" +
                      @" | |  | | |/ __| __| |/ _ \| '_ \ / _` | '__| |/ _ \/ __|" + "\n" +
                      @" | |__| | | (__| |_| | (_) | | | | (_| | |  | |  __/\__ \" + "\n" +
                      @" |_____/|_|\___|\__|_|\___/|_| |_|\__,_|_|  |_|\___||___/";
            return s;
        }
        
        public static void PrintBanner()
        {
            Console.WriteLine(AppBanner());
        }

        public static string ArrayBanner()
        {
            var s = @"     /\                         " + "\n" +
                    @"    /  \   _ __ _ __ __ _ _   _ " + "\n" +
                    @"   / /\ \ | '__| '__/ _` | | | |" + "\n" +
                    @"  / ____ \| |  | | | (_| | |_| |" + "\n" +
                    @" /_/    \_\_|  |_|  \__,_|\__, |" + "\n" +
                    @"                           __/ |" + "\n" +
                    @"                          |___/ " + "\n";
            return s;
        }
        public static void Printbanner1()
        {
            Console.WriteLine(ArrayBanner());
        }

        public static string ListBanner()
        {
            var s = @"  _      _       _            _ _      _     _   " + "\n" +
                    @" | |    (_)     | |          | | |    (_)   | |  " + "\n" +
                    @" | |     _ _ __ | | _____  __| | |     _ ___| |_ " + "\n" +
                    @" | |    | | '_ \| |/ / _ \/ _` | |    | / __| __|" + "\n" +
                    @" | |____| | | | |   <  __/ (_| | |____| \__ \ |_ " + "\n" +
                    @" |______|_|_| |_|_|\_\___|\__,_|______|_|___/\__|" + "\n";

            return s;
        }
        public static void Printbanner2()
        {
            Console.WriteLine(ListBanner());
        }

        public static string BinTreeBanner()
        {
            var s = @"  ____  _                     _______            " + "\n" +
                    @" |  _ \(_)                   |__   __|           " + "\n" +
                    @" | |_) |_ _ __   __ _ _ __ _   _| |_ __ ___  ___ " + "\n" +
                    @" |  _ <| | '_ \ / _` | '__| | | | | '__/ _ \/ _ \" + "\n" +
                    @" | |_) | | | | | (_| | |  | |_| | | | |  __/  __/" + "\n" +
                    @" |____/|_|_| |_|\__,_|_|   \__, |_|_|  \___|\___|" + "\n" +
                    @"                            __/ |                " + "\n" +
                    @"                           |___/                 " + "\n";
            return s;
        }
        public static void Printbanner3()
        {
            Console.WriteLine(BinTreeBanner());
        }

        public static string AVLBanner()
        {
            var s = @"      __      ___   _______            " + "\n" +
                    @"     /\ \    / / | |__   __|           " + "\n" +
                    @"    /  \ \  / /| |    | |_ __ ___  ___ " + "\n" +
                    @"   / /\ \ \/ / | |    | | '__/ _ \/ _ \" + "\n" +
                    @"  / ____ \  /  | |____| | | |  __/  __/" + "\n" +
                    @" /_/    \_\/   |______|_|_|  \___|\___|" + "\n";
            return s;
        }
        public static void Printbanner4()
        {
            Console.WriteLine(AVLBanner());
        }

        public static string TreapBanner()
        {
            var s = @"  _______                   " + "\n" +
                    @" |__   __|                  " + "\n" +
                    @"    | |_ __ ___  __ _ _ __  " + "\n" +
                    @"    | | '__/ _ \/ _` | '_ \ " + "\n" +
                    @"    | | | |  __/ (_| | |_) |" + "\n" +
                    @"    |_|_|  \___|\__,_| .__/ " + "\n" +
                    @"                     | |    " + "\n" +
                    @"                     |_|    " + "\n";
            return s;
        }
        public static void Printbanner5()
        {
            Console.WriteLine(TreapBanner());
        }

        public static string HashBanner()
        {
            var s = @"  _    _           _     " + "\n" +
                    @" | |  | |         | |    " + "\n" +
                    @" | |__| | __ _ ___| |__  " + "\n" +
                    @" |  __  |/ _` / __| '_ \ " + "\n" +
                    @" | |  | | (_| \__ \ | | |" + "\n" +
                    @" |_|  |_|\__,_|___/_| |_|" + "\n";
            return s;

        }
        public static void Printbanner6()
        {
            Console.WriteLine(HashBanner());
            
        }

        public static string MultisetBanner()
        {
            var s = @"  __  __       _ _   _          _   " + "\n" +
                    @" |  \/  |     | | | (_)        | |  " + "\n" +
                    @" | \  / |_   _| | |_ _ ___  ___| |_ " + "\n" +
                    @" | |\/| | | | | | __| / __|/ _ \ __|" + "\n" +
                    @" | |  | | |_| | | |_| \__ \  __/ |_ " + "\n" +
                    @" |_|  |_|\__,_|_|\__|_|___/\___|\__|" + "\n";
            return s;
        }

        public static string MultisetsortedBanner()
        {
            var s = @"  __  __       _ _   _          _    _____            _           _ " + "\n" +
                    @" |  \/  |     | | | (_)        | |  / ____|          | |         | |" + "\n" +
                    @" | \  / |_   _| | |_ _ ___  ___| |_| (___   ___  _ __| |_ ___  __| |" + "\n" +
                    @" | |\/| | | | | | __| / __|/ _ \ __|\___ \ / _ \| '__| __/ _ \/ _` |" + "\n" +
                    @" | |  | | |_| | | |_| \__ \  __/ |_ ____) | (_) | |  | ||  __/ (_| |" + "\n" +
                    @" |_|  |_|\__,_|_|\__|_|___/\___|\__|_____/ \___/|_|   \__\___|\__,_|" + "\n";
            return s;
        }

        public static string SetBanner()
        {
            var s = @"   _____      _   " + "\n" +
                    @"  / ____|    | |  " + "\n" +
                    @" | (___   ___| |_ " + "\n" +
                    @"  \___ \ / _ \ __|" + "\n" +
                    @"  ____) |  __/ |_ " + "\n" +
                    @" |_____/ \___|\__|" + "\n";
            return s;
        }

        public static string SetsortedBanner()
        {
            var s = @"   _____      _    _____            _           _ " + "\n" +
                    @"  / ____|    | |  / ____|          | |         | |" + "\n" +
                    @" | (___   ___| |_| (___   ___  _ __| |_ ___  __| |" + "\n" +
                    @"  \___ \ / _ \ __|\___ \ / _ \| '__| __/ _ \/ _` |" + "\n" +
                    @"  ____) |  __/ |_ ____) | (_) | |  | ||  __/ (_| |" + "\n" +
                    @" |_____/ \___|\__|_____/ \___/|_|   \__\___|\__,_|" + "\n";
            return s;
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
