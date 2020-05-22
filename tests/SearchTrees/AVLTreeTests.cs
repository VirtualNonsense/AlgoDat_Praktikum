using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests.SearchTrees
{
    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void Insertesttrue()
        {
            AVLTree t = new AVLTree();
            Assert.IsTrue(t.Insert(10));
        }
        [TestMethod]
        public void InsertTestFalse()
        {
            AVLTree t = new AVLTree();
            Assert.IsTrue(t.Insert(10));
            Assert.IsFalse(t.Insert(10));
        }
        [TestMethod]
        public void InsertTestTree()
        {
            AVLTree t = new AVLTree();
            Assert.IsTrue(t.Insert(10));
            Assert.IsTrue(t.Insert(5));
            Assert.IsTrue(t.Insert(3));
            Assert.IsTrue(t.Insert(15));
            
        }
        [TestMethod]
        public void InsertTestTreeWithFalse()
        {
            AVLTree t = new AVLTree();
            Assert.IsTrue(t.Insert(10));
            Assert.IsTrue(t.Insert(5));
            Assert.IsTrue(t.Insert(3));
            Assert.IsTrue(t.Insert(15));
            Assert.IsFalse(t.Insert(5));

        }
        [TestMethod]
        public void DeleteTestTrue()
        {
            AVLTree t = new AVLTree();
            t.Insert(10);
            Assert.IsTrue(t.Delete(10));
        }
        [TestMethod]
        public void DeleteTestFalse()
        {
            AVLTree t = new AVLTree();
            t.Insert(10);
            Assert.IsFalse(t.Delete(5));

        }
        [TestMethod]
        public void DeleteTestTree()
        {
            AVLTree t = new AVLTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(3);
            t.Insert(15);
            Assert.IsTrue(t.Delete(5));

        }
        [TestMethod]
        public void DeleteTestTreeFalse()
        {
            AVLTree t = new AVLTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(3);
            t.Insert(15);
            Assert.IsFalse(t.Delete(7));

        }
        [TestMethod]
        public void GetUnbalancedNodeRootTest()
        {
            AVLTree t = new AVLTree();
            Assert.AreEqual((null,0), t.GetUnbalancedNode(5));
        }
        [TestMethod]
        public void GetUnbalancedNodeRootTest2()
        {
            AVLTree t = new AVLTree();
            t.Insert(10);
            t.Delete(10);
            Assert.AreEqual((null, 0), t.GetUnbalancedNode(3));
        }
        [TestMethod]
        public void GetUnbalancedNodeTest()
        {
            AVLTree t = new AVLTree();
            t.Insert(5);
            Assert.AreEqual((null,0), t.GetUnbalancedNode(5));

        }
        [TestMethod]
        public void GetUnbalancedNodeTestTree()
        {
            AVLTree t = new AVLTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(3);
            t.Insert(15);
            Assert.AreEqual((10, -2), t.GetUnbalancedNode(3));

        }
    }
}