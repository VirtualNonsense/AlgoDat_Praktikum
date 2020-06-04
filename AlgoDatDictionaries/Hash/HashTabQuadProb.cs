using AlgoDatDictionaries.Arrays;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Hash
{
    public class HashTabQuadProb : ISet
    {
        static int k = 1;

        public int Hashfunc(int a, int tries)
        { 
            return (a + tries*tries) % (4 * k + 3);
        }

        int[] arr = new int[4 * k + 3];

        public bool Search(int value)
        {
            return search(value).Item1;
        }

        private (bool, int) search(int value)
        {
            int tries = 0;
            int place = Hashfunc(value, tries);
            double max = (4 * k + 3) / 2;
            int thinker = -1;

            while (tries <= Math.Floor(max))             // Not quite sure if 'Floor' is allowed => Please check in "Algo-Skript"
            {
                if (arr[place] == value)
                {
                    return (true, place);
                }
                if (arr[place] == 0 && thinker == -1)
                {
                    thinker = place;
                }
                tries++;
                place = Hashfunc(value, tries);
            }

            if (thinker != -1)
            {
                return (false, thinker);
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

            if (findtup.Item1 == true)
            {
                arr[findtup.Item2] = 0;                             // Zero-Problem
                return true;
            }

            return false;
        }

        public void Print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i}) ");
                if (arr[i] == 0)                                    // Zero-Problem
                {
                    Console.WriteLine("Slot is empty");
                }
                else
                {
                    Console.WriteLine($"{arr[i]} ");
                }
            }
        }
    }
}
