using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class BinSearchTree : ISetSorted
    {
        protected const char IntendString = '\t';
        protected const string Eol = "\n";
        protected string Branch = "----";
        protected TreeNode Root;
        
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
        internal (TreeNode, TreeNode, Direction, bool) DetailedSearch(int value)
        {
            TreeNode a = Root;
            TreeNode pre = null;
            Direction dir = Direction.Unset;
            while(a != null && a.Value != value)
            {
                if (value < a.Value)
                {
                    pre = a;
                    dir = Direction.Left;
                    a = a.Left;
                    continue;
                }
                pre = a;
                dir = Direction.Right;
                a = a.Right;
            }

            return (pre, a, dir, a != null);
        }

        /// <summary>
        /// Generate a string representation of the current tree
        /// </summary>
        /// <returns></returns>
        internal string GeneratePrintString()
        {
            return GeneratePrintString(Root, 0);
        }
        
        /// <summary>
        /// Generate a string representation of the current tree
        /// </summary>
        /// <param name="node">Start node</param>
        /// <param name="intend">Initial intend</param>
        /// <returns></returns>
        private string GeneratePrintString(TreeNode node, int intend)
        {
            switch (node.Type)
            {
                case TreeNode.NodeType.Leaf:
                    return IntendPrint(node, intend);
                default:
                    var tmp = "";
                    if (node.Right != null)
                        tmp += GeneratePrintString(node.Right, intend + 1);
                    tmp += IntendPrint(node, intend);
                    if (node.Left != null)
                        tmp += GeneratePrintString(node.Left, intend + 1);
                    return tmp;
            }
            
        }

        // ###############################################
        // Private / Protected stuff
        // ###############################################

        /// <summary>
        /// Actual insert method
        /// </summary>
        /// <param name="pre">Predecessor| Node append new TreeNode on</param>
        /// <param name="dir">Direction| Side on which the new Node should be put</param>
        /// <param name="value">new Value</param>
        /// <returns></returns>
        internal virtual bool Insert(TreeNode pre, Direction dir, int value)
        {
            switch(dir)
            {
                case Direction.Unset:
                    if (Root != null) return false;
                    Root = new TreeNode(value);
                    break;
                case Direction.Left:
                    if (pre.Left != null) return false;
                    pre.Left = new TreeNode(value);
                    break;
                case Direction.Right:
                    if (pre.Right != null) return false;
                    pre.Right = new TreeNode(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
            return true;
        }

        /// <summary>
        /// Actual delete method.
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="a"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        internal virtual (bool, TreeNode) Delete(TreeNode pre, TreeNode a, Direction dir)
        {
            if (a == null)
                return (false, pre);
            if (a.Type == TreeNode.NodeType.Symmetric)
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
        /// Helper method.
        /// Use to "remove" node when node has two children
        /// Basic idea is to copy 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected virtual (bool, TreeNode) DelSymPred(TreeNode node)
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
        /// Pretty print with variable intend
        /// </summary>
        /// <param name="node"></param>
        /// <param name="intend"></param>
        /// <param name="endOfLine"></param>
        /// <returns></returns>
        protected virtual string IntendPrint(TreeNode node, int intend, bool endOfLine = true)
        {
            return new string(IntendString, intend) + (intend > 0? Branch : "") + node.Value + (endOfLine? Eol : "");
        }
        
        /// <summary>
        /// Returns the most right node and its predecessor from a given start node
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        protected static (TreeNode, TreeNode) MaxNode(TreeNode n)
        {
            TreeNode pre = null;
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
        protected static (TreeNode, TreeNode) MinNode(TreeNode n)
        {
            TreeNode pre = null;
            while (n.Left != null)
            {
                pre = n;
                n = n.Left;
            }
            return (pre, n);
        }
    }
}