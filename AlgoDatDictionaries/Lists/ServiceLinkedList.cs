using AlgoDatDictionaries.Lists;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Xml;

namespace AlgoDatDictionaries.Lists
{
    public abstract class ServiceLinkedList
    {
        // Properties
        public llnode first = null;
        
        public llnode First
        {
            get { return first; }
            set { first = value; }
        }

        // Methods
        // Search
        public bool Search(int num)
        {
            return search(num).Item2;
        }
        public (llnode, bool, int) search(int num)  // added int, cause we need one more case
        {
            llnode find = First;

            // Empty List
            if (First == null)
            {
                return (null, false, -1);
            }

            // One Element in List
            if (num == First.Key)
            {
                return (First, true, 0);
            }

            // More Elements in List
            while (find.Next != null)
            {
                if (find.Next.Key == num)
                {
                    return (find, true, 0);
                }

                if (num > find.Key && num < find.Next.Key)
                {
                    return (find, false, 0);
                }
                find = find.Next;
            }

            // Check, after it wasn't found, if smaller than first element
            if (num < First.Key)
            {
                return (null, false, -1);
            }

            // Append
            if (num > find.Key)
            {
                return (find, false, 1);
            }
            return (null, false, 0);
        }

        // Insert
        public bool Insert(bool multi, bool sorted, int num)
        {
            (llnode insertnode, bool found, int BeforeAfter) = search(num);
           
            if (multi == false && found == true)
            {
                return false;
            }

            if ((multi == true && sorted == false) || (multi == false && sorted == false && found == false ||  BeforeAfter == -1))
            {
                Prepend(num);
                return true;
            }

            llnode newNode = new llnode(num, insertnode.Next);
            insertnode.Next = newNode;
            return true;
        }

        // Print
        public void Print()
        {
            llnode temp = First;
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

        // Prepend
        public void Prepend(int num)
        {
            llnode newNode = new llnode(num, First);

            first = newNode;
        }
    }
}