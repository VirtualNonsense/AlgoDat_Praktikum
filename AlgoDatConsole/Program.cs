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
            Console.WriteLine("Mulltisetunsorted");
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



            //Multisetsorted tests
            Console.WriteLine("Multisetsorted");
            MultiSetSortedLinkedList multisetsorted = new MultiSetSortedLinkedList();
            multisetsorted.Prepend(5);
            multisetsorted.Prepend(5);
            multisetsorted.Prepend(4);
            multisetsorted.Prepend(4);
            multisetsorted.Prepend(2);
            multisetsorted.Prepend(1);

            multisetsorted.Print();

            Console.WriteLine(multisetsorted.Search(1));
            Console.WriteLine(multisetsorted.Search(3));

            multisetsorted.Insert(3);
            multisetsorted.Insert(6);
            multisetsorted.Insert(1);
            multisetsorted.Insert(100);

            multisetsorted.Print();




            ////SetUnsorted Test
            Console.WriteLine("Setunsorted");
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

            setUnsorted.Print();




            //SetSorted Tests
            Console.WriteLine("setsorted"); //passt noch nicht!
            SetSortedLinkedList setSorted = new SetSortedLinkedList();
            setSorted.Prepend(100);
            setSorted.Prepend(87);
            setSorted.Prepend(46);
            setSorted.Prepend(45);
            setSorted.Prepend(36);
            setSorted.Prepend(1);

            setSorted.Print();

            setSorted.Insert(2);
            setSorted.Insert(99);
            setSorted.Insert(200);
            setSorted.Insert(46);


            setSorted.Print();



            Console.ReadKey();


        }
    }
}
