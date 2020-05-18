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
            double leftIndex = 0;
            double rightIndex = GetLastIndex(array)-1;//Array very long, search for first item == null
            do
            {
                var doubleMidIndex = (leftIndex + rightIndex) / 2;
                midIndex = Convert.ToInt32(Math.Ceiling(doubleMidIndex)); 
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
            int index = search(num).Item1;
            for (int i = GetLastIndex(array); i > index-1; i--)
            {
                array[i + 1] = array[i];
            }

            array[index] = num;
            return true;
        }

    }
}
