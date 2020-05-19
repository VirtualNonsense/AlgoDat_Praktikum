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
            int rightIndex = GetLastIndex(array);//Array very long, search for first item == null
            do
            {
                midIndex = (leftIndex + rightIndex) / 2;
                if (array[midIndex] < value)
                {
                    leftIndex = midIndex + 1;
                }
                else
                {
                    rightIndex = midIndex - 1;
                }

            } while (array[midIndex] != value && leftIndex <= rightIndex);
            return (midIndex, array[midIndex] == value);
        }

        public virtual bool Insert(int num)
        {
            if (array[0] == 0)
            {
                array[0] = num;
                return true;
            }
            int index = search(num).Item1;
            for (int i = GetLastIndex(array)+1; i >= index; i--)
            {
                array[i + 1] = array[i];
            }

            if (array[index] > num) array[index] = num;
            else array[index+1] = num;
            return true;
        }

    }
}
