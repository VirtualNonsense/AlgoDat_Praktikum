using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests.SearchTrees
{
    [TestClass]
    public class BinSearchTreeTests
    {
        [TestMethod]
        public void InsertTest()
        {
            BinSearchTree t = new BinSearchTree();
            
            Assert.IsTrue(t.Insert(5));           
            Assert.IsFalse(t.Insert(5));
        }

        [TestMethod]
        public void PublicSearchTest()
        {
            BinSearchTree t = new BinSearchTree();

            t.Insert(5);
            Assert.IsTrue(t.Search(5));
        }

        [TestMethod]
        public void InternalSearchRootTest_found()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;

            t.Insert(value);

            var r = t.search(value);

            Assert.IsNull(r.Item1);
            Assert.AreEqual(value, r.Item2.Value);
            Assert.AreEqual(BinSearchTree.Direction.Unset, r.Item3);
            Assert.IsTrue(r.Item4);
        }

        [TestMethod]
        public void InternalSearchRootTest_notfound()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;

            t.Insert(4);

            var r = t.search(value);

            Assert.AreEqual(4, r.Item1.Value);
            Assert.IsNull(r.Item2);
            Assert.AreEqual(BinSearchTree.Direction.Right, r.Item3);
            Assert.IsFalse(r.Item4);
        }

        [TestMethod]
        public void InternalSearchRightToRootTest_found()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;

            t.Insert(4);
            t.Insert(value);

            var r = t.search(value);

            Assert.AreEqual(4, r.Item1.Value);
            Assert.AreEqual(value, r.Item2.Value);
            Assert.AreEqual(BinSearchTree.Direction.Right, r.Item3);
            Assert.IsTrue(r.Item4);
        }


        [TestMethod]
        public void InternalSearchLeftToRootTest_found()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 3;

            t.Insert(4);
            t.Insert(value);

            var r = t.search(value);

            Assert.AreEqual(4, r.Item1.Value);
            Assert.AreEqual(value, r.Item2.Value);
            Assert.AreEqual(BinSearchTree.Direction.Left, r.Item3);
            Assert.IsTrue(r.Item4);
        }


        [TestMethod]
        public void InternalSearchRootNullTest_notfound()
        {
            BinSearchTree t = new BinSearchTree();
            var r = t.search(5);

            Assert.IsNull(r.Item1);
            Assert.IsNull(r.Item2);
            Assert.AreEqual(BinSearchTree.Direction.Unset, r.Item3);
            Assert.IsFalse(r.Item4);
        }

        [TestMethod]
        public void InsertTest_InsertFirstElement_True()
        {
            BinSearchTree t = new BinSearchTree();
            bool success = t.Insert(5);

            Assert.IsTrue(success);
        }
        [TestMethod]
        public void InsertTest_InsertSecondElement_SameAsRoot()
        {
            BinSearchTree t = new BinSearchTree();
            t.Insert(5);
            bool success = t.Insert(5);

            Assert.IsFalse(success);
        }


        [TestMethod]
        public void DeleteTest_TrueAfterDelete()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;
            t.Insert(value);
            bool deleted = t.Delete(value);
            Assert.IsTrue(deleted);
        }

        [TestMethod]
        public void DeleteTest_FalseIfNotInTree()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;
            bool deleted = t.Delete(value);
            Assert.IsFalse(deleted);
        }

        [TestMethod]
        public void DeleteTest_CheckIfDelete()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;
            t.Insert(value);
            bool deleted = t.Delete(value);
            Assert.IsFalse(t.Search(value));
            Assert.IsTrue(deleted);
        }
        
        [TestMethod]
        public void DeleteTest_DeleteRoot_CheckRest()
        {
            BinSearchTree t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(15);
            t.Insert(17);
            bool deleted = t.Delete(10);
            Assert.IsTrue(deleted);
            Assert.IsFalse(t.Search(10));
            Assert.IsTrue(t.Search(5));
            Assert.IsTrue(t.Search(15));
            Assert.IsTrue(t.Search(17));
        }

        [TestMethod]
        public void DeleteTest_SymmetricPredecessorIsChild_EzTree()
        {
            BinSearchTree t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(6);
            t.Insert(4);
            bool deleted = t.Delete(5);
            Assert.IsTrue(deleted);
            Assert.IsFalse(t.Search(5));
            Assert.IsTrue(t.Search(4));
            Assert.IsTrue(t.Search(6));
        }
        
        [TestMethod]
        public void DeleteTest_SymmetricPredecessorIsChild_EzTree_CheckForPredecessors()
        {
            BinSearchTree t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(6);
            t.Insert(4);
            Console.WriteLine("Befor delete");
            t.Print();
            bool deleted = t.Delete(5);
            Console.WriteLine("After delete");
            t.Print();
            Assert.IsTrue(deleted);
            var (pre6, node6, dir6, found6) = t.search(6);
            var (pre4, node4, dir4, found4) = t.search(4);
            
            Assert.AreEqual(pre6.Value, node6.Previous.Value);
            Assert.AreEqual(4, node6.Previous.Value);
            Assert.AreEqual(10, node4.Previous.Value);
            Assert.AreEqual(pre4.Value, node4.Previous.Value);
        }

        [TestMethod]
        public void DeleteTest_SymmetricPredecessorIsChild_HiddenSymPre_CheckForPredecessors()
        {
            BinSearchTree t = new BinSearchTree();
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
            Console.WriteLine("Befor delete");
            t.Print();
            
            bool result = t.Delete(67);
            
            Console.WriteLine("After delete");
            t.Print();
            var (pre66, node66, dir66, found66) = t.search(66);
            var (pre56, node56, dir56, found56) = t.search(56);
            var (pre97, node97, dir97, found97) = t.search(97);
            
            Assert.AreEqual(pre66.Value, node66.Previous.Value);
            Assert.AreEqual(45, node66.Previous.Value);
            Assert.AreEqual(pre56.Value, node56.Previous.Value);
            Assert.AreEqual(66, node56.Previous.Value);
            Assert.AreEqual(pre97.Value, node97.Previous.Value);
            Assert.AreEqual(66, node97.Previous.Value);

        }


        public void DeleteTest_DeleteNodeWithTwoChildren_SymPreHasTwoChildrenAsWell()
        {
            BinSearchTree t = new BinSearchTree();
            t.Insert(10);
            t.Insert(5);
            t.Insert(6);
            t.Insert(4);
            bool deleted = t.Delete(5);
            Assert.IsTrue(deleted);
            Assert.IsFalse(t.Search(5));
            Assert.IsTrue(t.Search(4));
            Assert.IsTrue(t.Search(6));
        }

        [TestMethod]
        public void GeneratePrintString_JustRoot()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            string s = t.GeneratePrintString();
            Assert.AreEqual("5\n", s);
        }

        [TestMethod]
        public void GeneratePrintString_RootAndRightChild()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            t.Insert(7);
            string s = t.GeneratePrintString();
            Assert.AreEqual("\t----7\n" + "5\n", s);
        }
        [TestMethod]
        public void GeneratePrintString_RootAndLeftChild()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            t.Insert(2);
            string s = t.GeneratePrintString();
            Assert.AreEqual( "5\n" + "\t----2\n", s);
        }
        
        
        [TestMethod]
        public void GeneratePrintString_RootChildren()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            t.Insert(7);
            t.Insert(2);
            string s = t.GeneratePrintString();
            Assert.AreEqual("\t----7\n" + "5\n" + "\t----2\n", s);
        }

        [TestMethod]
        public void GeneratePrintSting_TreeTest()
        {
            BinSearchTree t = new BinSearchTree();
            string tree =
                "\t\t\t----15\n" +
                "\t\t\t\t----12\n" +
                "\t\t----10\n" +
                "\t\t\t----8\n" +
                "\t----7\n" +
                "\t\t----6\n" +
                "5\n" +
                "\t\t----3\n" +
                "\t----2\n" +
                "\t\t----1\n";

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
            Assert.AreEqual(tree, t.GeneratePrintString());
            
        }

    }
}