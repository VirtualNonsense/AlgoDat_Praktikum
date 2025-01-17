﻿using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;
using System.Security.Cryptography;

namespace tests.SearchTrees
{
    [TestClass]
    public class AVLTreeTests
    {
        
        [TestMethod]
        public void BalancedInsert_LeftUnbalancedAfterInsert_TurnRootRight()
        {
            // Setup
            var t = new AVLTree();
            t.Insert(10); // - = > --
            t.Insert(5); // 0 => +
            
            // Action
            t.Insert(1); // 0
            Console.WriteLine("After");
            t.Print();

            // Assert
            var a = new AVLTree(false);
            a.Insert(5); // 0
            a.Insert(10); // 0
            a.Insert(1); // 0

            Console.WriteLine("Reference");
            a.Print();
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }

        [TestMethod]
        public void BalancedInsert_InsertAscending()
        {
            
            // Setup
            var t = new AVLTree();
            t.Insert(5);
            t.Insert(10);
            t.Insert(12);
            t.Insert(20);
            t.Insert(40);
            Console.WriteLine("bevor");
            t.Print();
            
            t.Insert(70);
            Console.WriteLine("after");
            t.Print();
            
            var a = new AVLTree(false);
            a.Insert(20);
            a.Insert(10);
            a.Insert(40);
            a.Insert(5);
            a.Insert(12);
            a.Insert(70);
            Console.WriteLine("reference");
            a.Print();
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }

        [TestMethod]
        public void BalancedInsert_PlusPlusMinus_DoubleRotation()
        {
            //Setup
            var t = new AVLTree(false);
            t.Insert(50);
            t.Insert(17);
            t.Insert(55);
            t.Insert(12);
            t.Insert(37);
            t.Insert(54);
            t.Insert(69);
            t.Insert(2);
            t.Insert(34);
            t.Insert(63);
            t.Insert(71);
            
            Console.WriteLine("bevor");
            t.Print();

            t.EnableBalance = true;
            t.Insert(67);
            
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new AVLTree(false);
            a.Insert(50);
            a.Insert(17);
            a.Insert(63);
            a.Insert(12);
            a.Insert(37);
            a.Insert(55);
            a.Insert(69);
            a.Insert(2);
            a.Insert(34);
            a.Insert(54);
            a.Insert(67);
            a.Insert(71);
            Console.WriteLine("reference");
            a.Print();
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        

        [TestMethod]
        public void BalancedInsert_InsertDescending()
        {
            
            // Setup
            var t = new AVLTree();
            t.Insert(5);
            t.Insert(4);
            t.Insert(3);
            t.Insert(2);
            
            Console.WriteLine("bevor");
            t.Print();
            t.Insert(1);
            
            Console.WriteLine("after");
            t.Print();
            
            var a = new AVLTree(false);
            Console.WriteLine("reference");
            a.Insert(4);
            a.Insert(2);
            a.Insert(5);
            a.Insert(1);
            a.Insert(3);
            a.Print();
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        
        [TestMethod]
        public void BalancedInsert_LeftUnbalancedAfterInsert_LeftRight()
        {
            // Setup
            var t = new AVLTree();
            t.Insert(10); // - = > --
            t.Insert(5); // 0 => -
            
            // Action
            t.Insert(1); // 0
            Console.WriteLine("After");
            t.Print();

            // Assert
            var a = new AVLTree(false);
            a.Insert(5); // 0
            a.Insert(10); // 0
            a.Insert(1); // 0

            Console.WriteLine("Reference");
            a.Print();
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }

        [TestMethod]
        public void BalancedInsert_LeftTiltOnRightSubNode()
        {
            // Setup
            var t = new AVLTree();
            t.Insert(55);
            t.Insert(50);
            t.Insert(65);
            t.Insert(47);
            t.Insert(59);
            Console.WriteLine("bevor");
            t.Print();
            
            // Action
            t.Insert(57);
            Console.WriteLine("after inserting 57");
            t.Print();
            
            // Assert
            var a = new AVLTree(false);
            a.Insert(55);
            a.Insert(50);
            a.Insert(59);
            a.Insert(47);
            a.Insert(57);
            a.Insert(65);
            Console.WriteLine("reference");
            t.Print();
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());

        }

        [TestMethod]
        public void BalancedInsert_RightUnbalancedAfterInsert_LeftRight()
        {
            // Setup
            var t = new AVLTree();
            t.Insert(10); // + = > ++
            t.Insert(15); // 0 => +
            
            // Action
            t.Insert(20); // 0
            Console.WriteLine("After");
            t.Print();

            // Assert
            var a = new AVLTree(false);
            a.Insert(15); // 0
            a.Insert(10); // 0
            a.Insert(20); // 0

            Console.WriteLine("Reference");
            a.Print();
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }

        [TestMethod]
        public void BalancedInsert_DoubleRotation_PlusPlusMinus()
        {
            var t = new AVLTree(false);
            t.Insert(50);
            t.Insert(17);
            t.Insert(55);
            t.Insert(12);
            t.Insert(37);
            t.Insert(54);
            t.Insert(69);
            t.Insert(2);
            t.Insert(16);
            t.Insert(34);
            t.Insert(41);
            t.Insert(63);
            t.Insert(71);

            Console.WriteLine("bevor");
            t.Print();

            t.EnableBalance = true;
            t.Insert(64);

            Console.WriteLine("after");
            t.Print();
            
            var a = new AVLTree(false);
            a.Insert(50);
            a.Insert(17);
            a.Insert(63);
            a.Insert(12);
            a.Insert(37);
            a.Insert(55);
            a.Insert(69);
            a.Insert(2);
            a.Insert(16);
            a.Insert(34);
            a.Insert(41);
            a.Insert(54);
            a.Insert(64);
            a.Insert(71);
            
            Console.WriteLine("reference");
            a.Print();
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }

        [TestMethod]
        public void BalanceDelete_RootPlusPlus_ChildPlus()
        {
            // 
            var t = new AVLTree();
            t.Insert(1);
            t.Insert(2);
            t.Insert(3);
            t.Insert(4);
            t.Insert(5);
            t.Insert(6);
            t.Insert(7);
            t.Insert(8);
            t.Insert(9);
            t.Delete(4);
            Console.WriteLine("bevor");
            t.Print();
            
            // Action
            Console.WriteLine("removed 3");
            t.Delete(3);
            t.Print();
            
            // Assert 
            var a = new AVLTree(false);
            a.Insert(6);
            a.Insert(2);
            a.Insert(8);
            a.Insert(1);
            a.Insert(5);
            a.Insert(7);
            a.Insert(9);
            Console.WriteLine("reference");
            a.Print();
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());



        }

