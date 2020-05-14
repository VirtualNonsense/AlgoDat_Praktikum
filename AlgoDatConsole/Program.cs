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
            //testing servicelist
            testlist testlist = new testlist();
            testlist.root=(new llnode(10, null));
            testlist.Append(new llnode(10, null));
            testlist.Append(new llnode(30, null));
            testlist.Append(new llnode(40, null));
            testlist.Append(new llnode(50, null));

            testlist.PrintList();
            Console.ReadKey();



        }
    }
}
