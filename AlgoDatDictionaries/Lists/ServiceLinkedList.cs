using AlgoDatDictionaries.Lists;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace AlgoDatDictionaries.Lists
{
    public abstract class ServiceLinkedList
    {
        bool Set = false;
        // Properties

        public llnode first = null;
        
        public llnode First
        {
            get { return first; }
            set { first = value; }
        }


        // Methods
        public bool Search(int num)
        {
            return search(num).Item2;
        }
        public (llnode, bool) search(int num) //test
        {
            llnode searchNum = First;
            
            if (searchNum == null)
            {
                return (null, false);
            }
            if (searchNum.Key == num) //changed first to searchnum
            {
                return (searchNum,true); // ""-""
            }

            if (searchNum.Next == null)
            {
                if (num < searchNum.Key)
                {
                    return (null, false);
                }
                else
                {
                    return (searchNum, false);
                }
            }

            while (searchNum.Next != null)
            {
                if (searchNum.Next.Key == num)
                {
                    return (searchNum, true);
                }
                if (searchNum.Next.Key > num) //&& Set == true
                {
                    return (searchNum, false);
                }
                searchNum = searchNum.Next;
            }
            return (searchNum, false);
        }
        public void Print()
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

        public void Prepend(int num)
        {
            llnode newNode = new llnode(num, First);

            first = newNode;
        }
    }
}
