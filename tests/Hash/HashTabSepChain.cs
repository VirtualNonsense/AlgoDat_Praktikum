using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgoDatDictionaries.Hash;
namespace Tests.Hash
{
    [TestClass]

    public class HashTabSepChainTest
    {
        [TestMethod]
        public void InsertTest()
        {
            HashTabSepChain a = new HashTabSepChain();
            Assert.IsTrue(a.Insert(12));
            Assert.IsTrue(a.Insert(56));
            Assert.IsTrue(a.Insert(47));
            Assert.IsTrue(a.Insert(19));
            Assert.IsTrue(a.Insert(89));
            Assert.IsTrue(a.Insert(31));
            Assert.IsTrue(a.Insert(24));
            Assert.IsTrue(a.Insert(79));
            a.Print();
        }

        [TestMethod]
        public void SearchTest()
        {
            HashTabSepChain a = new HashTabSepChain();
            a.Insert(12);
            a.Insert(56);
            a.Insert(47);
            a.Insert(19);
            a.Insert(89);
            a.Insert(31);
            a.Insert(24);
            a.Insert(79);
            Assert.IsTrue(a.Search(12));
            Assert.IsTrue(a.Search(56));
            Assert.IsTrue(a.Search(47));
            Assert.IsTrue(a.Search(19));
            Assert.IsTrue(a.Search(89));
            Assert.IsTrue(a.Search(31));
            Assert.IsTrue(a.Search(24));
            Assert.IsTrue(a.Search(79));
            Assert.IsFalse(a.Search(100));
            a.Print();
        }

        [TestMethod]
        public void DoubleInsertTest()
        {
            HashTabSepChain a = new HashTabSepChain();
            a.Insert(12);
            a.Insert(56);
            a.Insert(47);
            a.Insert(19);
            a.Insert(89);
            a.Insert(31);
            a.Insert(24);
            a.Insert(79);
            Assert.IsFalse(a.Insert(12));
            Assert.IsFalse(a.Insert(79));
            a.Print();
        }

        [TestMethod]
        public void DeleteTest()
        {
            HashTabSepChain a = new HashTabSepChain();
            a.Insert(12);
            a.Insert(56);
            a.Insert(47);
            a.Insert(19);
            a.Insert(89);
            a.Insert(31);
            a.Insert(24);
            a.Insert(79);
            
            Assert.IsTrue(a.Delete(79));
            Assert.IsTrue(a.Delete(56));
            Assert.IsTrue(a.Delete(12));
            Assert.IsTrue(a.Delete(31));
            Assert.IsFalse(a.Delete(100));
            a.Print();
        }

        //    a.Print();

        //    Console.WriteLine();
        //    Console.WriteLine(a.Search(12));
        //    Console.WriteLine(a.Search(56));
        //    Console.WriteLine(a.Search(47));
        //    Console.WriteLine(a.Search(19));
        //    Console.WriteLine(a.Search(89));
        //    Console.WriteLine(a.Search(31));
        //    Console.WriteLine(a.Search(24));
        //    Console.WriteLine(a.Search(79));
        //    Console.WriteLine();
        //    Console.WriteLine(a.Search(100));
        //    Console.WriteLine();
        //    Console.WriteLine(a.Insert(12));
        //    Console.WriteLine(a.Insert(24));
        //    Console.WriteLine(a.Insert(79));
        //    Console.WriteLine(a.Insert(47));

        //    a.Delete(79);
        //    Console.WriteLine();
        //    a.Print();

        //    a.Delete(56);
        //    a.Delete(12);
        //    a.Delete(31);
        //    Console.WriteLine();
        //    a.Print();

    }
}
