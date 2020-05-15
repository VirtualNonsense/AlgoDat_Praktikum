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
            // MultiSetUnsorted Tests
            Console.WriteLine("MultiSetUnSorted:");
            MultiSetUnsortedLinkedList multiSetUnsorted = new MultiSetUnsortedLinkedList();
            multiSetUnsorted.Insert(7);
            multiSetUnsorted.Insert(6);
            multiSetUnsorted.Insert(3);
            multiSetUnsorted.Insert(4);
            multiSetUnsorted.Insert(3);
            multiSetUnsorted.Insert(2);

            multiSetUnsorted.Print();

            Console.WriteLine(multiSetUnsorted.Search(3));
            Console.WriteLine(multiSetUnsorted.Search(10));
            Console.WriteLine(multiSetUnsorted.Search(7));
            Console.WriteLine(multiSetUnsorted.Search(2));

            Console.WriteLine();

            // MultiSetSorted Tests
            Console.WriteLine("MultiSetSorted:");
            MultiSetSortedLinkedList multisetsorted = new MultiSetSortedLinkedList();
            multisetsorted.Insert(5);
            multisetsorted.Insert(5);
            multisetsorted.Insert(4);
            multisetsorted.Insert(4);
            multisetsorted.Insert(2);
            multisetsorted.Insert(1);

            multisetsorted.Print();

            multisetsorted.Insert(3);
            multisetsorted.Insert(6);
            multisetsorted.Insert(1);
            multisetsorted.Insert(100);

            multisetsorted.Print();

            Console.WriteLine(multisetsorted.Search(70));
            Console.WriteLine(multisetsorted.Search(1));
            Console.WriteLine(multisetsorted.Search(5));
            Console.WriteLine(multisetsorted.Search(100));

            Console.WriteLine();

            // SetUnsorted Tests
            Console.WriteLine("SetUnSorted:");
            SetUnSortedLinkedList setUnsorted = new SetUnSortedLinkedList();
            setUnsorted.Insert(45);
            setUnsorted.Insert(46);
            setUnsorted.Insert(100);
            setUnsorted.Insert(1);
            setUnsorted.Insert(87);
            setUnsorted.Insert(36);

            setUnsorted.Print();

            setUnsorted.Insert(100);
            setUnsorted.Insert(89);
            setUnsorted.Insert(45);
            setUnsorted.Insert(87);

            setUnsorted.Print();

            Console.WriteLine(setUnsorted.Search(100));
            Console.WriteLine(setUnsorted.Search(99));
            Console.WriteLine(setUnsorted.Search(89));
            Console.WriteLine(setUnsorted.Search(45));

            Console.WriteLine();

            // SetSorted Tests
            Console.WriteLine("SetSorted:");
            SetSortedLinkedList setSorted = new SetSortedLinkedList();
            setSorted.Insert(100);
            setSorted.Insert(87);
            setSorted.Insert(46);
            setSorted.Insert(45);
            setSorted.Insert(36);
            setSorted.Insert(2);

            setSorted.Print();

            setSorted.Insert(2);
            setSorted.Insert(1);
            setSorted.Insert(99);
            setSorted.Insert(200);
            setSorted.Insert(46);

            setSorted.Print();

            Console.WriteLine(setSorted.Search(2));
            Console.WriteLine(setSorted.Search(47));
            Console.WriteLine(setSorted.Search(1));
            Console.WriteLine(setSorted.Search(200));

            Console.ReadKey();
        }
    }
}