        [TestMethod]
        public void BalancedInsertTest_InsertRoot()
        {
            var t = new AVLTree();
            t.Insert(20);
            Assert.IsTrue(t.Search(20));
        }
        
        [TestMethod]
        public void BalancedDeleteTest_DeleteRoot()
        {
            var t = new AVLTree();
            t.Insert(20);
            t.Delete(20);
            
            Assert.IsFalse(t.Search(20));
        }

        [TestMethod]
        public void BalancedDeleteTest_DoubleRotation_DoubleMinus()
        {
            var t = new AVLTree(false);
            t.Insert(11);
            t.Insert(7);
            t.Insert(15);
            t.Insert(5);
            t.Insert(9);
            t.Insert(14);
            t.Insert(17);
            t.Insert(3);
            t.Insert(6);
            t.Insert(8);
            t.Insert(12);
            t.Insert(1);
            Console.WriteLine("bevor");
            t.Print();

            t.EnableBalance = true;
            t.Delete(17);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new AVLTree(false);
            a.Insert(7);
            a.Insert(5);
            a.Insert(11);
            a.Insert(3);
            a.Insert(6);
            a.Insert(9);
            a.Insert(14);
            a.Insert(1);
            a.Insert(8);
            a.Insert(12);
            a.Insert(15);

            Console.WriteLine("reference");
            a.Print();
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
            
            
        }

        [TestMethod]
        public void BalancedDelete_DoubleRotation()
        {
            var t = new AVLTree(false);
            t.Insert(50);
            t.Insert(14);
            t.Insert(63);
            t.Insert(12);
            t.Insert(20);
            t.Insert(55);
            t.Insert(69);
            t.Insert(13);
            t.Insert(52);
            t.Insert(60);
            t.Insert(67);
            t.Insert(71);
            t.Insert(57);

            Console.WriteLine("bevor");
            t.Print();

            t.EnableBalance = true;
            t.Delete(20);
            
            
            Console.WriteLine("after");
            t.Print();
            
            var a = new AVLTree(false);
            a.Insert(55);
            a.Insert(50);
            a.Insert(63);
            a.Insert(13);
            a.Insert(52);
            a.Insert(60);
            a.Insert(69);
            a.Insert(12);
            a.Insert(14);
            a.Insert(57);
            a.Insert(67);
            a.Insert(71);
            
            
            Console.WriteLine("reference");
            a.Print();
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());

        }
        
