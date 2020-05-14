using AlgoDatDictionaries.Lists;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AlgoDatDictionaries.Lists
{
    public abstract class ServiceLinkedList
    {
        public llnode first = null;
        
        public llnode First
        {
            get { return first; }
            set { first = value; }
        }

        public void PrintList()
        {
            llnode temp = first;
            if (temp == null)
            {
                Console.WriteLine("List is empty");
            }
            while (temp != null)
            {
                Console.Write($"{temp.Key} ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }
    }
}
