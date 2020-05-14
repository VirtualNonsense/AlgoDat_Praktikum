using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class SetUnSortedLinkedList:ServiceLinkedList
    {
        public bool Prepend(int num) // Could be func insert() -> (unsorted)
        {
            if (Search(num) == false)
            {
                llnode newNode = new llnode(num, First);

                first = newNode;

                return true;
            }
            return false;
        }

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

        public void Print()
        {
            llnode output = First;

            while (output != null)
            {
                Console.Write(output.Key + " ");

                output = output.Next;
            }
            Console.WriteLine();
        }
    }
}
