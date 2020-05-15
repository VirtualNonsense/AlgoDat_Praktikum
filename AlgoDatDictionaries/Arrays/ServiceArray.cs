using System;
using System.Collections.Generic;
using System.Net.Sockets;
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

        public bool Search(int value)
        {
            return search(value).Item2;
        }

        protected virtual (int, bool) search(int value)
        {
            throw new NotImplementedException();
        }
    }
}
