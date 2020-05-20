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
        public void InternalSeachRootTest_found()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;

            t.Insert(value);

            var r = t.search(value);

            Assert.IsNull(r.Item1);
            Assert.AreEqual(value, r.Item2.value);
            Assert.AreEqual(BinSearchTree.Direction.Unset, r.Item3);
            Assert.IsTrue(r.Item4);
        }

        [TestMethod]
        public void InternalSeachRootTest_notfound()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;

            t.Insert(4);

            var r = t.search(value);

            Assert.AreEqual(4, r.Item1.value);
            Assert.IsNull(r.Item2);
            Assert.AreEqual(BinSearchTree.Direction.Right, r.Item3);
            Assert.IsFalse(r.Item4);
        }

        [TestMethod]
        public void InternalSeachRightToRootTest_found()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 5;

            t.Insert(4);
            t.Insert(value);

            var r = t.search(value);

            Assert.AreEqual(4, r.Item1.value);
            Assert.AreEqual(value, r.Item2.value);
            Assert.AreEqual(BinSearchTree.Direction.Right, r.Item3);
            Assert.IsTrue(r.Item4);
        }


        [TestMethod]
        public void InternalSeachLeftToRootTest_found()
        {
            BinSearchTree t = new BinSearchTree();
            int value = 3;

            t.Insert(4);
            t.Insert(value);

            var r = t.search(value);

            Assert.AreEqual(4, r.Item1.value);
            Assert.AreEqual(value, r.Item2.value);
            Assert.AreEqual(BinSearchTree.Direction.Left, r.Item3);
            Assert.IsTrue(r.Item4);
        }


        [TestMethod]
        public void InternalSeachRootNullTest_notfound()
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
        public void DeleteTest_Delete_TwoChildNode()
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
            Assert.AreEqual("\t7\n" + "5\n", s);
        }
        [TestMethod]
        public void GeneratePrintString_RootAndLeftChild()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            t.Insert(2);
            string s = t.GeneratePrintString();
            Assert.AreEqual( "5\n" + "\t2\n", s);
        }
        
        
        [TestMethod]
        public void GeneratePrintString_RootChildren()
        {
            BinSearchTree t = new BinSearchTree(); 
            t.Insert(5);
            t.Insert(7);
            t.Insert(2);
            string s = t.GeneratePrintString();
            Assert.AreEqual("\t7\n" + "5\n" + "\t2\n", s);
        }

        [TestMethod]
        public void GeneratePrintSting_TreeTest()
        {
            BinSearchTree t = new BinSearchTree();
            string tree =
                "\t\t\t15\n" +
                "\t\t\t\t12\n" +
                "\t\t10\n" +
                "\t\t\t8\n" +
                "\t7\n" +
                "\t\t6\n" +
                "5\n" +
                "\t\t3\n" +
                "\t2\n" +
                "\t\t1\n";

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