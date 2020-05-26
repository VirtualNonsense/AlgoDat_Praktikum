using System;
using System.Runtime.CompilerServices;



[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class AVLTree : BinSearchTree
    {
        private readonly int _balanceThreshold = 2;
        internal bool EnableBalance { get; set; } = true;


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
            EnableBalance = enableBalance;
            if(!EnableBalance)
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
                || !EnableBalance // Balance debug is enabled
                || dir == Direction.Unset) // Root was inserted 
                return result;
            
            // Get inserted node
            var node = pre == null? Root : (dir == Direction.Left ? pre.Left : pre.Right);
            
            // Search vor unbalanced node
            int balance;
            (prePre, pre, node, dir, balance) = GetUnbalancedNode(prePre, pre, node, dir);
            
            // Balance
            Balance(prePre, pre, node, dir, balance);
            
            // Insert successful
            return true;
        }

        public override bool Delete(int value)
        {
            // Search vor insert node pre
            var (prePre, pre, node, dir, _) = EvenMoreDetailedSearch(value);
            var (result, newPre) = Delete(pre, node, dir);
            
            // overwriting pre to avoid confusion about what to use
            pre = newPre;
            
            // Step out if
            if (!result // Delete was unsuccessful
                || !EnableBalance) // Balance debug is enabled)
                return result;
            
            // Search vor unbalanced node
            int balance;
            (prePre, pre, node, dir, balance) = GetUnbalancedNode(prePre, pre, node, dir);
            
            // Balance tree
            Balance(prePre, pre, node, dir, balance);
            
            // Delete Successful
            return true;
            
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
                    TurnRight(pre, node, node.Left, Direction.Left);
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
                    TurnLeft(pre, node, node.Right, Direction.Right);
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
            
            // Check if children for threshold bevor going up the tree
            if (node.Type != TreeNode.NodeType.Leaf)
            {
                if (node.Type == TreeNode.NodeType.Symmetric)
                {
                    var lB = node.Left.Balance;
                    var rB = node.Right.Balance;
                    if (Math.Abs(lB) > Math.Abs(rB) && Math.Abs(lB) > _balanceThreshold)
                        return (pre, node, node.Left, Direction.Left, lB);
                    if (Math.Abs(rB) > _balanceThreshold)
                        return (pre, node, node.Right, Direction.Right, rB);
                }

                var c = node.Left ?? node.Right;
                dir = node.Left != null ? Direction.Left : Direction.Right; 
                var b = c.Balance;
                if (Math.Abs(b) > _balanceThreshold)
                    return (pre, node, c, dir ,b);
            }
            
            
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