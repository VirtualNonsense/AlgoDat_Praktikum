using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class MultiSetUnsortedLinkedList:ServiceLinkedList
    {
        

        public virtual bool Insert(int num)
        {
            Prepend(num);
            return true;
        }

        

        
    }
}
