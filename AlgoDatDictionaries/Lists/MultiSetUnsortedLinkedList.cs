using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class MultiSetUnsortedLinkedList:ServiceLinkedList, IMultiSet
    {
        public virtual bool Insert(int num)
        {
            return Insert(true, false, num);
        }     
    }
}
