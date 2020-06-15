using System;
using AlgoDatDictionaries.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Arrays
{
    [TestClass]
    public class MultiSetSorted
    {
        
        [TestMethod]
        public void InsertTest()
        {
            MultiSetSortedArray multiSetSorted = new MultiSetSortedArray();
            multiSetSorted.Insert(7);
        }
        
        
        [TestMethod]
        public void SearchTest()
        {
            MultiSetSortedArray array = new MultiSetSortedArray();
            array.Insert(7);
            array.Insert(6);
            array.Insert(3);
            array.Insert(4);
            array.Insert(0);
            array.Insert(3);
            array.Insert(2);
            Assert.IsTrue(array.Search(7));
            Assert.IsTrue(array.Search(6));
            Assert.IsTrue(array.Search(3));
            Assert.IsTrue(array.Search(4));
            Assert.IsTrue(array.Search(3));
            Assert.IsTrue(array.Search(2));
            Assert.IsTrue(array.Search(0));
            Assert.IsFalse(array.Search(5));
            array.Print();
        }

        [TestMethod]
        public void DeleteTest()
        {
            MultiSetSortedArray array = new MultiSetSortedArray();
            array.Insert(7);
            Assert.IsTrue(array.Search(7));
            array.Delete(7);
            Assert.IsFalse(array.Search(7));
            
        }
    }
}