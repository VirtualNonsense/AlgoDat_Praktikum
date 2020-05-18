using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace AlgoDatDictionaries.Arrays
{
    public class SetSortedArray : MultiSetSortedArray, ISet
    {
        public override bool Insert(int num)
        {
            if (!Search(num))
            {
                base.Insert(num);
                return true;
            }
            return false;
        }
    }
}
