using System;
using System.Collections.Generic;
using System.Text;
using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Arrays;
using AlgoDatDictionaries;
using AlgoDatDictionaries.Trees;
using AlgoDatDictionaries.Hash;

namespace AlgoDatConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            List<List<string>> menu = new List<List<string>>()
            {
                new List<string>()
                {
                    "ISet",
                    "ISetSorted",
                    "IMultiSetSorted",
                    "IMultiSet"
                }
            };
            Demonstrator demonstrator = new Demonstrator(controller);
        }
    }
}
