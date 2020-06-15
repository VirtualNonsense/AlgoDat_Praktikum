using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDatDictionaries.Hash;

namespace Tests.Hash
{
    [TestClass]

    public class HashTabQuadProbTest
    {

        

        [TestMethod]
        public void InsertTest()
        {
            HashTabQuadProb a = new HashTabQuadProb();
            Assert.IsTrue(a.Insert(76));
            Assert.IsTrue(a.Insert(40));
            Assert.IsTrue(a.Insert(0));
            Assert.IsTrue(a.Insert(48));
            Assert.IsTrue(a.Insert(5));
            Assert.IsTrue(a.Insert(20));
            a.Print();
            
        }

        [TestMethod]
        public void DeleteTest()
        {
            HashTabQuadProb a = new HashTabQuadProb();
            Assert.IsTrue(a.Insert(76));
            Assert.IsTrue(a.Insert(40));
            Assert.IsTrue(a.Insert(0));
            Assert.IsTrue(a.Insert(48));
            Assert.IsTrue(a.Insert(5));
            Assert.IsTrue(a.Insert(20));
            a.Delete(76);
            Assert.IsFalse(a.Search(76));
            Assert.IsFalse(a.Delete(100));
            a.Print();
        }

        [TestMethod]
        public void SearchTest()
        {
            HashTabQuadProb a = new HashTabQuadProb();
            Assert.IsTrue(a.Insert(76));
            Assert.IsTrue(a.Insert(40));
            Assert.IsTrue(a.Insert(0));
            Assert.IsTrue(a.Insert(48));
            Assert.IsTrue(a.Insert(5));
            Assert.IsTrue(a.Insert(20));
            
            Assert.IsTrue(a.Search(76));
            Assert.IsTrue(a.Search(40));
            Assert.IsTrue(a.Search(48));
            Assert.IsTrue(a.Search(5));
            Assert.IsTrue(a.Search(20));
            Assert.IsTrue(a.Search(0));
            Assert.IsFalse(a.Search(2));
            Assert.IsTrue(a.Insert(8));
            Assert.IsFalse(a.Insert(11));
            Assert.IsFalse(a.Insert(76));
            a.Print();
            
        }



    }
}

