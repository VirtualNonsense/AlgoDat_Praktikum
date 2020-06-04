using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Arrays
{
    public class SetUnsortedArray : MultiSetUnsortedArray, ISet
    {
        public override bool Insert(int num)
        {
            if (!Search(num))
            {
                base.Insert(num);
            }
            return false;
        }
    }
}
