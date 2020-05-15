using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Arrays
{
    class MultiSetUnsortedArray : ServiceArray, IMultiSet
    {
        public bool Search(int num) //linear serach
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

        public bool Insert()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }
}
