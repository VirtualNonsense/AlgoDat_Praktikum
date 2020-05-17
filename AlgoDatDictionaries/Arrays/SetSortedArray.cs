using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace AlgoDatDictionaries.Arrays
{
    public class SetSortedArray : MultiSetSortedArray, ISet
    {
        public bool Insert(int value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int num)
        {
            
            if (Search(num))
            {
                int index = search(num).Item1;
                array[index] = 0;
                for (int i = index; i <= GetLastIndex(array)+1; i++)
                {
                    array[i] = array[i + 1];
                }

                return true;
            }
            return false;
        }

    }
}
