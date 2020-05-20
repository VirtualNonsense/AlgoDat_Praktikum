using Microsoft.VisualStudio.TestTools.UnitTesting;

using AlgoDatDictionaries.Lists;
namespace Tests.Lists
{
    [TestClass]

    public class MultiSetSorted
    {
        [TestMethod]
        public void InsetTest()
        {
            MultiSetSortedLinkedList multiSetUnsorted = new MultiSetSortedLinkedList();
            multiSetUnsorted.Insert(7);
        }
        
        
        [TestMethod]
        public void SearchTest()
        {
            MultiSetSortedLinkedList set = new MultiSetSortedLinkedList();
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
            MultiSetSortedLinkedList set = new MultiSetSortedLinkedList();
            set.Insert(7);
            set.Insert(7);
            set.Insert(3);
            set.Insert(2);
            set.Insert(4);
            set.Insert(4);
            set.Insert(10);
            //Delete Process
            
            Assert.IsTrue(set.Delete(7));
            Assert.IsTrue(set.Delete(3));
            Assert.IsTrue(set.Delete(4));
            Assert.IsTrue(set.Delete(10));
            Assert.IsFalse(set.Delete(0));

        }
    }
}