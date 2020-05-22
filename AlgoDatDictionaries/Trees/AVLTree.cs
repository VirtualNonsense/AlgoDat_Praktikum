using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;



[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class AVLTree : BinSearchTree
    {
        private readonly int _balanceThreshold = 2;
        private bool _enableBalance = true;

        public AVLTree()
        {
            
        }
        
        /// <summary>
        /// Used for testing
        /// When balance is false the insert and delete method will behave like on the parent class.
        /// </summary>
        /// <param name="enableBalance"></param>
        internal AVLTree(bool enableBalance)
        {
            _enableBalance = enableBalance;
        }
        public override bool Insert(int value)
        {
            var search = base.search(value);
            var result = Insert(search, value);
            if (!result || !_enableBalance) return result;
            var (treeNode, balance) = GetUnbalancedNode(value);
            Balance(treeNode, balance);
            return true;
        }

        public override bool Delete(int value)
        {
            var search = base.search(value);
            var result = Delete(search, value);
            if (!result || !_enableBalance) return result;
            var (treeNode, balance) = GetUnbalancedNode(value);
            Balance(treeNode, balance);
            return true;
        }

        private void Balance(TreeNode node, int balance)
        {
            
        }

        /// <summary>
        /// This function will search similar to search for the given value but will return the first unbalanced node
        /// instead of prenode node directon and found.
        /// </summary>
        /// <param name="value"></param>
        internal (TreeNode, int) GetUnbalancedNode(int value)
        {
            if (root == null)
                return (null, 0);
            var a = root;                
            var balance = a.Balance;
            while(a != null && a.Value != value && Math.Abs(balance) < _balanceThreshold)
            {
                if (value < a.Value)
                {
                    a = a.Left;
                    balance = a.Balance;
                    continue;
                }
                a = a.Right;
                balance = a.Balance;
            }
            return (a, balance);
        }

        
    }
}