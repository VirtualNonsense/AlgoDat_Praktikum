using AlgoDatDictionaries.Lists;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Xml;

namespace AlgoDatDictionaries.Lists
{
    public enum Case
    {
        Default, //= 0,
        SmallerFirst //= 1
        // None (if you like)
    }
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
            return search(num).Item2;       // Just return bool as task demands
        }
        public (llnode, bool, Case) search(int num)  // added Enum, cause we need one more case for smaller than first
        {
            llnode find = First;
            (llnode, bool, Case) gothroughMarker = (null, false, Case.Default); // Necessary for not sorted Multiset; e.g.: 1 100 1 1 1 1 80 input: 80
            
            // Empty List
            if (First == null)
            {
                return (null, false, Case.SmallerFirst); // Enum None (if you like)
            }

            // One Element in List
            if (num == First.Key)
            {
                return (First, true, Case.Default);
            }

            // More Elements in List
            while (find.Next != null)
            {
                // We'll watch the successors 
                // If searched num is successor it returns predecessor and bool => node was found 
                if (find.Next.Key == num)
                {
                    return (find, true, Case.Default);
                }

                // Haven't found it yet, mark the place where it (would) belong. Don't return it immediately, go through List,
                // 'cause it's needed for not sorted Multisets; e.g.: 1 100 1 1 1 1 80 input: 80
                // For Lucas: Can put that into Insert function (If you like...)
                if (num > find.Key && num < find.Next.Key)
                {
                    gothroughMarker = (find, false, Case.Default);
                }
                find = find.Next;
            }

            // After it wasn't found, check if smaller than first element
            if (num < First.Key)
            {
                return (null, false, Case.SmallerFirst);
            }

            // After it wasn't found, check if bigger than last element
            if (num > find.Key)
            {
                return (find, false, Case.Default);
            }
            return gothroughMarker;
        }

        // Insert
        protected bool Insert(bool multi, bool sorted, int num)
        {
            (llnode insertnode, bool found, Case cases) = search(num);
           
            // Not possible
            if (multi == false && found == true)
            {
                return false;
            }

            // Easiest cases
            if ((multi == true && sorted == false)                      // Is a MultiSet and Unsorted => Just Prepend
                || (multi == false && sorted == false && found == false // Not Multi and Unsorted and searched num is not found => Just Prepend
                ||  cases == Case.SmallerFirst))                        // After NOTHING was found in any List variety => Just Prepend
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
            Case _case;
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
                Console.Write("List is empty");
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

        // Reset  // Does not work for instance of IDictionary. Maybe we'll put it in...
        public void Reset()
        {
            first = null;
        }
    }
}