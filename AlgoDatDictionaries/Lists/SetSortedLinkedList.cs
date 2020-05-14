using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class SetSortedLinkedList :ServiceLinkedList
    {
        

        public bool Search(int num)
        {
            llnode searchNum = First;

            while (searchNum != null)
            {
                if (searchNum.Key == num)
                {
                    return true;
                }
                searchNum = searchNum.Next;
            }
            return false;
        }

        public bool Insert(int num) // Clumsy...
        {
            if (Search(num) == false)
            {
                llnode x = First;

                // First Knot
                if (num <= First.Key)
                {
                    Prepend(num);

                    return true;
                }

                // Inbetween Knots
                while (x.Next != null)
                {
                    if (num >= x.Key && num <= x.Next.Key)
                    {
                        llnode newNode = new llnode(num, x.Next);

                        x.Next = newNode;

                        return true;
                    }
                    x = x.Next;
                }

                // Last Knot
                while (x.Next != null)
                {
                    x = x.Next;
                }

                llnode newNode2 = new llnode(num, null);

                x.Next = newNode2;

                return true;
            }
            return false;
        }

        


        public void Prepend(int num)
        {
            llnode newNode = new llnode(num, First);

            first = newNode;
        }
    }
}
