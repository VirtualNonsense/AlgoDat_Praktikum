using System;
using System.Runtime.CompilerServices;
using System.Text;



[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class AVLTree : BinSearchTree
    {
        private readonly int _balanceThreshold = 2;
        internal bool EnableBalance { get; set; } = true;

        protected new AvlTreeNode Root
        {
            get => (AvlTreeNode) base.Root;
            set => base.Root = value;
        }
        


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

        protected override BinSearchTreeNode ConstructTreeNode(int value)
        {
            return new AvlTreeNode(value);
        }

        public override bool Delete(int value)
        {
            // Search vor insert node pre
            var (prePre, pre, node, dir, _) = EvenMoreDetailedSearch(value);
            var (result, newPre) = Delete(pre, node, dir);
            
            
            // Step out if
            if (!result // Delete was unsuccessful
                || !EnableBalance // Balance debug is enabled
                || Root == null)  // Tree is empty
                return result;
            
            (prePre, pre, node, dir, _) = EvenMoreDetailedSearch(newPre.Value);
            // Search vor unbalanced node
            int balance;
            (prePre, pre, node, dir, balance) = GetUnbalancedNode(prePre, pre, node, dir);
            
            // Balance tree
            Balance(prePre, pre, node, dir, balance);
            
            // Delete Successful
            return true;
            
        }

        private bool Balance(AvlTreeNode prePre, AvlTreeNode pre, AvlTreeNode node, Direction dir, int balance)
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
                    (prePre, pre, node, dir, _) = pre == null? EvenMoreDetailedSearch(Root.Value) : EvenMoreDetailedSearch(pre.Value); 
                    (prePre, pre, node, dir, balance) = GetUnbalancedNode(prePre, pre, node, dir);
                    return Balance(prePre, pre, node, dir, balance);
                    
                }
                // SubNode tilted to the right
                TurnLeft(node, node.Left, node.Left.Right, Direction.Right);
                TurnRight(pre, node, node.Left, Direction.Left);
                (prePre, pre, node, dir, _) = pre == null? EvenMoreDetailedSearch(Root.Value) : EvenMoreDetailedSearch(pre.Value); 
                (prePre, pre, node, dir, balance) = GetUnbalancedNode(prePre, pre, node, dir);
                return Balance(prePre, pre, node, dir, balance);
            }
            
            // Tilted to the right
            else if (balance > 0)
            {
                var subBalance = node.Right.Balance;
                // SubNode neutral or tilted to the right
                if (subBalance >= 0)
                {
                    TurnLeft(pre, node, node.Right, Direction.Right);
                    (prePre, pre, node, dir, _) = pre == null? EvenMoreDetailedSearch(Root.Value) : EvenMoreDetailedSearch(pre.Value); 
                    (prePre, pre, node, dir, balance) = GetUnbalancedNode(prePre, pre, node, dir);
                    return Balance(prePre, pre, node, dir, balance);
                }
                // SubNode tilted left
                TurnRight(node, node.Right, node.Right.Left, Direction.Left);
                TurnLeft(pre, node, node.Right, Direction.Right);
                (prePre, pre, node, dir, _) = pre == null? EvenMoreDetailedSearch(Root.Value) : EvenMoreDetailedSearch(pre.Value); 
                (prePre, pre, node, dir, balance) = GetUnbalancedNode(prePre, pre, node, dir);
                return Balance(prePre, pre, node, dir, balance);
            }
            
            return true;
        }

        internal (AvlTreeNode, AvlTreeNode, AvlTreeNode, Direction, int) GetUnbalancedNode(
                                                                            AvlTreeNode prePre, 
                                                                            AvlTreeNode pre, 
                                                                            AvlTreeNode node,
                                                                            Direction dir)
        {
            if (node == null)
                return (null, null, null, Direction.Unset, 0);
            
            // Check if children for threshold bevor going up the tree
            if (node.Type != BinSearchTreeNode.NodeType.Leaf)
            {
                if (node.Type == BinSearchTreeNode.NodeType.Symmetric)
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
                var (nPrePre, nPre, n, nDir, _) =EvenMoreDetailedSearch(pre.Value);
                (prePre, pre, node, dir) = (nPrePre, nPre, n, nDir);
            }
        }
        
        


        protected override string IntendPrint(BinSearchTreeNode node, int intend, bool endOfLine = true, Direction dir = Direction.Unset)
        {
            var n = (AvlTreeNode) node;
            var b = n.Balance;
            var bString = "0";
            if (b < 0)
                bString = new string('-', Math.Abs(b));
            else if (b > 0)
                bString = new string('+', b);

            return base.IntendPrint($"{node.Value}[{bString}]", intend, endOfLine, dir);
        }

        internal new (AvlTreeNode, AvlTreeNode, AvlTreeNode, Direction, bool) EvenMoreDetailedSearch(int value)
        {
            var (prePre, pre, node, dir, found) = base.EvenMoreDetailedSearch(value);
            return ((AvlTreeNode) prePre, (AvlTreeNode) pre, (AvlTreeNode) node, dir, found);
        }
        
    }
}