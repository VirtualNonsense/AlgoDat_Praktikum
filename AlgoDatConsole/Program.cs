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
            SetSortedArray testarray = new SetSortedArray();
            Console.WriteLine("insert 2");
            Console.WriteLine(testarray.Insert(2));
            testarray.Insert(5);
            testarray.Insert(7);
            testarray.Insert(7);
            testarray.Insert(1);
            testarray.Print();
            Console.ReadKey();
            ConsoleKeyInfo input;
            ConsoleKeyInfo input2;

            do // Outer Loop - Dictionary
            {
                Console.Clear();
                Menu.PrintBanner();
                Menu.PrintDicSuggestions();
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.D1)
                {
                    do // Array decision which dictionary
                    {
                        Console.Clear();
                        Menu.Printbanner1();
                        Menu.PrintTypeSuggestion();
                        IDictionary array;
                        ConsoleKeyInfo type = Console.ReadKey();
                        if (type.Key == ConsoleKey.D1)
                        {
                            array = new MultiSetSortedArray ();
                        }
                        else if (type.Key == ConsoleKey.D2)
                        {
                            array = new MultiSetUnsortedArray();
                        }
                        else if (type.Key == ConsoleKey.D3)
                        {
                            array = new SetSortedArray(); 
                        }
                        else if(type.Key == ConsoleKey.D4)
                        {
                            array= new SetUnsortedArray();
                        }
                        else if ((type.Key == ConsoleKey.Backspace) || (type.Key == ConsoleKey.Escape))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("input not accepted try again");
                            Console.ReadKey();
                            continue;
                        }
                            do // Inner Loop Array
                            {
                                Console.Clear();
                                Menu.Printbanner1();
                                Menu.PrintOperationSuggestions();
                                input2 = Console.ReadKey();
                            if (input2.Key == ConsoleKey.S)
                            {
                                Menu.PrintSearchSuggestions();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success=array.Search(inputint);
                                if (success ==true)
                                {
                                    Console.WriteLine("found your integer!");
                                }
                                else
                                {
                                    Console.WriteLine("Did not find your integer");
                                }

                            }
                            else if (input2.Key == ConsoleKey.I)
                            {
                                Menu.PrintInsertSuggestions();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success = array.Insert(inputint);
                                if (success == true)
                                {
                                    Console.WriteLine("successfully inserted " + inputint);
                                }
                                else
                                {
                                    Console.WriteLine("could not insert" +inputint);
                                }
                            }
                            else if (input2.Key == ConsoleKey.D)
                            {
                                Menu.PrintDeleteSuggestions();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success = array.Delete(inputint);
                                if (success == true)
                                {
                                    Console.WriteLine("successfully deleted " + inputint);
                                }
                                else
                                {
                                    Console.WriteLine("could not delete" + inputint);
                                }
                            }
                            else if (input2.Key == ConsoleKey.P)
                            {
                                Menu.PrintPrintMessage();
                                array.Print();
                            }
                            Console.WriteLine("press any key to continue");
                            Console.ReadKey();
                        } while (input2.Key != ConsoleKey.Backspace);

                    }
                    while (input.Key != ConsoleKey.Backspace);
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
