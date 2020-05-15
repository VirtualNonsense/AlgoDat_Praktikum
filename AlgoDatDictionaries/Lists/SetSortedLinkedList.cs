using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class SetSortedLinkedList : MultiSetSortedLinkedList
    {
        public override bool Insert(int num)
        {
            return Insert(false, true, num);
        }
    }
}
