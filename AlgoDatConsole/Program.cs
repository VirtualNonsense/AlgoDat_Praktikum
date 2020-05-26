using System;
using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Arrays;
using AlgoDatDictionaries;
using AlgoDatDictionaries.Trees;
using System.Text;

namespace AlgoDatConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode; 
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
                                Console.WriteLine();
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
                                Console.WriteLine();
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
                                Console.WriteLine();
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
                    do // Lists decision which dictionary
                    {
                        Console.Clear();
                        Menu.Printbanner2();
                        Menu.PrintTypeSuggestion();
                        IDictionary list;
                        ConsoleKeyInfo type = Console.ReadKey();
                        if (type.Key == ConsoleKey.D1)
                        {
                            list = new MultiSetSortedLinkedList();
                        }
                        else if (type.Key == ConsoleKey.D2)
                        {
                            list = new MultiSetUnsortedLinkedList();
                        }
                        else if (type.Key == ConsoleKey.D3)
                        {
                            list = new SetSortedLinkedList();
                        }
                        else if (type.Key == ConsoleKey.D4)
                        {
                            list = new SetUnsortedLinkedList();
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
                            Menu.Printbanner2();
                            Menu.PrintOperationSuggestions();
                            input2 = Console.ReadKey();
                            if (input2.Key == ConsoleKey.S)
                            {
                                Menu.PrintSearchSuggestions();
                                Console.WriteLine();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success = list.Search(inputint);
                                if (success == true)
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
                                Console.WriteLine();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success = list.Insert(inputint);
                                if (success == true)
                                {
                                    Console.WriteLine("successfully inserted " + inputint);
                                }
                                else
                                {
                                    Console.WriteLine("could not insert" + inputint);
                                }
                            }
                            else if (input2.Key == ConsoleKey.D)
                            {
                                Menu.PrintDeleteSuggestions();
                                Console.WriteLine();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success = list.Delete(inputint);
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
                                Console.WriteLine();
                                Menu.PrintPrintMessage();
                                Console.WriteLine();
                                list.Print();
                            }
                            Console.WriteLine("press any key to continue");
                            Console.ReadKey();
                        } while (input2.Key != ConsoleKey.Backspace);

                    }
                    while (input.Key != ConsoleKey.Backspace);
                }
                if (input.Key == ConsoleKey.D3)
                {
                    do // BinaryTree decision which dictionary
                    {
                        IDictionary bintree= new BinSearchTree();
                        
                        do // Inner Loop BinaryTree
                        {
                            Console.Clear();
                            Menu.Printbanner3();
                            Menu.PrintOperationSuggestions();
                            input2 = Console.ReadKey();
                            if (input2.Key == ConsoleKey.S)
                            {
                                Menu.PrintSearchSuggestions();
                                Console.WriteLine();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success = bintree.Search(inputint);
                                if (success == true)
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
                                Console.WriteLine();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success = bintree.Insert(inputint);
                                if (success == true)
                                {
                                    Console.WriteLine("successfully inserted " + inputint);
                                }
                                else
                                {
                                    Console.WriteLine("could not insert" + inputint);
                                }
                            }
                            else if (input2.Key == ConsoleKey.D)
                            {
                                Menu.PrintDeleteSuggestions();
                                Console.WriteLine();
                                int inputint = Convert.ToInt32(Console.ReadLine());
                                bool success = bintree.Delete(inputint);
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
                                Console.WriteLine();
                                Menu.PrintPrintMessage();
                                Console.WriteLine();
                                bintree.Print();
                            }
                            Console.WriteLine("press any key to continue");
                            Console.ReadKey();
                        } while (input2.Key != ConsoleKey.Backspace);

                    }
                    while (input.Key != ConsoleKey.Backspace);
                }
                if (input.Key == ConsoleKey.D4)
                {
                    IDictionary avltree = new AVLTree();

                    do // Inner Loop AVL
                    {
                        Console.Clear();
                        Menu.Printbanner4();
                        Menu.PrintOperationSuggestions();
                        input2 = Console.ReadKey();
                        if (input2.Key == ConsoleKey.S)
                        {
                            Menu.PrintSearchSuggestions();
                            Console.WriteLine();
                            int inputint = Convert.ToInt32(Console.ReadLine());
                            bool success = avltree.Search(inputint);
                            if (success == true)
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
                            Console.WriteLine();
                            int inputint = Convert.ToInt32(Console.ReadLine());
                            bool success = avltree.Insert(inputint);
                            if (success == true)
                            {
                                Console.WriteLine("successfully inserted " + inputint);
                            }
                            else
                            {
                                Console.WriteLine("could not insert" + inputint);
                            }
                        }
                        else if (input2.Key == ConsoleKey.D)
                        {
                            Menu.PrintDeleteSuggestions();
                            Console.WriteLine();
                            int inputint = Convert.ToInt32(Console.ReadLine());
                            bool success = avltree.Delete(inputint);
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
                            Console.WriteLine();
                            Menu.PrintPrintMessage();
                            Console.WriteLine();
                            avltree.Print();
                        }
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();
                    } while (input2.Key != ConsoleKey.Backspace);
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