        [TestMethod]
        public void BalancedDeleteTest_Unbalanced_afterDeleteRoot_SymmetricPredecessorIsChild_HiddenSymPre_CheckForPredecessors()
        {
            var t = new AVLTree(false);
            t.Insert(67);
            t.Insert(55);
            t.Insert(97);
            t.Insert(50);
            t.Insert(65);
            t.Insert(95);
            t.Insert(105);
            t.Insert(47);
            t.Insert(59);
            t.Insert(66);
            t.Insert(100);
            t.Insert(57);
            t.Insert(64);
            Console.WriteLine("Bevor delete");
            t.Print();
            // Action
            t.EnableBalance = true;
            t.Delete(67);
            Console.WriteLine("After removing 67");
            t.Print();
            
            // Assert
            var a = new AVLTree(false);
            a.Insert(66);
            a.Insert(55);
            a.Insert(97);
            a.Insert(50);
            a.Insert(59);
            a.Insert(95);
            a.Insert(105);
            a.Insert(47);
            a.Insert(57);
            a.Insert(65);
            a.Insert(100);
            a.Insert(64);
            
            Console.WriteLine("Reference");
            a.Print();
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }


        [TestMethod]
        public void GetUnbalancedNodeTest_UnbalancedAfterDelete()
        {
            // Setup
            var t = new AVLTree(false);
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
            var (prePre, pre, node, dir, _) = t.EvenMoreDetailedSearch(20);
            
            // Using this method deliberately to test GetUnBalancedNode
            var (_, nPre) = t.Delete(pre, node, dir);
            pre = (AvlTreeNode) nPre;

            var (_, _, unbalanced, _, balance) =
                t.GetUnbalancedNode(prePre, pre, node, dir);
            t.Print();
            
            // Assert
            Assert.AreEqual(15, unbalanced.Value);
            Assert.AreEqual(-2, balance);
        }


        [TestMethod]
        public void GetUnBalancedNodeTest_Unbalanced_afterDelete_SymmetricPredecessorIsChild_HiddenSymPre_CheckForPredecessors()
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
            var (prePre, pre, node, dir, _) = t.EvenMoreDetailedSearch(67);
            var (_, nPre) = t.Delete(pre, node, dir);
            pre = (AvlTreeNode) nPre;
            var (_, _, unbalanced, _, balance) =
                t.GetUnbalancedNode(prePre, pre, node, dir);
            Console.WriteLine("After delete 67");
            t.Print();
            
            // Assert
            Assert.AreEqual(65, unbalanced.Value);
            Assert.AreEqual(-2, balance);
            
        }
        [TestMethod]
        public void GetUnBalancedNodeTest_Unbalanced_afterDeleteRoot_SymmetricPredecessorIsChild_HiddenSymPre_CheckForPredecessors()
        {
            var t = new AVLTree(false);
            t.Insert(67);
            t.Insert(55);
            t.Insert(97);
            t.Insert(50);
            t.Insert(65);
            t.Insert(95);
            t.Insert(105);
            t.Insert(47);
            t.Insert(59);
            t.Insert(66);
            t.Insert(100);
            t.Insert(57);
            t.Insert(64);
            Console.WriteLine("Bevor delete");
            t.Print();
            // Action
            var (prePre, pre, node, dir, _) = t.EvenMoreDetailedSearch(67);
            var (_, nPre) = t.Delete(pre, node, dir);
            pre = (AvlTreeNode) nPre;
            var (_, _, unbalanced, _, balance) =
                t.GetUnbalancedNode(prePre, pre, node, dir);
            Console.WriteLine("After delete 67");
            t.Print();
            
            // Assert
            Assert.AreEqual(65, unbalanced.Value);
            Assert.AreEqual(-2, balance);
            
        }
        
        
        [TestMethod]
        public void GetUnBalancedNodeTest_UnbalancedAfterInsert_2Lvl_OneChild_Left()
        {
            // Setup
            var t = new AVLTree(false);
            t.Insert(10); // 0
            t.Insert(5); // - 
            t.Insert(7); // 0  
            t.Insert(3); // - 
            t.Insert(1); // 0 
            t.Insert(15); // -
            t.Insert(20); // 0 
            t.Insert(12); // 0
            // Action
            AvlTreeNode prePre;
            AvlTreeNode pre;
            BinSearchTree.Direction dir;
            (prePre, pre, _, dir, _) = t.EvenMoreDetailedSearch(2);
            t.Insert(pre, dir, new AvlTreeNode(2));
            var node = dir == BinSearchTree.Direction.Left ? pre.Left : pre.Right;
            (prePre, pre, node, _, _) = t.GetUnbalancedNode(prePre, pre, node, dir);
            t.Print();

            // Assert
            Assert.AreEqual(3, node.Value);
            Assert.AreEqual(5, pre.Value);
            Assert.AreEqual(10, prePre.Value);
            Assert.AreEqual(-2, node.Balance);
            Assert.AreEqual(-2, pre.Balance);
            Assert.AreEqual(-2, prePre.Balance);

        }

    }
}