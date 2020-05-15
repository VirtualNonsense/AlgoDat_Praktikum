using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class MultiSetSortedLinkedList:ServiceLinkedList
    {

        static bool Set = false;

        
        public bool Insert(int num) // funktioniert
        {
            llnode insertnode;
            bool found;

            (insertnode, found) = search(num);

            if (found == false && insertnode == null)
            {
                Prepend(num);
                return true;
            }

            if (num <= first.Key)
            {
                Prepend(num);
                return true;
            }

            if (found == false || (found == true && Set ==false) )
            {
                llnode newnode = new llnode(num, insertnode.Next);
                insertnode.Next = newnode;
                return true;
            }
            
            
            return false;

        }



        
    }
}
