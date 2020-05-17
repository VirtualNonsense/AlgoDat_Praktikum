using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class MultiSetSortedLinkedList:ServiceLinkedList , IMultiSetSorted
    {
        public virtual bool Insert(int num)
        {
            return Insert(true, true, num);
        }
    }
}