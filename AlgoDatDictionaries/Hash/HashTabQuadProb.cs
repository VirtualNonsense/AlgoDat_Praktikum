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
                // value found on positive hashindex
                if (arr[hashfuncpos] == value) 
                {
                    return (true, hashfuncpos);
                }
                // value found on negative hashindex
                if (arr[hashfuncneg] == value)
                {
                    return (true, hashfuncneg);
                }
                // found empty spot on hashfuncpos, thinker suggest that there is no freed slot before that
                if (arr[hashfuncpos] == -1 && thinker == -1 ) 
                {
                    return (false, hashfuncpos);
                }
                
                // found empty spot on hashfuncneg, thinker suggest that there is no freed slot before that
                if (arr[hashfuncpos] != -1 && arr[hashfuncneg] == -1 && thinker == -1)
                {
                    return (false, hashfuncneg);
                }
                
                // check whether the "probing chain" is broken and the thinker suggests that there is place somewhere
                // somewhere before the current hash values
                if ((arr[hashfuncpos] == -1 || arr[hashfuncneg] == -1) 
                    && thinker != -1)
                {
                    return (false, thinker);
                }

                // saving current position in case the desired value isn't found later
                if (arr[hashfuncpos] == -2 && thinker == -1)    
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
            
            return (false, thinker); 
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
