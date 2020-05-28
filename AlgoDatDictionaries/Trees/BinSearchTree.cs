using System;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class BinSearchTree : ISetSorted
    {
        private const char IntendString = '\t';
        private const string Eol = "\n";
        private const string Branch = "---";
        protected BinSearchTreeNode Root;
        
        public enum Direction
        {
            Unset,
            Left,
            Right
        }
        
        // ###############################################
        // Constructor
        // ###############################################

        // ###############################################
        // ISetSorted
        // ###############################################
        /// <summary>
        /// Search for value in tree structure
        /// Returns true if the value is found
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Search(int value)
        {
            return DetailedSearch(value).Item4;
        }

        /// <summary>
        /// Insert a new node with given value
        /// Returns true if successful
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool Insert(int value)
        {
            var (pre, _, dir, _) = DetailedSearch(value);
            return Insert(pre, dir, value);
        }

        /// <summary>
        /// Delete node with given value
        /// Returns true if successful
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual bool Delete(int value)
        {
            var (pre, node, dir, _) = DetailedSearch(value);
            return Delete(pre, node, dir).Item1;
        }

        /// <summary>
        /// Print a string representation of the current tree into console
        /// </summary>
        public void Print()
        {
            Console.WriteLine(GeneratePrintString());
        }
        
        // ###############################################
        // Internal stuff
        // ###############################################

        /// <summary>
        /// Searches inside tree for value;
        /// if value is found the method returns its predecessor, the node value, the direction relative to pre and
        /// true
        /// if value is not within the tree structure the method will return the TreeNode where it Should be, null, the
        /// direction where the direction where the value should be found and false
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Item1 PreNode, Item2 Node, Item3 Direction, Item4 found</returns>
        internal (BinSearchTreeNode, BinSearchTreeNode, Direction, bool) DetailedSearch(int value)
        {
            var(_, pre, node, dir, found) = EvenMoreDetailedSearch(value);
            return (pre, node, dir, found);
        }
        
        
        /// <summary>
        /// Searches inside tree for value;
        /// if value is found the method returns its predecessor, the node value, the direction relative to pre and
        /// true
        /// if value is not within the tree structure the method will return the TreeNode where it Should be, null, the
        /// direction where the direction where the value should be found and false
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Item1 PreNode, Item2 Node, Item3 Direction, Item4 found</returns>
        internal (BinSearchTreeNode, BinSearchTreeNode, BinSearchTreeNode, Direction, bool) EvenMoreDetailedSearch(int value)
        {
            BinSearchTreeNode a = Root;
            BinSearchTreeNode pre = null;
            BinSearchTreeNode prePre = null;
            Direction dir = Direction.Unset;
            while(a != null && a.Value != value)
            {
                if (value < a.Value)
                {
                    prePre = pre;
                    pre = a;
                    dir = Direction.Left;
                    a = a.Left;
                    continue;
                }
                prePre = pre;
                pre = a;
                dir = Direction.Right;
                a = a.Right;
            }

            return (prePre, pre, a, dir, a != null);
        }

        /// <summary>
        /// Actual insert method
        /// </summary>
        /// <param name="pre">Predecessor| Node append new TreeNode on</param>
        /// <param name="dir">Direction| Side on which the new Node should be put</param>
        /// <param name="value">new Value</param>
        /// <returns></returns>
        internal virtual bool Insert(BinSearchTreeNode pre, Direction dir, int value)
        {
            switch(dir)
            {
                case Direction.Unset:
                    if (Root != null) return false;
                    Root = ConstructTreeNode(value);
                    break;
                case Direction.Left:
                    if (pre.Left != null) return false;
                    pre.Left = ConstructTreeNode(value);
                    break;
                case Direction.Right:
                    if (pre.Right != null) return false;
                    pre.Right = ConstructTreeNode(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
            return true;
        }

        protected virtual BinSearchTreeNode ConstructTreeNode(int value)
        {
            return new BinSearchTreeNode(value);
        }
        
        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="prePreNode"></param>
        /// <param name="preNode">Predecessor of Node</param>
        /// <param name="node"></param>
        /// <param name="dir"></param>
        internal BinSearchTreeNode TurnRight(BinSearchTreeNode prePreNode, BinSearchTreeNode preNode, BinSearchTreeNode node, Direction dir)
        {
            // node is root
            if(dir == Direction.Unset)
            {
                Root = node.Left;
                node.Left = Root.Right;
                Root.Right = node;
                return Root;
            }

            // PreNode is Root
            if(prePreNode == null)
                switch (dir)
                {
                    case Direction.Left:
                        Root = node;
                        preNode.Left = node.Right;
                        Root.Right = preNode;
                        return Root;
                    default:
                        throw new InvalidOperationException("Turning right on left neighbour is not possible");
                }
            
            switch (dir)
            {
                case Direction.Left:
                    if (prePreNode.Left?.Value == preNode.Value)
                        prePreNode.Left = node;
                    else 
                        prePreNode.Right = node;
                    preNode.Left = node.Right;
                    node.Right = preNode;
                    return prePreNode;
                default:
                    throw new InvalidOperationException("Turning right on left neighbour is not possible");
            }
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prePreNode"></param>
        /// <param name="preNode">Predecessor of Node</param>
        /// <param name="node"></param>
        /// <param name="dir"></param>
        internal BinSearchTreeNode TurnLeft(BinSearchTreeNode prePreNode, BinSearchTreeNode preNode, BinSearchTreeNode node, Direction dir)
        {
            // node is root
            if(dir == Direction.Unset)
            {
                Root = node.Right;
                node.Right = Root.Left;
                Root.Left = node;
                return Root;
            }

            // PreNode is Root
            if(prePreNode == null)
                switch (dir)
                {
                    case Direction.Right:
                        Root = node;
                        preNode.Right = node.Left;
                        Root.Left = preNode;
                        return Root;
                    default:
                        throw new InvalidOperationException("Turning left on right neighbour is not possible");
                }
            
            switch (dir)
            {
                case Direction.Right:
                    if (prePreNode.Left?.Value == preNode.Value)
                        prePreNode.Left = node;
                    else 
                        prePreNode.Right = node;
                    preNode.Right = node.Left;
                    node.Left = preNode;
                    return prePreNode;
                default:
                    throw new InvalidOperationException("Turning left on right neighbour is not possible");
            }
        }
        

        /// <summary>
        /// Actual delete method.
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="a"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        internal virtual (bool, BinSearchTreeNode) Delete(BinSearchTreeNode pre, BinSearchTreeNode a, Direction dir)
        {
            if (a == null)
                return (false, pre);
            if (a.Type == BinSearchTreeNode.NodeType.Symmetric)
                return DelSymPred(a);
            
            var b = a.Left ?? a.Right;

            if (pre == null)
            {
                Root = b;
                return (true, Root);
            }

            if (dir == Direction.Left)
            {
                pre.Left = b;
            }
            else
            {
                pre.Right = b;
            }
            return (true, pre);
        }
        
        /// <summary>
        /// Generate a string representation of the current tree
        /// </summary>
        /// <returns></returns>
        internal string GeneratePrintString()
        {
            return  Root != null? GeneratePrintString(Root, 0, Direction.Unset) : "";
        }
        
        // ###############################################
        // Private / Protected stuff
        // ###############################################

        
        /// <summary>
        /// Helper method.
        /// Use to "remove" node when node has two children
        /// Basic idea is to copy 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected virtual (bool, BinSearchTreeNode) DelSymPred(BinSearchTreeNode node)
        {

            var (preSymPre, symPred) = MaxNode(node.Left);

            preSymPre ??= node;
            
            // Steal value from symPred
            var tmp = symPred.Value;

            
            // Check if the Node bevor symPred is node
            if (preSymPre.Value == node.Value)
            {
                // remove symPred
                node.Left = node.Left.Left;
            }
            else
            {
                // remove symPred
                preSymPre.Right = symPred.Left;
            }

            node.Value = tmp;
            return (true, preSymPre);
        }

        

        

        /// <summary>
        /// Generate a string representation of the current tree
        /// </summary>
        /// <param name="node">Start node</param>
        /// <param name="intend">Initial intend</param>
        /// <param name="dir"></param>
        /// <returns></returns>
        private string GeneratePrintString(BinSearchTreeNode node, int intend, Direction dir)
        {
            switch (node.Type)
            {
                case BinSearchTreeNode.NodeType.Leaf:
                    return IntendPrint(node, intend, dir: dir);
                default:
                    var tmp = "";
                    if (node.Right != null)
                        tmp += GeneratePrintString(node.Right, intend + 1, Direction.Right);
                    tmp += IntendPrint(node, intend, dir: dir);
                    if (node.Left != null)
                        tmp += GeneratePrintString(node.Left, intend + 1, Direction.Left);
                    return tmp;
            }
            
        }
        
        /// <summary>
        /// Pretty print with variable intend
        /// </summary>
        /// <param name="node"></param>
        /// <param name="intend"></param>
        /// <param name="endOfLine"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        protected virtual string IntendPrint(BinSearchTreeNode node, int intend, bool endOfLine = true, Direction dir = Direction.Unset)
        {
            return IntendPrint(node.Value.ToString(), intend, endOfLine, dir);
        }
        
        
        /// <summary>
        /// Pretty print with variable intend
        /// </summary>
        /// <param name="node"></param>
        /// <param name="intend"></param>
        /// <param name="endOfLine"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        protected virtual string IntendPrint(string node, int intend, bool endOfLine = true, Direction dir = Direction.Unset)
        {
            var sDir = "-";
            if (dir == Direction.Left)
                sDir = @"╰";
            else if (dir == Direction.Right)
                sDir = @"╭";
            return new string(IntendString, intend>0?intend-1:0) + (intend > 0? sDir + Branch : "") + node + (endOfLine? Eol : "");
        }
        /// <summary>
        /// Returns the most right node and its predecessor from a given start node
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        protected static (BinSearchTreeNode, BinSearchTreeNode) MaxNode(BinSearchTreeNode n)
        {
            BinSearchTreeNode pre = null;
            while (n.Right != null)
            {
                pre = n;
                n = n.Right;
            }
            return (pre, n);
        }
        
        /// <summary>
        /// Returns the most left node and its predecessor from a given start node
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        protected static (BinSearchTreeNode, BinSearchTreeNode) MinNode(BinSearchTreeNode n)
        {
            BinSearchTreeNode pre = null;
            while (n.Left != null)
            {
                pre = n;
                n = n.Left;
            }
            return (pre, n);
        }
    }
}