using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries
{
    public interface IDictionary
    {
        bool Search(int value);
        bool Insert(int value);
        bool Delete(int value);
        void Print();
    }
}
