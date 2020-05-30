﻿using System;
using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.SearchTrees
{
    [TestClass]
    public class TreapTreeTest
    {
        [TestMethod]
        public void Inserttest()
        {
            var t = new Treap();
            Assert.IsTrue(t.Insert(10));
            Assert.IsTrue(t.Insert(8));
            Assert.IsTrue(t.Insert(3));
            Assert.IsFalse(t.Insert(3));
        }
        [TestMethod]
        public void Deletetest()
        {
            var t = new Treap();
            t.Insert(10);
            t.Insert(1);
            t.Insert(15);
            t.Insert(7);
            t.Insert(8);
            t.Insert(4);
            Assert.IsTrue(t.Delete(10));
        }
        [TestMethod]
        public void printtest()
        {
            var t = new Treap();
            t.Insert(10);
            t.Insert(1);
            t.Insert(15);
            t.Insert(7);
            t.Insert(8);
            t.Insert(4);
            t.Print();

        }
        [TestMethod]
        public void Deletetestrotateprint()
        {
            var t = new Treap();
            t.Insert(10);
            t.Insert(1);
            t.Insert(15);
            t.Insert(7);
            t.Insert(8);
            t.Insert(4);

            //before delete
            t.Print();

            t.Delete(7);

            //after delete
            t.Print();
        }
    }
}
