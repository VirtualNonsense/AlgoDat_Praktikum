using AlgoDatDictionaries.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AlgoDatDictionaries.Lists;
namespace Tests.Arrays
{
    [TestClass]
    public class MultiSetUnsorted
    {
        [TestMethod]
        public void InsertTest()
        {
            MultiSetUnsortedArray multiSetUnsorted = new MultiSetUnsortedArray();
            multiSetUnsorted.Insert(7);
        }
        
        
        [TestMethod]
        public void SearchTest()
        {
            MultiSetUnsortedArray array = new MultiSetUnsortedArray();
            array.Insert(7);
            array.Insert(6);
            array.Insert(3);
            array.Insert(4);
            array.Insert(3);
            array.Insert(0);
            array.Insert(2);
            Assert.IsTrue(array.Search(7));
            Assert.IsTrue(array.Search(6));
            Assert.IsTrue(array.Search(3));
            Assert.IsTrue(array.Search(4));
            Assert.IsTrue(array.Search(3));
            Assert.IsTrue(array.Search(2));
            Assert.IsTrue(array.Search(0));
            Assert.IsFalse(array.Search(5));
        }

        [TestMethod]
        public void DeleteTest()
        {
            MultiSetUnsortedArray array = new MultiSetUnsortedArray();
            array.Insert(7);
            Assert.IsTrue(array.Search(7));
            array.Delete(7);
            Assert.IsFalse(array.Search(7));
            
        }
    }
}