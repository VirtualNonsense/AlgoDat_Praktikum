using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Lists
{
    public class llnode
    {
        int key;
        llnode next;

        // Properties
        public int Key
        { 
            get { return key; }
            set { key = value; }
        }

        public llnode Next
        {
            get { return next; }
            set { next = value; }
        }

        // Constructors
        public llnode() 
        {
            // Default constructor
        }
        

        public llnode(int key, llnode next)
        {
            this.key = key;
            this.next = next;
        }
    }
}
