using Microsoft.VisualStudio.TestTools.UnitTesting;

using AlgoDatDictionaries.Lists;
namespace Tests.Lists
{
    [TestClass]
    public class SetUnsorted
    {
        [TestMethod]
        public void InsertTest()
        {
            SetUnsortedLinkedList multiSetUnsorted = new SetUnsortedLinkedList();
            multiSetUnsorted.Insert(7);
        }
        
        
        [TestMethod]
        public void SearchTest()
        {
            SetUnsortedLinkedList set = new SetUnsortedLinkedList();
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
            SetUnsortedLinkedList set = new SetUnsortedLinkedList();
            set.Insert(7);
            set.Insert(5);
            set.Insert(2);
            set.Insert(1);
            set.Insert(6);
            set.Insert(8);
            set.Insert(9);
            Assert.IsTrue(set.Delete(7));
            Assert.IsTrue(set.Delete(1));
            Assert.IsTrue(set.Delete(9));
            Assert.IsFalse(set.Delete(0));
            Assert.IsFalse(set.Delete(10));

        }
    }
}