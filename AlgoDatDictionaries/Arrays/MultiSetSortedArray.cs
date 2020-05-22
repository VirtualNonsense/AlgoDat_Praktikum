using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace AlgoDatDictionaries.Arrays
{
    public class MultiSetSortedArray:ServiceArray, IMultiSetSorted
    {
        protected override (int, bool) search(int value)    //binary search
        {
            int midIndex;
            int leftIndex = 0;
            int rightIndex = Length;//Array very long, search for first item == null
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
            if (Length<0)    //checking if array empty
            {
                array[0] = num;
                Length++;
                return true;
            }
            int index = search(num).Item1;
            for (int i = (Length++) + 1; i >= index; i--)    //move all elements from the end to the index
            {
                array[i + 1] = array[i];
            }

            if (array[index] > num) array[index] = num;    //checking where to put the element
            else array[index+1] = num;
            return true;
        }

    }
}
