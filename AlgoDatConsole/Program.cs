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

            ////Multisetunsorted tests

            //MultiSetUnsortedLinkedList multiSetUnsorted = new MultiSetUnsortedLinkedList();
            //multiSetUnsorted.Prepend(7);
            //multiSetUnsorted.Prepend(6);
            //multiSetUnsorted.Prepend(3);
            //multiSetUnsorted.Prepend(4);
            //multiSetUnsorted.Prepend(3);
            //multiSetUnsorted.Prepend(2);

            //multiSetUnsorted.Print();

            //Console.WriteLine(multiSetUnsorted.Search(3));
            //Console.WriteLine(multiSetUnsorted.Search(10));



            ////Multisetsorted tests

            //MultiSetSortedLinkedList multisetsorted = new MultiSetSortedLinkedList();
            //multisetsorted.Prepend(5);
            //multisetsorted.Prepend(5);
            //multisetsorted.Prepend(4);
            //multisetsorted.Prepend(4);
            //multisetsorted.Prepend(2);
            //multisetsorted.Prepend(1);

            //multisetsorted.Print();

            //Console.WriteLine(multisetsorted.Search(1));
            //Console.WriteLine(multisetsorted.Search(3));

            //multisetsorted.Insert(3);
            //multisetsorted.Insert(6);
            //multisetsorted.Insert(1);
            //multisetsorted.Insert(100);

            //multisetsorted.Print();




            ////SetUnsorted Test

            //SetUnsortedLinkedList setUnsorted = new SetUnsortedLinkedList();
            //setUnsorted.Prepend(45);
            //setUnsorted.Prepend(46);
            //setUnsorted.Prepend(100);
            //setUnsorted.Prepend(1);
            //setUnsorted.Prepend(87);
            //setUnsorted.Prepend(36);

            //setUnsorted.Print();

            //setUnsorted.Prepend(100);
            //setUnsorted.Prepend(89);
            //setUnsorted.Prepend(45);

            //setUnsorted.Print();




            //SetSorted Tests

            SetSortedLinkedList setSorted = new SetSortedLinkedList();
            setSorted.Prepend(100);
            setSorted.Prepend(87);
            setSorted.Prepend(46);
            setSorted.Prepend(45);
            setSorted.Prepend(36);
            setSorted.Prepend(1);

            setSorted.PrintList();

            setSorted.Insert(2);
            setSorted.Insert(99);
            setSorted.Insert(200);
            setSorted.Insert(46);

            setSorted.PrintList();

            Console.ReadKey();


        }
    }
}
