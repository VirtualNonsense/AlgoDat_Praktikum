using AlgoDatDictionaries.Lists;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AlgoDatDictionaries.Hash
{
    public class HashTabSepChain : ISet
    {
        static int k = 8;

        public int Hashfunc(int a)          // Function can be different, change the k - maybe delete term before 'mod k'
        {
            int b = (3 * a + 3) % k;
            return b;
        }

        ISet[] harray = new SetUnsortedLinkedList[k];
            
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
            int place = Hashfunc(value);
            
            bool success = true;                    // for reading purposes

            if (harray[place] == null)
            {
                SetUnsortedLinkedList begin = new SetUnsortedLinkedList();
                success = begin.Insert(value);
                harray[Hashfunc(value)] = begin;
                return success;
            }
            success = harray[Hashfunc(value)].Insert(value);
            return success;
        }

        public bool Delete(int value)
        {
            int place = Hashfunc(value);

            bool success = true;                                    // for reading purposes

            success = harray[Hashfunc(value)].Delete(value);
            return success;
        }

        public void Print()
        {         
           for (int i = 0; i < harray.Length; i++)
           {
                Console.Write($"{i}) ");
                if (harray[i] == null)
                {
                    Console.WriteLine("Slot is empty");
                }
                else
                {
                    harray[i].Print();
                }
           }        
        }
    }
}
