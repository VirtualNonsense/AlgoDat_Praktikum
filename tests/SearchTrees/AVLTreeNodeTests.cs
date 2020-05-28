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
            var t = new AvlTreeNode(5);
            
            Assert.AreEqual(0, t.MaxHeight);
        }

        [TestMethod]
        public void MaxHeightTest_RootLeft()
        {
            var t = new AvlTreeNode(5) {Left = new AvlTreeNode(4)};
            Assert.AreEqual(1, t.MaxHeight);
            
        }
        
        [TestMethod]
        public void MaxHeightTest_RootRight()
        {
            var t = new AvlTreeNode(5) {Right = new AvlTreeNode(6)};
            Assert.AreEqual(1, t.MaxHeight);
            
        }
        
        [TestMethod]
        public void MaxHeightTest_RootTwoChildren()
        {
            var t = new AvlTreeNode(5) {Left = new AvlTreeNode(4), Right = new AvlTreeNode(6)};
            Assert.AreEqual(1, t.MaxHeight);
        }
        
        [TestMethod]
        public void MaxHeightTest()
        {
            var t = new AvlTreeNode(5) {
                Left = new AvlTreeNode(3)
                {
                    Left= new AvlTreeNode(2),
                    Right = new AvlTreeNode(4)
                }, 
                Right = new AvlTreeNode(6)
            };
            Assert.AreEqual(2, t.MaxHeight);
        }


        [TestMethod]
        public void BalanceTest_RootOnly()
        {
            
            var t = new AvlTreeNode(5);
            
            Assert.AreEqual(0, t.Balance);
        }
        
        [TestMethod]
        public void BalanceTest_RootLeft()
        {
            var t = new AvlTreeNode(5) {Left = new AvlTreeNode(4)};
            Assert.AreEqual(-1, t.Balance);
            
        }
        
        [TestMethod]
        public void BalanceTest_RootRight()
        {
            var t = new AvlTreeNode(5) {Right = new AvlTreeNode(6)};
            Assert.AreEqual(1, t.Balance);
            
        }
        
        [TestMethod]
        public void BalanceTestTest_RootTwoChildren()
        {
            var t = new AvlTreeNode(5) {Left = new AvlTreeNode(4), Right = new AvlTreeNode(6)};
            Assert.AreEqual(0, t.Balance);
        }
        
        
        [TestMethod]
        public void BalanceTest()
        {
            var t = new AvlTreeNode(5) {
                Left = new AvlTreeNode(3)
                {
                    Left= new AvlTreeNode(2),
                    Right = new AvlTreeNode(4)
                }, 
                Right = new AvlTreeNode(6)
            };
            Assert.AreEqual(-1, t.Balance);
        }

        [TestMethod]
        public void BalanceTest_ComplexTree()
        {
            var t = new AvlTreeNode(5) {
                Left = new AvlTreeNode(3)
                {
                    Left= new AvlTreeNode(1)
                    {
                        Left = new AvlTreeNode(0)
                    },
                    Right = new AvlTreeNode(4)
                }, 
                Right = new AvlTreeNode(6)
                {
                    Right = new AvlTreeNode(10)
                    {
                        Left = new AvlTreeNode(8)
                    }
                    
                }
            };
            Assert.AreEqual(0, t.Balance);
        }

    }
}