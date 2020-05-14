using AlgoDatDictionaries.Lists;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class testlist:ServiceLinkedList
    {
        public testlist()
        {

        }
        public testlist(llnode root)
        {
            this.root = root;
        }

        public void Append(llnode node)
        {
            llnode temp = root;
            while (temp.Next!=null)
            {
                temp = temp.Next;
            }
            temp.Next = new llnode(node.Key, null);
        }


    }
}
