using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDatDictionaries.Arrays;

using AlgoDatDictionaries.Lists;

namespace Tests.Arrays
{
    [TestClass]
    public class SetSorted
    {
        [TestMethod]
        public void InsetTest()
        {
            SetSortedArray setSortedArray = new SetSortedArray();
            setSortedArray.Insert(7);
        }
        
        
        [TestMethod]
        public void SearchTest()
        {
            SetSortedArray set = new SetSortedArray();
            set.Insert(7);
            set.Insert(6);
            set.Insert(3);
            set.Insert(4);
            set.Insert(3);
            set.Insert(2);
            Assert.IsTrue(set.Search(7));
            Assert.IsTrue(set.Search(6));
            Assert.IsTrue(set.Search(3));
            Assert.IsTrue(set.Search(4));
            Assert.IsTrue(set.Search(3));
            Assert.IsTrue(set.Search(2));
            Assert.IsFalse(set.Search(5));
            set.Print();
        }

        [TestMethod]
        public void DeleteTest()
        {
            SetSortedArray set = new SetSortedArray();
            set.Insert(7);
            Assert.IsTrue(set.Search(7));
            set.Delete(7);
            Assert.IsFalse(set.Search(7));
            
        }
    }
}