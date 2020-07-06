using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace AlgoDatDictionaries.Arrays
{
    public class SetSortedArray : MultiSetSortedArray, ISetSorted
    {
        public override bool Insert(int num)
        {
            if (!Search(num))
            {
                return base.Insert(num);
            }
            return false;
        }
    }
}
