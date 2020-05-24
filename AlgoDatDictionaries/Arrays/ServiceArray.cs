using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace AlgoDatDictionaries.Arrays
{
    public abstract class ServiceArray
    {
        protected int[] array = new int[100]; 
           
        // idee: int length =0; //bei insert ==> ++       bei delete ==> --
        
        // protected int GetLastIndex(int[] array)
        // {
        //     int currentIndex = 0;
        //     while (array[currentIndex] != 0) currentIndex++; //darf 0 vorkommen??
        //     return currentIndex-1;    //current index is not a number -> -1
        // }

        protected int Length { get; set; } = -1; // Default value -1
        
        public void Print()
        {
            for (int i = 0; i <= Length; i++)
            {
                Console.WriteLine("{0} \t {1}", i,array[i] );
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
            if (Search(num))    //checking if number is in array
            {
                int index = search(num).Item1;    //get the position 
                array[index] = 0;    //delete the number and move all consecutive elements
                for (int i = index; i <= Length +1; i++)
                {
                    array[i] = array[i + 1];
                }

                Length--;
                return true;
            }
            return false;
        }
        

    }
}
