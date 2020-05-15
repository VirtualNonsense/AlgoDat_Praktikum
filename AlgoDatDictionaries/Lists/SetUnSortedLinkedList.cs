using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class SetUnSortedLinkedList:MultiSetUnsortedLinkedList
    {
        public override bool Insert(int num)
        {
            return Insert(false, false, num);
        }    
    }
}
