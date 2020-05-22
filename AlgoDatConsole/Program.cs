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
            // Sorry Leute ich will ne Ausgabe
            // Können wir verschieben in die Tests

            // Check MultiSetUnsorted
            Console.WriteLine("MultiSetUnsorted:");
            IDictionary msu = new MultiSetUnsortedLinkedList();

            Console.Write(msu.Insert(400) + " ");
            Console.Write(msu.Insert(1) + " ");
            Console.Write(msu.Insert(50) + " ");
            Console.Write(msu.Insert(2) + " ");
            Console.Write(msu.Insert(869) + " ");
            Console.Write(msu.Insert(400) + " ");
            Console.WriteLine(msu.Insert(2));

            msu.Print();

            Console.Write(msu.Search(400) + " ");
            Console.Write(msu.Search(1) + " ");
            Console.WriteLine(msu.Search(800));

            Console.Write(msu.Delete(400) + " ");
            Console.Write(msu.Delete(400) + " ");
            Console.Write(msu.Delete(1) + " ");
            Console.WriteLine(msu.Delete(500) + " ");

            msu.Print();
            Console.WriteLine();

            // Check MultiSetSorted
            Console.WriteLine("MultiSetSorted:");
            IDictionary mss = new MultiSetSortedLinkedList();

            Console.Write(mss.Insert(400) + " ");
            Console.Write(mss.Insert(2) + " ");
            Console.Write(mss.Insert(50) + " ");
            Console.Write(mss.Insert(1) + " ");
            Console.Write(mss.Insert(869) + " ");
            Console.Write(mss.Insert(400) + " ");
            Console.WriteLine(mss.Insert(2));

            mss.Print();

            Console.Write(mss.Search(400) + " ");
            Console.Write(mss.Search(1) + " ");
            Console.Write(mss.Search(800) + " ");
            Console.WriteLine(mss.Search(869));

            Console.Write(mss.Delete(400) + " ");
            Console.Write(mss.Delete(400) + " ");
            Console.Write(mss.Delete(1) + " ");
            Console.Write(mss.Delete(400) + " ");
            Console.Write(mss.Delete(859) + " ");
            Console.WriteLine(mss.Delete(500) + " ");

            mss.Print();
            Console.WriteLine();

            // Check SetUnsorted
            Console.WriteLine("SetUnsorted:");
            IDictionary su = new SetUnsortedLinkedList();

            Console.Write(su.Insert(400) + " ");
            Console.Write(su.Insert(2) + " ");
            Console.Write(su.Insert(50) + " ");
            Console.Write(su.Insert(1) + " ");
            Console.Write(su.Insert(869) + " ");
            Console.Write(su.Insert(400) + " ");
            Console.WriteLine(su.Insert(2));

            su.Print();

            Console.Write(su.Search(400) + " ");
            Console.Write(su.Search(1) + " ");
            Console.Write(su.Search(800) + " ");
            Console.WriteLine(su.Search(869));

            Console.Write(su.Delete(400) + " ");
            Console.Write(su.Delete(400) + " ");
            Console.Write(su.Delete(1) + " ");
            Console.Write(su.Delete(400) + " ");
            Console.Write(su.Delete(959) + " ");
            Console.Write(su.Delete(500) + " ");
            Console.WriteLine(su.Delete(869) + " ");

            su.Print();
            Console.WriteLine();

            // Check SetUnsorted
            Console.WriteLine("SetSorted:");
            IDictionary ss = new SetSortedLinkedList();

            Console.Write(ss.Insert(400) + " ");
            Console.Write(ss.Insert(2) + " ");
            Console.Write(ss.Insert(50) + " ");
            Console.Write(ss.Insert(50) + " ");
            Console.Write(ss.Insert(1) + " ");
            Console.Write(ss.Insert(869) + " ");
            Console.Write(ss.Insert(400) + " ");
            Console.WriteLine(ss.Insert(2));

            ss.Print();

            Console.Write(ss.Search(400) + " ");
            Console.Write(ss.Search(1) + " ");
            Console.Write(ss.Search(800) + " ");
            Console.WriteLine(ss.Search(869));

            Console.Write(ss.Delete(400) + " ");
            Console.Write(ss.Delete(400) + " ");
            Console.Write(ss.Delete(1) + " ");
            Console.Write(ss.Delete(400) + " ");
            Console.Write(ss.Delete(959) + " ");
            Console.Write(ss.Delete(500) + " ");
            Console.WriteLine(ss.Delete(869) + " ");

            ss.Print();
            Console.WriteLine();

            IDictionary dummy = new MultiSetSortedLinkedList();
            dummy.Delete(5);
            dummy.Print();


            ////bin zu dämlich für die unit tests
            //int[] nums = { 1, 2, 3, 4, 4, 5, };
            //MultiSetSortedLinkedList testlist = new MultiSetSortedLinkedList();
            //foreach (int  item in nums)
            //{
            //    testlist.Insert(item);
            //}
            //testlist.Print();

            //Console.WriteLine("deleting root");
            //testlist.Delete(1);
            //testlist.Print();

            //Console.WriteLine("deleting inbetween");
            //testlist.Delete(4);

            //testlist.Print();

            //Console.WriteLine("deleting last");
            //testlist.Delete(5);

            //testlist.Print();

            //SetUnSortedLinkedList setun = new SetUnSortedLinkedList();
            //setun.Insert(100);

            //setun.Print();

            //IDictionary listone = new SetUnSortedLinkedList();
            //listone.Insert(200);
            //listone.Insert(100);
            //listone.Insert(10);
            //listone.Insert(99);
            //listone.Insert(50);
            //listone.Insert(20);

            //listone.Print();

            //listone.Insert(10);

            //listone.Print();
        }
    }
}
