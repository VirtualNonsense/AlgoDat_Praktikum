using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace AlgoDatDictionaries.Arrays
{
    class MultiSetSortedArray:ServiceArray, IMultiSetSorted
    {
        public bool Search(int num) //Binary Search
        {
            int midIndex;
            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            do
            {
                midIndex = (leftIndex + rightIndex) / 2;//Array Length very long, search for first item == null
                if (array[midIndex] < num)
                {
                    leftIndex = midIndex + 1;
                }
                else
                {
                    rightIndex = midIndex - 1;
                }

            } while (array[midIndex] != num || leftIndex < rightIndex);
            return (array[midIndex] == num);
        }

        public bool Insert(int num)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int num)
        {
            throw new NotImplementedException();
        }
    }
}
