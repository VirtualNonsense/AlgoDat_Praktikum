using Microsoft.VisualStudio.TestTools.UnitTesting;

using AlgoDatDictionaries.Lists;
namespace Tests.Lists
{
    [TestClass]
    public class SetSorted
    {
        [TestMethod]
        public void InsetTest()
        {
            SetSortedArray multiSetUnsorted = new SetSortedArray();
            multiSetUnsorted.Insert(7);
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
        }

        [TestMethod]
        public void DeleteTest()
        {
            SetSortedArray set = new SetSortedArray();
            set.Insert(7);
            set.Insert(5);
            set.Insert(2);
            set.Insert(1);
            set.Insert(10);
            set.Insert(4);
            Assert.IsTrue(set.Delete(1));
            Assert.IsTrue(set.Delete(10));
            Assert.IsTrue(set.Delete(5));
            Assert.IsFalse(set.Delete(20));
            Assert.IsFalse(set.Delete(1));
            


        }
    }
}