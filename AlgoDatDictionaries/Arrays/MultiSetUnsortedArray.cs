using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AlgoDatDictionaries.Arrays
{
    public class MultiSetUnsortedArray : ServiceArray, IMultiSet
    {
        protected override (int, bool) search(int value) //linear search
        {
            for (int i = 0;  i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return (i, true);
                }
            }
            return (-1, false); //what do we want to return if no index is correct
        }


        public virtual bool Insert(int num)
        { 
            array[GetLastIndex(array) + 1] = num;    //insert at last position
            return true;
        }

       
    }
}
