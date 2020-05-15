using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Arrays
{
    public abstract class ServiceArray
    {
        protected int[] array; 
        
        
        protected int GetLastIndex(int[] array)
        {
            int currentIndex = 0;
            while (array[currentIndex] != 0) currentIndex++; //darf 0 vorkommen??
            return currentIndex - 1;
        }
        
        public void Print()
        {
            foreach(int i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

    }
}
