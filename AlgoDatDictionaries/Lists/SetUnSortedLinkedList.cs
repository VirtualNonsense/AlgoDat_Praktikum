using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class SetUnSortedLinkedList:MultiSetUnsortedLinkedList
    {
        public override bool Insert(int num)
        {
            if (Search(num) == true)
            {
                return false;
            }
            Prepend(num);
            return true;
        }
       
    }
}
