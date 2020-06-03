using AlgoDatDictionaries.Lists;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AlgoDatDictionaries.Hash
{
    class HashTabSepChain : ISet
    {
        public int Hashfunc(int a)          // Fest???
        {
            int b = (3 * a + 3) % 8;
            return b;
        }

        ISet[] harray = new SetUnsortedLinkedList[8];
        
        public bool Search(int value)
        {
            ISet temp = harray[Hashfunc(value)];

            if (temp == null)
            {
                return false;
            }
            return temp.Search(value);
        }

        public bool Insert(int value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int value)
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
