using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    class MultiSetUnsortedLinkedList:ServiceLinkedList
    {
        

        public bool Prepend(int num) // Could be func insert() -> (Multi, unsorted)
        {
            llnode newNode = new llnode(num, First);

            first = newNode;

            return true;
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

        
    }
}
