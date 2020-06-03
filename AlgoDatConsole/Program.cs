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
            ConsoleKeyInfo CaseInput;
            ConsoleKeyInfo input3;
            

            while(true) // Outer Loop - Dictionary
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
                                
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
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
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }
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
                            int inputint;
                            try
                            {
                                inputint = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Input is not an Integer, press any key and repeat");
                                Console.ReadKey();
                                continue;
                            }
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
                            int inputint;
                            try
                            {
                                inputint = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Input is not an Integer, press any key and repeat");
                                Console.ReadKey();
                                continue;
                            }
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
                            int inputint;
                            try
                            {
                                inputint = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Input is not an Integer, press any key and repeat");
                                Console.ReadKey();
                                continue;
                            }
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
                    Treap treap = new Treap();
                    do // Inner Loop Treap
                    {
                        Console.Clear();
                        Menu.Printbanner5();
                        Menu.PrintOperationSuggestions();
                        input2 = Console.ReadKey();
                        if (input2.Key == ConsoleKey.S)
                        {
                            Menu.PrintSearchSuggestions();
                            Console.WriteLine();
                            int inputint;
                            try
                            {
                                inputint = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Input is not an Integer, press any key and repeat");
                                Console.ReadKey();
                                continue;
                            }
                            bool success = treap.Search(inputint);
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
                            while (true) //1 rng , 2 own
                            {
                                Console.WriteLine();
                                Console.WriteLine("Press 1 for random Priorities or 2 for own Priorities");
                                CaseInput = Console.ReadKey();
                                if (CaseInput.Key != ConsoleKey.D1 && CaseInput.Key != ConsoleKey.D2)
                                {
                                    Console.WriteLine("you did not press 1 or 2, press any key and try again");
                                    Console.ReadKey();
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while(true)
                            {
                                Console.Clear();
                                Menu.Printbanner5();
                                Menu.PrintInsertSuggestions();
                                Console.WriteLine();
                                int inputint;
                                try
                                {
                                    inputint = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Input is not an Integer, press any key and repeat");
                                    Console.ReadKey();
                                    continue;
                                }

                                bool success = false;
                                if (CaseInput.Key == ConsoleKey.D1)
                                {
                                    success = treap.Insert(inputint);
                                }
                                else
                                {
                                    int inputprio;
                                    while (true)
                                    {
                                        Console.WriteLine("enter your priority as Integer: ");
                                        try
                                        {
                                            inputprio = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Input is not an Integer, press any key and repeat");
                                            Console.ReadKey();
                                            continue;
                                        }
                                        break;
                                    }
                                    success = treap.Insert(inputint, inputprio);

                                }

                                if (success == true)
                                {
                                    Console.WriteLine("successfully inserted " + inputint);
                                }
                                else
                                {
                                    Console.WriteLine("could not insert" + inputint);
                                }
                                Console.WriteLine("press Backspace to escape loop");
                                input3 = Console.ReadKey();
                                if (input3.Key == ConsoleKey.Backspace)
                                {
                                    break;
                                }
                            } 
                            
                        }
                        else if (input2.Key == ConsoleKey.D)
                        {
                            Menu.PrintDeleteSuggestions();
                            Console.WriteLine();
                            int inputint;
                            try
                            {
                                inputint = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Input is not an Integer, press any key and repeat");
                                Console.ReadKey();
                                continue;
                            }
                            bool success = treap.Delete(inputint);
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
                            treap.Print();
                        }
                        Console.WriteLine("press any key to continue");
                        Console.ReadKey();
                    } while (input2.Key != ConsoleKey.Backspace);
                }
                if (input.Key == ConsoleKey.D6)
                {
                    do // Inner Loop Hash
                    {

                    } while (input.Key != ConsoleKey.Backspace);
                }


                //input = Console.ReadKey();

            }

           
        }
    }
}
