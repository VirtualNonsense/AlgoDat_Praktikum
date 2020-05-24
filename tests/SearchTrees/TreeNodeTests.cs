using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace tests.SearchTrees
{
    [TestClass]
    public class TreeNodeTests
    {
        [TestMethod]
        public void MaxHeightTest_RootOnly()
        {
            TreeNode t = new TreeNode(5);
            
            Assert.AreEqual(0, t.MaxHeight);
        }

        [TestMethod]
        public void MaxHeightTest_RootLeft()
        {
            TreeNode t = new TreeNode(5) {Left = new TreeNode(4)};
            Assert.AreEqual(1, t.MaxHeight);
            
        }
        
        [TestMethod]
        public void MaxHeightTest_RootRight()
        {
            TreeNode t = new TreeNode(5) {Right = new TreeNode(6)};
            Assert.AreEqual(1, t.MaxHeight);
            
        }
        
        [TestMethod]
        public void MaxHeightTest_RootTwoChildren()
        {
            TreeNode t = new TreeNode(5) {Left = new TreeNode(4), Right = new TreeNode(6)};
            Assert.AreEqual(1, t.MaxHeight);
        }
        
        [TestMethod]
        public void MaxHeightTest()
        {
            TreeNode t = new TreeNode(5) {
                Left = new TreeNode(3)
                {
                    Left= new TreeNode(2),
                    Right = new TreeNode(4)
                }, 
                Right = new TreeNode(6)
            };
            Assert.AreEqual(2, t.MaxHeight);
        }


        [TestMethod]
        public void BalanceTest_RootOnly()
        {
            
            TreeNode t = new TreeNode(5);
            
            Assert.AreEqual(0, t.Balance);
        }
        
        [TestMethod]
        public void BalanceTest_RootLeft()
        {
            TreeNode t = new TreeNode(5) {Left = new TreeNode(4)};
            Assert.AreEqual(-1, t.Balance);
            
        }
        
        [TestMethod]
        public void BalanceTest_RootRight()
        {
            TreeNode t = new TreeNode(5) {Right = new TreeNode(6)};
            Assert.AreEqual(1, t.Balance);
            
        }
        
        [TestMethod]
        public void BalanceTestTest_RootTwoChildren()
        {
            TreeNode t = new TreeNode(5) {Left = new TreeNode(4), Right = new TreeNode(6)};
            Assert.AreEqual(0, t.Balance);
        }
        
        
        [TestMethod]
        public void BalanceTest()
        {
            TreeNode t = new TreeNode(5) {
                Left = new TreeNode(3)
                {
                    Left= new TreeNode(2),
                    Right = new TreeNode(4)
                }, 
                Right = new TreeNode(6)
            };
            Assert.AreEqual(-1, t.Balance);
        }

        [TestMethod]
        public void BalanceTest_ComplexTree()
        {
            TreeNode t = new TreeNode(5) {
                Left = new TreeNode(3)
                {
                    Left= new TreeNode(1)
                    {
                        Left = new TreeNode(0)
                    },
                    Right = new TreeNode(4)
                }, 
                Right = new TreeNode(6)
                {
                    Right = new TreeNode(10)
                    {
                        Left = new TreeNode(8)
                    }
                    
                }
            };
            Assert.AreEqual(0, t.Balance);
        }

    }
}