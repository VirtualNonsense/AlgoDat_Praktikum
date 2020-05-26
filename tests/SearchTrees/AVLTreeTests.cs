using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            (_, pre) = t.Delete(pre, node, dir);

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
            (_, pre) = t.Delete(pre, node, dir);
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
            (_, pre) = t.Delete(pre, node, dir);
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
            TreeNode prePre;
            TreeNode pre;
            BinSearchTree.Direction dir;
            (prePre, pre, _, dir, _) = t.EvenMoreDetailedSearch(2);
            t.Insert(pre, dir, 2);
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