using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace AlgoDatDictionaries.Arrays
{
    public class MultiSetSortedArray:ServiceArray, IMultiSetSorted
    {
        protected override (int, bool) search(int value)
        {
            int midIndex;
            int leftIndex = 0;
            int rightIndex = array.Length - 1;
            do
            {
                midIndex = (leftIndex + rightIndex) / 2;//Array Length very long, search for first item == null
                if (array[midIndex] < value)
                {
                    leftIndex = midIndex + 1;
                }
                else
                {
                    rightIndex = midIndex - 1;
                }

            } while (array[midIndex] != value || leftIndex < rightIndex);
            return (midIndex, array[midIndex] == value);
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
