using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace AlgoDatDictionaries.Arrays
{
    public abstract class ServiceArray
    {
        protected int[] array = new int[100]; 
        
        protected int GetLastIndex(int[] array)
        {
            int currentIndex = 0;
            while (array[currentIndex] != 0) currentIndex++; //darf 0 vorkommen??
            return currentIndex-1;
        }
        
        public void Print()
        {
            for (int i = 0; i <= GetLastIndex(array); i++)
            {
                Console.WriteLine("{0}, \t {1}", i,array[i] );
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
