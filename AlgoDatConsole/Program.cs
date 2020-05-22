using System;
using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Arrays;
using AlgoDatDictionaries;

namespace AlgoDatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;

            do // Outer Loop - Dictionary
            {
                Console.Clear();
                Menu.PrintBanner();
                Menu.PrintSuggestions();
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    do // Inner Loop Array
                    {

                    } while (input.Key != ConsoleKey.Backspace);

                }
                if (input.Key == ConsoleKey.D2)
                {
                    do // Inner Loop Lists
                    { 

                    } while (input.Key != ConsoleKey.Backspace);
                }
                if (input.Key == ConsoleKey.D3)
                {
                    do // Inner Loop Binary Search Tree
                    {

                    } while (input.Key != ConsoleKey.Backspace);
                }
                if (input.Key == ConsoleKey.D4)
                {
                    do // Inner Loop AVL
                    {

                    } while (input.Key != ConsoleKey.Backspace);
                }
                if (input.Key == ConsoleKey.D5)
                {
                    do // Inner Loop Treap
                    {

                    } while (input.Key != ConsoleKey.Backspace);
                }
                if (input.Key == ConsoleKey.D6)
                {
                    do // Inner Loop Hash
                    {

                    } while (input.Key != ConsoleKey.Backspace);
                }


                //input = Console.ReadKey();

            } while (input.Key != ConsoleKey.Escape);

            
        }
    }
}
