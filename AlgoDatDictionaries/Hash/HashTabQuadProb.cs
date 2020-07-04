using AlgoDatDictionaries.Arrays;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Hash
{
    public class HashTabQuadProb : ISet
    {
        static int k = 1;
        int[] arr = new int[4 * k + 3];
        
        public HashTabQuadProb()
        {
            for (int index = 0; index < arr.Length; index++) //setting all array values to -1
            {
                arr[index] = -1;
            }
        }

        private int HashfuncPos(int a, int tries) 
        { 
            return (a + tries*tries) % (4 * k + 3);
            
        }

        private int HashfuncNeg(int a, int tries)
        {
            return ((a - tries * tries) % (4 * k + 3) + (4* k +3))%(4*k+3); //avoiding negative
        }

        

        public bool Search(int value)
        {
            return search(value).Item1;
        }
        
        
       

        private (bool, int) search(int value)
        {
            
            int tries = 0;
            double max = (4 * k + 3) / 2; 

            while (tries <= Math.Floor(max))
            {
                var hashfuncpos = HashfuncPos(value, tries);
                var hashfuncneg = HashfuncNeg(value, tries);
                if (arr[hashfuncpos] == value)    //checking if calculated position contains value
                {
                    return (true, hashfuncpos);
                }

                if (arr[hashfuncneg] == value)
                {
                    return (true, hashfuncneg);
                }

                if (arr[hashfuncpos] == -1) //if -1 is found, no cell before could contain value, so it's not in array
                {
                    return (false, hashfuncpos); //returning the empty position for runtime optimization
                }

                if (arr[hashfuncneg] == -1)
                {
                    return (false, hashfuncneg);
                }

                tries++;
            }

            return (false, -1);                 // Instead of -1 "thinker" possible
        }

        public bool Insert(int value)
        {
            (bool, int) findtup = search(value);

            if (findtup.Item1 == false && findtup.Item2 != -1)
            {
                arr[findtup.Item2] = value;
                return true;
            }

            return false;
        }

        public bool Delete(int value)
        {
            (bool, int) findtup = search(value);

            if(findtup.Item1)
            {
                arr[findtup.Item2] = -2;                             // delete item and set cell to used (-2)
                return true;
            }

            return false;
        }

        public void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i}) ");
                switch (arr[i])
                {
                    case -1:
                        Console.WriteLine("Slot is empty");
                        break;
                    case -2:
                        Console.WriteLine("Slot is empty, but blocked");
                        break;
                    default:
                        Console.WriteLine($"{arr[i]} ");
                        break;
                }
            }
        }
    }
}
