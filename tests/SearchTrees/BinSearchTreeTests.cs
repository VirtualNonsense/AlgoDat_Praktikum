using System;
using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.SearchTrees
{
    [TestClass]
    public class BinSearchTreeTests
    {
        [TestMethod]
        public void InsertTest()
        {
            var t = new BinSearchTree();
            
            Assert.IsTrue(t.Insert(5));           
            Assert.IsFalse(t.Insert(5));
        }

        [TestMethod]
        public void PublicSearchTest()
        {
            var t = new BinSearchTree();

            t.Insert(5);
            Assert.IsTrue(t.Search(5));
        }

        [TestMethod]
        public void InternalSearchRootTest_found()
        {
            var t = new BinSearchTree();
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
            var t = new BinSearchTree();
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
            var t = new BinSearchTree();
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
            var t = new BinSearchTree();
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
            var t = new BinSearchTree();
            var (pre, node, direction, found) = t.DetailedSearch(5);

            Assert.IsNull(pre);
            Assert.IsNull(node);
            Assert.AreEqual(BinSearchTree.Direction.Unset, direction);
            Assert.IsFalse(found);
        }

        [TestMethod]
        public void InsertTest_InsertFirstElement_True()
        {
            var t = new BinSearchTree();
            var success = t.Insert(5);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void InsertTest_InsertSecondElement_SameAsRoot()
        {
            var t = new BinSearchTree();
            t.Insert(5);
            var success = t.Insert(5);

            Assert.IsFalse(success);
        }


        [TestMethod]
        public void DeleteTest_TrueAfterDelete()
        {
            var t = new BinSearchTree();
            const int value = 5;
            t.Insert(value);
            var deleted = t.Delete(value);
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void DeleteTest_FalseIfNotInTree()
        {
            var t = new BinSearchTree();
            const int value = 5;
            var deleted = t.Delete(value);
            Assert.IsFalse(deleted);
        }

        [TestMethod]
        public void DeleteTest_CheckIfDelete()
        {
            var t = new BinSearchTree();
            const int value = 5;
            t.Insert(value);
            var deleted = t.Delete(value);
            Assert.IsFalse(t.Search(value));
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void DeleteTest_ComplexTree()
        {
            var t = new BinSearchTree();
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
            var t = new BinSearchTree();
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
            var t = new BinSearchTree();
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
        public void DeleteTest_DeleteNodeWithTwoChildren_SymPreHasTwoChildrenAsWell()
        {
            var t = new BinSearchTree();
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
        public void GeneratePrintString_JustRoot()
        {
            var t = new BinSearchTree(); 
            t.Insert(5);
            var s = t.GeneratePrintString();
            t.Print();
            Assert.AreEqual("5\n", s);
        }

        [TestMethod]
        public void GeneratePrintString_RootAndRightChild()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            t.Insert(7);
            string s = t.GeneratePrintString();
            t.Print();
            Assert.AreEqual("╭---7\n" + "5\n", s);
        }
        [TestMethod]
        public void GeneratePrintString_RootAndLeftChild()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            t.Insert(2);
            string s = t.GeneratePrintString();
            t.Print();
            Assert.AreEqual( "5\n" + "╰---2\n", s);
        }
        
        
        [TestMethod]
        public void GeneratePrintString_RootChildren()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            t.Insert(7);
            t.Insert(2);
            string s = t.GeneratePrintString();
            t.Print();
            Assert.AreEqual("╭---7\n" + "5\n" + "╰---2\n", s);
        }

        [TestMethod]
        public void GeneratePrintString_TreeTest()
        {
            BinSearchTree t = new BinSearchTree();
            string tree =
                "\t\t╭---15\n" +
                "\t\t\t╰---12\n" +
                "\t╭---10\n" +
                "\t\t╰---8\n" +
                "╭---7\n" +
                "\t╰---6\n" +
                "5\n" +
                "\t╭---3\n" +
                "╰---2\n" +
	            "\t╰---1\n";

            t.Insert(5);
            t.Insert(7);
            t.Insert(2);
            t.Insert(3);
            t.Insert(1);
            t.Insert(10);
            t.Insert(15);
            t.Insert(12);
            t.Insert(8);
            t.Insert(6);
            t.Print();
            Assert.AreEqual(tree, t.GeneratePrintString());
            
        }

        [TestMethod]
        public void GeneratePrintString_EmptyTree()
        {
            // Setup
            var t = new BinSearchTree();
            // Action
            var s = t.GeneratePrintString();
            // Assert
            Assert.AreEqual("", s);
            
        }
        [TestMethod]
        public void TurnLeftTest_TurnAroundRoot_SymNode()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre, pre, node, dir, _) = t.EvenMoreDetailedSearch(10);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(15);
            a.Insert(10);
            a.Insert(5);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        
        [TestMethod]
        public void TurnLeftTest_TurnAroundRootChild_Leaf()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(15);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(15);
            a.Insert(10);
            a.Insert(5);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnLeftTest_TurnAround2LvlRootChild_Leaf()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(20);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(20);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(10);
            a.Insert(20);
            a.Insert(15);
            a.Insert(5);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnLeftTest_TurnAround2LvlRootChild_OneChild_Left()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(20);
            t.Insert(17);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(20);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(10);
            a.Insert(20);
            a.Insert(15);
            a.Insert(5);
            a.Insert(17);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        
        [TestMethod]
        public void TurnLeftTest_TurnAround2LvlRootChild_OneChild_Right()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(20);
            t.Insert(40);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(20);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(10);
            a.Insert(20);
            a.Insert(40);
            a.Insert(15);
            a.Insert(5);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        [TestMethod]
        public void TurnLeftTest_TurnAround2LvlRootChild_SymNode()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(20);
            t.Insert(17);
            t.Insert(40);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(20);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(10);
            a.Insert(20);
            a.Insert(40);
            a.Insert(15);
            a.Insert(5);
            a.Insert(17);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        
        
        [TestMethod]
        public void TurnLeftTest_TurnAround3LvlRootChild_Leaf()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(20);
            t.Insert(40);
            t.Insert(50);
            t.Insert(70);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(70);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(20);;
            a.Insert(40);
            a.Insert(70);
            a.Insert(50);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }

        [TestMethod]
        public void TurnLeftTest_TurnAround3LvlRootChild_OneChild_Left()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(20);
            t.Insert(40);
            t.Insert(50);
            t.Insert(70);
            t.Insert(69);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(70);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(20);;
            a.Insert(40);
            a.Insert(70);
            a.Insert(50);
            a.Insert(69);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        
        [TestMethod]
        public void TurnLeftTest_TurnAround3LvlRootChild_OneChild_Right()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(20);
            t.Insert(40);
            t.Insert(50);
            t.Insert(70);
            t.Insert(100);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(70);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(20);
            a.Insert(40);
            a.Insert(70);
            a.Insert(100);
            a.Insert(50);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnLeftTest_TurnAround3LvlRootChild_SymNode()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(20);
            t.Insert(40);
            t.Insert(50);
            t.Insert(70);
            t.Insert(69);
            t.Insert(100);
            
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(70);
            t.TurnLeft(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(20);;
            a.Insert(40);
            a.Insert(70);
            a.Insert(100);
            a.Insert(50);
            a.Insert(69);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        
        [TestMethod]
        public void TurnLeftTest_TurnAroundRightChild_InvalidOperationException()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Print();

            // Action
            var (pre, node, dir, _) = t.DetailedSearch(5);
            Assert.ThrowsException<InvalidOperationException>(() => t.TurnLeft(null, pre, node, dir));
        }
        
        [TestMethod]
        public void TurnRightTest_TurnAroundRoot_SymNode()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre, pre, node, dir, _) = t.EvenMoreDetailedSearch(10);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(5);
            a.Insert(10);
            a.Insert(15);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnRightTest_TurnAroundRootChild_Leaf()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(5);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(5);
            a.Insert(10);
            a.Insert(15);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnRightTest_TurnAround2LvlRootChild_Leaf()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(3);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(3);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(10);
            a.Insert(3);
            a.Insert(15);
            a.Insert(5);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnRightTest_TurnAround2LvlRootChild_OneChild_Left()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(3);
            t.Insert(1);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(3);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(10);
            a.Insert(3);
            a.Insert(15);
            a.Insert(1);
            a.Insert(5);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnRightTest_TurnAround2LvlRootChild_OneChild_Right()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(3);
            t.Insert(4);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(3);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(10);
            a.Insert(3);
            a.Insert(15);
            a.Insert(5);
            a.Insert(4);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        [TestMethod]
        public void TurnRightTest_TurnAround2LvlRootChild_SymNode()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(3);
            t.Insert(1);
            t.Insert(4);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(3);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(10);
            a.Insert(3);
            a.Insert(1);
            a.Insert(15);
            a.Insert(5);
            a.Insert(4);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        
        
        [TestMethod]
        public void TurnRightTest_TurnAround3LvlRootChild_Leaf()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(20);
            t.Insert(10);
            t.Insert(5);
            t.Insert(3);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(3);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(20);
            a.Insert(10);
            a.Insert(3);
            a.Insert(5);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnRightTest_TurnAround3LvlRootChild_OneChild_Left()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(20);
            t.Insert(10);
            t.Insert(5);
            t.Insert(3);
            t.Insert(1);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(3);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(20);
            a.Insert(10);
            a.Insert(3);
            a.Insert(1);
            a.Insert(5);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnRightTest_TurnAround3LvlRootChild_OneChild_Right()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(20);
            t.Insert(10);
            t.Insert(5);
            t.Insert(3);
            t.Insert(4);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(3);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(20);
            a.Insert(10);
            a.Insert(3);
            a.Insert(5);
            a.Insert(4);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        
        [TestMethod]
        public void TurnRightTest_TurnAround3LvlRootChild_SymNode()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(20);
            t.Insert(10);
            t.Insert(5);
            t.Insert(3);
            t.Insert(1);
            t.Insert(4);
            Console.WriteLine("bevor");
            t.Print();

            // Action
            var (prePre,pre, node, dir, _) = t.EvenMoreDetailedSearch(3);
            t.TurnRight(prePre, pre, node, dir);
            Console.WriteLine("after");
            t.Print();
            
            // Assert
            var a = new BinSearchTree();
            a.Insert(20);
            a.Insert(10);
            a.Insert(3);
            a.Insert(1);
            a.Insert(5);
            a.Insert(4);
            
            Assert.AreEqual(a.GeneratePrintString(), t.GeneratePrintString());
        }
        
        [TestMethod]
        public void TurnRightTest_TurnAroundRightChild_InvalidOperationException()
        {
            // Setup
            var t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Print();

            // Action
            var (pre, node, dir, _) = t.DetailedSearch(15);
            Assert.ThrowsException<InvalidOperationException>(() => t.TurnRight(null, pre, node, dir));
        }
        
        
    }
}