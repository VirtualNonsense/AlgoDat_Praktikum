using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class SetUnsortedLinkedList:MultiSetUnsortedLinkedList , ISet
    {
        public override bool Insert(int num)
        {
            return Insert(false, false, num);
        }    
    }
}
