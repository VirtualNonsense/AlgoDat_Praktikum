using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Arrays
{
    class MultiSetUnsortedArray : ServiceArray
    {
        public bool LinearSearch(int num)
        {
            foreach (int elem in array)
            {
                if (elem == num)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
