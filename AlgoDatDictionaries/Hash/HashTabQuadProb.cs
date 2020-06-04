using AlgoDatDictionaries.Arrays;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Hash
{
    class HashTabQuadProb : ISet
    {
        static int k = 1;

        public int Hashfunc(int a, int tries)
        { 
            return (a + tries^2) % (4 * k + 3);
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

            while (arr[place] != 0 || arr[place] == value)
            {
                tries++;
                Hashfunc(value, tries);
            }

            if (arr[place] == 0)
            {
                return (false, place);
            }

            return (true, place);
        }

        public bool Insert(int value)
        {
            (bool, int) findtup = search(value);

            if (findtup.Item1 == false)
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

            }
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

      


    }
}
