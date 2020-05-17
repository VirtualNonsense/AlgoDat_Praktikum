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

            //bin zu dämlich für die unit tests
            int[] nums = { 1, 2, 3, 4, 4, 5, };
            MultiSetSortedLinkedList testlist = new MultiSetSortedLinkedList();
            foreach (int  item in nums)
            {
                testlist.Insert(item);
            }
            testlist.Print();

            Console.WriteLine("deleting root");
            testlist.Delete(1);
            testlist.Print();

            Console.WriteLine("deleting inbetween");
            testlist.Delete(4);

            testlist.Print();

            Console.WriteLine("deleting last");
            testlist.Delete(5);

            testlist.Print();

            SetUnSortedLinkedList setun = new SetUnSortedLinkedList();
            setun.Insert(100);

            setun.Print();

            IDictionary listone = new SetUnSortedLinkedList();
            listone.Insert(200);
            listone.Print();

        }
    }
}
