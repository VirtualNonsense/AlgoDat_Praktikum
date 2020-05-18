using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Arrays
{
    public class SetUnsortedArray : MultiSetUnsortedArray, ISetSorted
    {
        public override bool Insert(int num)
        {
            if (!Search(num))
            {
                array[GetLastIndex(array) + 1] = num;
                return true;
            }

            return false;
        }
    }
}
