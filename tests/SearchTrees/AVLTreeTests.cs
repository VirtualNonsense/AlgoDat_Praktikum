using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualBasic.FileIO;
using NuGet.Frameworks;

namespace tests.SearchTrees
{
    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void GetUnBalancedNodeTest_UnbalancedAfterInsert()
        {
            // Setup
            AVLTree t = new AVLTree(false);
            t.Insert(10); // 0
            t.Insert(5); // - 
            t.Insert(7); // 0  
            t.Insert(3); // - 
            t.Insert(1); // 0 
            t.Insert(15); // -
            t.Insert(20); // 0 
            t.Insert(12); // 0
            var (pre, node, dir, found) = t.DetailedSearch(2);
            t.Insert(pre, dir, 2);
            var (unbalanced, balance) = t.GetUnbalancedNode(pre);
            t.Print();

            // Assert
            Assert.AreEqual(3, unbalanced.Value);
            Assert.AreEqual(-2, balance);
        }


        [TestMethod]
        public void GetUnbalancedNodeTest_UnbalancedAfterDelete()
        {
            // Setup
            AVLTree t = new AVLTree(false);
            t.Insert(10); // 0
            t.Insert(5); // - 
            t.Insert(7); // 0  
            t.Insert(3); // - 
            t.Insert(1); // 0 
            t.Insert(15); // - -> --
            t.Insert(20); // 0 -> x
            t.Insert(12); // - 
            t.Insert(11); // 0 

            // Action
            var (pre, node, dir, found) = t.DetailedSearch(20);
            (_, pre) = t.Delete(pre, node, dir);
            var (unbalanced, balance) = t.GetUnbalancedNode(pre);
            t.Print();

            // Assert
            Assert.AreEqual(15, unbalanced.Value);
            Assert.AreEqual(-2, balance);
        }

        [TestMethod]
        public void GetUnbalancedNodeTest_BalancedTree_ReturnRoot()
        {
            // Setup
            AVLTree t = new AVLTree(false);
            t.Insert(10); // 0
            t.Insert(5); // - 
            t.Insert(7); // 0  
            t.Insert(3); // - 
            t.Insert(1); // 0 
            t.Insert(15); // - 
            t.Insert(20); // 0 
            t.Insert(12); // - 
            t.Insert(11); // 0 

            // Action
            var (pre, node, dir, found) = t.DetailedSearch(20);
            var (unbalanced, balance) = t.GetUnbalancedNode(pre);
            t.Print();

            // Assert
            Assert.AreEqual(10, unbalanced.Value);
            Assert.AreEqual(0, balance);
        }

        [TestMethod]
        public void GetUnbalancedNodeTest_BalancedRoot()
        {
            AVLTree t = new AVLTree(false);
            t.Insert(5);
            // Action
            var (pre, node, dir, found) = t.DetailedSearch(5);
            var (unbalanced, balance) = t.GetUnbalancedNode(node);
            t.Print();
            Assert.IsNull(pre);
            Assert.AreEqual(5, unbalanced.Value);
            Assert.AreEqual(0, balance);

        }


        [TestMethod]
        public void
            GetUnBalancedNodeTest_Unbalanced_afterDeleteDelete_SymmetricPredecessorIsChild_HiddenSymPre_CheckForPredecessors()
        {
            var t = new AVLTree(false);
            t.Insert(45);
            t.Insert(18);
            t.Insert(67);
            t.Insert(10);
            t.Insert(41);
            t.Insert(55);
            t.Insert(97);
            t.Insert(5);
            t.Insert(14);
            t.Insert(43);
            t.Insert(50);
            t.Insert(65);
            t.Insert(95);
            t.Insert(105);
            t.Insert(8);
            t.Insert(47);
            t.Insert(59);
            t.Insert(57);
            t.Insert(64);
            t.Insert(66);
            t.Insert(100);
            Console.WriteLine("Bevor delete");
            t.Print();
            // Action
            var (pre, node, dir, found) = t.DetailedSearch(67);
            (_, pre) = t.Delete(pre, node, dir);
            var (unbalanced, balance) = t.GetUnbalancedNode(pre);
            Console.WriteLine("After delete");
            t.Print();
            
            // Assert
            Assert.AreEqual(65, unbalanced.Value);
            Assert.AreEqual(-2, balance);
            
        }

        [TestMethod]
        public void InsertTest()
        {
            var t = new AVLTree();
            t.Insert(20);
        }
    }
}