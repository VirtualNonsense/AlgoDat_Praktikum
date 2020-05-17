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
            int rightIndex = GetLastIndex(array);
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

            } while (array[midIndex] != value && leftIndex < rightIndex);
            return (midIndex, array[midIndex] == value);
        }

        public bool Insert(int num)
        {
            int index = search(num).Item1;
            for (int i = GetLastIndex(array); i > index; i--)
            {
                array[i + 1] = array[i];
            }

            array[index + 1] = num;
            return true;
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
