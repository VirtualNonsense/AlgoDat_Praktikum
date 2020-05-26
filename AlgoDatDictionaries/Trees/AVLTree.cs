using System;
using System.Runtime.CompilerServices;



[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class AVLTree : BinSearchTree
    {
        private readonly int _balanceThreshold = 2;
        private readonly bool _enableBalance = true;
        

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
            if(!_enableBalance)
                Console.WriteLine("UNBALANCED MODE ENABLED");
        }
        public override bool Insert(int value)
        {
            // Search vor insert node pre
            var (prePre, pre, _, dir, _) = EvenMoreDetailedSearch(value);
            
            // Perform insert
            var result = Insert(pre, dir, value);
            
            // Step out if
            if (!result // Insert was unsuccessful
                || !_enableBalance // Balance debug is enabled
                || dir == Direction.Unset) // Root was inserted 
                return result;
            
            // Get inserted node
            var node = pre == null? Root : (dir == Direction.Left ? pre.Left : pre.Right);
            
            // Search vor unbalanced node
            int balance;
            (prePre, pre, node, dir, balance) = GetUnbalancedNode(prePre, pre, node, dir);
            
            // Balance
            return Balance(prePre, pre, node, dir, balance);
        }

        public override bool Delete(int value)
        {
            // var (pre, node, dir, found) = base.DetailedSearch(value);
            // var (result, newPre) = Delete(pre, node, dir);
            // if (!result || !_enableBalance) return result;
            // var (treeNode, balance) = GetUnbalancedNode(newPre);
            // Balance(treeNode, balance);
            // return true;
            throw new NotImplementedException();
        }

        private bool Balance(TreeNode prePre, TreeNode pre, TreeNode node, Direction dir, int balance)
        {
            // Check if balancing is necessary
            if (Math.Abs(balance) < _balanceThreshold)
                return false;
            
            // Tilted to the left
            if (balance < 0)
            {
                var subBalance = node.Left.Balance;
                
                // SubNode neutral or tilted to the left
                if (subBalance <= 0)
                {
                    // node is right child of pre node
                    if (dir == Direction.Right)
                    {
                        TurnRight(pre, node, node.Left, Direction.Left);
                        return true;
                    }
                    TurnRight(prePre, pre, node, dir);
                    return true;
                }
                // SubNode tilted to the right
                TurnLeft(node, node.Left, node.Left.Right, Direction.Right);
                TurnRight(pre, node, node.Left, Direction.Left);
            }
            
            // Tilted to the right
            else if (balance > 0)
            {
                var subBalance = node.Right.Balance;
                // SubNode neutral or tilted to the right
                if (subBalance >= 0)
                {
                    // node is Left child of pre node
                    if (dir == Direction.Left)
                    {
                        TurnLeft(pre, node, node.Right, Direction.Right);
                        return true;
                    }
                    TurnLeft(prePre, pre, node, dir);
                    return true;
                }
                // SubNode tilted left
                TurnRight(node, node.Right, node.Right.Left, Direction.Left);
                TurnLeft(pre, node, node.Right, Direction.Right);
            }
            
            return true;
        }

        internal (TreeNode, TreeNode, TreeNode, Direction, int) GetUnbalancedNode(TreeNode prePre, 
                                                                            TreeNode pre, 
                                                                            TreeNode node,
                                                                            Direction dir)
        {
            // Step out if node is root
            if (prePre == null || pre == null)
                return (prePre, pre, node, dir, node.Balance);
            
            // Iterate until node is root or steps over threshold.
            while (true)
            {
                var balance = node.Balance;
                if (Math.Abs(balance) >= _balanceThreshold || pre == null)
                    return (prePre, pre, node, dir, balance);
                (prePre, pre, node, dir, _) = EvenMoreDetailedSearch(pre.Value);
            }
        }


        protected override string IntendPrint(TreeNode node, int intend, bool endOfLine = true, Direction dir = Direction.Unset)
        {
            var b = node.Balance;
            var bString = "0";
            if (b < 0)
                bString = new string('-', Math.Abs(b));
            else if (b > 0)
                bString = new string('+', b);

            return base.IntendPrint($"{node.Value}[{bString}]", intend, endOfLine, dir);
        }
    }
}