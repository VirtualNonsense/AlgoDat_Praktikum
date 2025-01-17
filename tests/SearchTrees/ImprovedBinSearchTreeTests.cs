﻿using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests.SearchTrees
{
    [TestClass]
    public class ImprovedBinSearchTreeTests
    {
        [TestMethod]
        public void InsertTest()
        {
            var t = new ImprovedBinSearchTree();
            
            Assert.IsTrue(t.Insert(5));           
            Assert.IsFalse(t.Insert(5));
        }

        [TestMethod]
        public void PublicSearchTest()
        {
            var t = new ImprovedBinSearchTree();

            t.Insert(5);
            Assert.IsTrue(t.Search(5));
        }

        [TestMethod]
        public void InternalSearchRootTest_found()
        {
            var t = new ImprovedBinSearchTree();
            const int value = 5;

            t.Insert(value);

            var (pre, node, direction, found) = t.DetailedSearch(value);

            Assert.IsNull(pre);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(BinSearchTree.Direction.Unset, direction);
            Assert.IsTrue(found);
        }

        [TestMethod]
        public void InternalSearchRootTest_notfound()
        {
            var t = new ImprovedBinSearchTree();
            const int value = 5;

            t.Insert(4);

            var (pre, node, direction, found) = t.DetailedSearch(value);

            Assert.AreEqual(4, pre.Value);
            Assert.IsNull(node);
            Assert.AreEqual(BinSearchTree.Direction.Right, direction);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void InternalSearchRightToRootTest_found()
        {
            var t = new ImprovedBinSearchTree();
            const int value = 5;

            t.Insert(4);
            t.Insert(value);

            var (pre, node, direction, found) = t.DetailedSearch(value);

            Assert.AreEqual(4, pre.Value);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(BinSearchTree.Direction.Right, direction);
            Assert.IsTrue(found);
        }


        [TestMethod]
        public void InternalSearchLeftToRootTest_found()
        {
            var t = new ImprovedBinSearchTree();
            const int value = 3;

            t.Insert(4);
            t.Insert(value);

            var (pre, node, direction, found) = t.DetailedSearch(value);

            Assert.AreEqual(4, pre.Value);
            Assert.AreEqual(value, node.Value);
            Assert.AreEqual(BinSearchTree.Direction.Left, direction);
            Assert.IsTrue(found);
        }


        [TestMethod]
        public void InternalSearchRootNullTest_notfound()
        {
            var t = new ImprovedBinSearchTree();
            var (pre, node, direction, found) = t.DetailedSearch(5);

            Assert.IsNull(pre);
            Assert.IsNull(node);
            Assert.AreEqual(BinSearchTree.Direction.Unset, direction);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void InsertTest_InsertFirstElement_True()
        {
            var t = new ImprovedBinSearchTree();
            var success = t.Insert(5);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void InsertTest_InsertSecondElement_SameAsRoot()
        {
            var t = new ImprovedBinSearchTree();
            t.Insert(5);
            var success = t.Insert(5);

            Assert.IsFalse(success);
        }


        [TestMethod]
        public void DeleteTest_TrueAfterDelete()
        {
            var t = new ImprovedBinSearchTree();
            const int value = 5;
            t.Insert(value);
            var deleted = t.Delete(value);
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void DeleteTest_FalseIfNotInTree()
        {
            var t = new ImprovedBinSearchTree();
            const int value = 5;
            var deleted = t.Delete(value);
            Assert.IsFalse(deleted);
        }

        [TestMethod]
        public void DeleteTest_CheckIfDelete()
        {
            var t = new ImprovedBinSearchTree();
            const int value = 5;
            t.Insert(value);
            var deleted = t.Delete(value);
            Assert.IsFalse(t.Search(value));
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void DeleteTest_ComplexTree()
        {
            var t = new ImprovedBinSearchTree();
            t.Insert(10); // 0
            t.Insert(5); // - 
            t.Insert(7); // 0  
            t.Insert(3); // - 
            t.Insert(1); // 0 
            t.Insert(15); // - -> --
            t.Insert(20); // 0 -> x
            t.Insert(12); // - 
            t.Insert(11); // 0 

            var b = t.Delete(20);
            
            Assert.IsTrue(b);
        }
        
        [TestMethod]
        public void DeleteTest_DeleteRoot_CheckRest()
        {
            var t = new ImprovedBinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(17);
            var deleted = t.Delete(10);
            Assert.IsTrue(deleted);
            Assert.IsFalse(t.Search(10));
            Assert.IsTrue(t.Search(5));
            Assert.IsTrue(t.Search(15));
            Assert.IsTrue(t.Search(17));
        }

        [TestMethod]
        public void DeleteTest_SymmetricPredecessorIsChild_EzTree()
        {
            var t = new ImprovedBinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(6);
            t.Insert(4);
            var deleted = t.Delete(5);
            Assert.IsTrue(deleted);
            Assert.IsFalse(t.Search(5));
            Assert.IsTrue(t.Search(4));
            Assert.IsTrue(t.Search(6));
        }
        
        [TestMethod]
        public void DeleteTest_SymmetricPredecessorIsChild_EzTree_CheckForPredecessors()
        {
            var t = new ImprovedBinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(6);
            t.Insert(4);
            Console.WriteLine("Bevor delete");
            t.Print();
            var deleted = t.Delete(5);
            Console.WriteLine("After delete");
            t.Print();
            Assert.IsTrue(deleted);
            var (pre6, node6, _, _) = t.DetailedSearch(6);
            var (pre4, node4, _, _) = t.DetailedSearch(4);
            
            Assert.AreEqual(pre6.Value, ((DoubleLinkBinSearchTreeNode)node6).Previous.Value);
            Assert.AreEqual(4, ((DoubleLinkBinSearchTreeNode)node6).Previous.Value);
            Assert.AreEqual(10, ((DoubleLinkBinSearchTreeNode)node4).Previous.Value);
            Assert.AreEqual(pre4.Value, ((DoubleLinkBinSearchTreeNode)node4).Previous.Value);
        }

        [TestMethod]
        public void DeleteTest_SymmetricPredecessorIsChild_HiddenSymPre_CheckForPredecessors()
        {
            var t = new ImprovedBinSearchTree();
            t.Insert(45);
            t.Insert(18);
            t.Insert(67);
            t.Insert(10);
            t.Insert(41);
            t.Insert(56);
            t.Insert(97);
            t.Insert(43);
            t.Insert(66);
            t.Insert(95);
            t.Insert(59);
            t.Insert(57);
            t.Insert(64);
            Console.WriteLine("Bevor delete");
            t.Print();
            
            t.Delete(67);
            
            Console.WriteLine("After delete");
            t.Print();
            var (pre66, node66, _, _) = t.DetailedSearch(66);
            var (pre56, node56, _, _) = t.DetailedSearch(56);
            var (pre97, node97, _, _) = t.DetailedSearch(97);
            
            
            Assert.AreEqual(pre66.Value, ((DoubleLinkBinSearchTreeNode)node66).Previous.Value);
            Assert.AreEqual(45, ((DoubleLinkBinSearchTreeNode)node66).Previous.Value);
            Assert.AreEqual(pre56.Value, ((DoubleLinkBinSearchTreeNode)node56).Previous.Value);
            Assert.AreEqual(66, ((DoubleLinkBinSearchTreeNode)node56).Previous.Value);
            Assert.AreEqual(pre97.Value, ((DoubleLinkBinSearchTreeNode)node97).Previous.Value);
            Assert.AreEqual(66, ((DoubleLinkBinSearchTreeNode)node97).Previous.Value);

        }

        [TestMethod]
        public void DeleteTest_DeleteNodeWithTwoChildren_SymPreHasTwoChildrenAsWell()
        {
            var t = new ImprovedBinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(6);
            t.Insert(4);
            var deleted = t.Delete(5);
            Assert.IsTrue(deleted);
            Assert.IsFalse(t.Search(5));
            Assert.IsTrue(t.Search(4));
            Assert.IsTrue(t.Search(6));
        }


    }
}