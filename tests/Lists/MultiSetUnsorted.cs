using Microsoft.VisualStudio.TestTools.UnitTesting;

using AlgoDatDictionaries.Lists;
namespace Tests.Lists
{
    [TestClass]
    public class MultiSetUnsorted
    {
        [TestMethod]
        public void InsetTest()
        {
            MultiSetUnsortedLinkedList multiSetUnsorted = new MultiSetUnsortedLinkedList();
            multiSetUnsorted.Insert(7);
        }
        
        
        [TestMethod]
        public void SearchTest()
        {
            MultiSetUnsortedLinkedList set = new MultiSetUnsortedLinkedList();
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
            MultiSetUnsortedLinkedList set = new MultiSetUnsortedLinkedList();
            set.Insert(7);
            Assert.IsTrue(set.Search(7));
            // multiSetUnsorted.Delete(7);
            Assert.Fail("Delete method is missing");
            Assert.IsFalse(set.Search(7));
            
        }
    }
}