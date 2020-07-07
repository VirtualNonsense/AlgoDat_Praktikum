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

        public int HashfuncPos(int a, int tries) 
        { 
            return (a + tries*tries) % (4 * k + 3);
            
        }

        public int HashfuncNeg(int a, int tries)
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
            double max = (4 * k + 3) / 2; //Math.Floor in ugly
            int thinker = -1;
            int hashfuncpos = HashfuncPos(value, tries);
            int hashfuncneg = HashfuncNeg(value, tries);

            while (tries <= Math.Floor(max))          
            {
                if (arr[hashfuncpos] == value)    //value was found
                {
                    return (true, hashfuncpos);
                }
                if (arr[hashfuncneg] == value)
                {
                    return (true, hashfuncneg);
                }
                if (arr[hashfuncpos] == -1 && arr[hashfuncneg] == -1 && thinker == -1 ) // if -1 is found, the value is not in the array, returning first free position
                {
                    return (false, hashfuncpos);
                }

                if (arr[hashfuncpos] != -1 && arr[hashfuncneg] == -1 && thinker == -1)
                {
                    return (false, hashfuncneg);
                }
                
                if ((arr[hashfuncpos] == -1 && arr[hashfuncneg] == -1 ||     //value is not in array, but cell previous to current
                     arr[hashfuncpos] != -1 && arr[hashfuncneg] == -1) 
                    && thinker != -1)
                {
                    return (false, thinker);
                }


                if (arr[hashfuncpos] == -2 && thinker == -1)    //cell contained another value before, value could be after, but remembering cell for insert
                {
                    thinker = hashfuncpos;
                }

                if (arr[hashfuncneg] == -2 && thinker == -1)
                {
                    thinker = hashfuncneg;
                }
                tries++;
                hashfuncpos = HashfuncPos(value, tries);
                hashfuncneg = HashfuncNeg(value, tries);
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
            if(findtup.Item1 == true)
            {
                arr[findtup.Item2] = -2;                 
                return true;
            }

            return false;
        }

        public void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i}) ");
                if (arr[i] == -1)                                  
                {
                    Console.WriteLine("Slot is empty");
                }
                else if(arr[i] == -2)
                {
                    Console.WriteLine("Slot is empty (previously used)");
                }
                else
                {
                    Console.WriteLine($"{arr[i]} ");
                }
            }
        }
    }
}
