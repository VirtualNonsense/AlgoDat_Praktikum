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
        public (llnode, bool, int) search(int num)  // added int, cause we need one more case for smaller than first ((null, true) is rude)
        {
            llnode find = First;
            (llnode, bool, int) gothroughMarker = (null, false, 0); // Necessary for not sorted Multiset; e.g.: 1 100 1 1 1 1 80 input: 80

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
                     gothroughMarker = (find, false, 0);
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
            return gothroughMarker;
        }

        // Insert
        protected bool Insert(bool multi, bool sorted, int num)
        {
            (llnode insertnode, bool found, int before) = search(num);
           
            // Not possible
            if (multi == false && found == true)
            {
                return false;
            }

            // Easiest cases
            if ((multi == true && sorted == false) || (multi == false && sorted == false && found == false ||  before == -1))
            {
                Prepend(num);
                return true;
            }

            // Inbetween Inputs
            llnode newNode = new llnode(num, insertnode.Next);
            insertnode.Next = newNode;
            return true;
        }

        public bool Delete(int value)
        {
            llnode foundnode;
            int _case;
            bool found;

            (foundnode, found, _case) = search(value);

            if (found == false) // Node not found  => do nothing
            {
                return false;   
            }
            else if (first.Key == value) // Special case : Root is the value
            {
                first = first.Next;
                return true;
            }
            else        // Inbetween nodes
            {
                llnode temp = foundnode.Next.Next;
                foundnode.Next = temp;
                return true;
            }
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