using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDatDictionaries.Arrays;

namespace Tests.Arrays
{
    [TestClass]
    public class SetUnsorted
    {
        [TestMethod]
        public void InsetTest()
        {
            SetUnsortedArray setUnsortedArray = new SetUnsortedArray();
            setUnsortedArray.Insert(7);
        }
        
        
        [TestMethod]
        public void SearchTest()
        {
            SetUnsortedArray set = new SetUnsortedArray();
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
            SetUnsortedArray set = new SetUnsortedArray();
            set.Insert(7);
            Assert.IsTrue(set.Search(7));
            set.Delete(7);
            Assert.IsFalse(set.Search(7));
            
        }
    }
}