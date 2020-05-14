using AlgoDatDictionaries.Lists;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AlgoDatDictionaries.Lists
{
    public abstract class ServiceLinkedList
    {
        public llnode root;

        public void PrintList()
        {
            llnode temp = root;
            if (temp == null)
            {
                Console.WriteLine("List is empty");
            }
            while (temp != null)
            {
                Console.Write($"{temp.Key} ");
                temp = temp.Next;
            }
        }
    }
}
