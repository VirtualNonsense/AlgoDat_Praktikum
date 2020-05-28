using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace tests.SearchTrees
{
    [TestClass]
    public class AVLTreeNodeTests
    {
        [TestMethod]
        public void MaxHeightTest_RootOnly()
        {
            var t = new AvlBinSearchTreeNode(5);
            
            Assert.AreEqual(0, t.MaxHeight);
        }

        [TestMethod]
        public void MaxHeightTest_RootLeft()
        {
            var t = new AvlBinSearchTreeNode(5) {Left = new AvlBinSearchTreeNode(4)};
            Assert.AreEqual(1, t.MaxHeight);
            
        }
        
        [TestMethod]
        public void MaxHeightTest_RootRight()
        {
            var t = new AvlBinSearchTreeNode(5) {Right = new AvlBinSearchTreeNode(6)};
            Assert.AreEqual(1, t.MaxHeight);
            
        }
        
        [TestMethod]
        public void MaxHeightTest_RootTwoChildren()
        {
            var t = new AvlBinSearchTreeNode(5) {Left = new AvlBinSearchTreeNode(4), Right = new AvlBinSearchTreeNode(6)};
            Assert.AreEqual(1, t.MaxHeight);
        }
        
        [TestMethod]
        public void MaxHeightTest()
        {
            var t = new AvlBinSearchTreeNode(5) {
                Left = new AvlBinSearchTreeNode(3)
                {
                    Left= new AvlBinSearchTreeNode(2),
                    Right = new AvlBinSearchTreeNode(4)
                }, 
                Right = new AvlBinSearchTreeNode(6)
            };
            Assert.AreEqual(2, t.MaxHeight);
        }


        [TestMethod]
        public void BalanceTest_RootOnly()
        {
            
            var t = new AvlBinSearchTreeNode(5);
            
            Assert.AreEqual(0, t.Balance);
        }
        
        [TestMethod]
        public void BalanceTest_RootLeft()
        {
            var t = new AvlBinSearchTreeNode(5) {Left = new AvlBinSearchTreeNode(4)};
            Assert.AreEqual(-1, t.Balance);
            
        }
        
        [TestMethod]
        public void BalanceTest_RootRight()
        {
            var t = new AvlBinSearchTreeNode(5) {Right = new AvlBinSearchTreeNode(6)};
            Assert.AreEqual(1, t.Balance);
            
        }
        
        [TestMethod]
        public void BalanceTestTest_RootTwoChildren()
        {
            var t = new AvlBinSearchTreeNode(5) {Left = new AvlBinSearchTreeNode(4), Right = new AvlBinSearchTreeNode(6)};
            Assert.AreEqual(0, t.Balance);
        }
        
        
        [TestMethod]
        public void BalanceTest()
        {
            var t = new AvlBinSearchTreeNode(5) {
                Left = new AvlBinSearchTreeNode(3)
                {
                    Left= new AvlBinSearchTreeNode(2),
                    Right = new AvlBinSearchTreeNode(4)
                }, 
                Right = new AvlBinSearchTreeNode(6)
            };
            Assert.AreEqual(-1, t.Balance);
        }

        [TestMethod]
        public void BalanceTest_ComplexTree()
        {
            var t = new AvlBinSearchTreeNode(5) {
                Left = new AvlBinSearchTreeNode(3)
                {
                    Left= new AvlBinSearchTreeNode(1)
                    {
                        Left = new AvlBinSearchTreeNode(0)
                    },
                    Right = new AvlBinSearchTreeNode(4)
                }, 
                Right = new AvlBinSearchTreeNode(6)
                {
                    Right = new AvlBinSearchTreeNode(10)
                    {
                        Left = new AvlBinSearchTreeNode(8)
                    }
                    
                }
            };
            Assert.AreEqual(0, t.Balance);
        }

    }
}