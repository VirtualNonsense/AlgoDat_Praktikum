using System;
using System.Numerics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class BinSearchTree : ISetSorted
    {
        private char _intendString = '\t';
        private char _eol = '\n';
        
        public enum Direction
        {
            Unset,
            Left,
            Right
        }
        

        protected TreeNode root;
        
        // ###############################################
        // Constructor
        // ###############################################

        // ###############################################
        // ISetSorted
        // ###############################################
        public bool Search(int value)
        {
            return search(value).Item4;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Item1 PreNode, Item2 Node, Item3 Direction, Item4 found</returns>
        internal (TreeNode, TreeNode, Direction, bool) search(int value)
        {
            TreeNode a = root;
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


        public virtual bool Insert(int value)
        {
            var (pre, node, dir, found) = search(value);
            return Insert(pre, dir, found, value);
        }

        public virtual bool Delete(int value)
        {
            var (pre, node, dir, found) = search(value);
            return Delete(pre, node, dir, found);
        }
        

        public void Print()
        {
            Console.WriteLine(GeneratePrintString());
        }


        internal string GeneratePrintString()
        {
            return GeneratePrintString(root, 0);
        }
        
        internal string GeneratePrintString(TreeNode node, int intend)
        {
            switch (node.Type)
            {
                case TreeNode.NodeType.Leaf:
                    return IntendPrint($"{node.Value}", intend);
                default:
                    string tmp = "";
                    if (node.Right != null)
                        tmp += GeneratePrintString(node.Right, intend + 1);
                    tmp += IntendPrint($"{node.Value}", intend);
                    if (node.Left != null)
                        tmp += GeneratePrintString(node.Left, intend + 1);
                    return tmp;
            }
            
        }

        // ###############################################
        // Private Stuff
        // ###############################################

        protected bool Insert(TreeNode pre, Direction dir, bool found, int value)
        {
            if(found)
            {
                return false;
            }
            switch(dir)
            {
                case Direction.Unset:
                    root = new TreeNode(value);
                    break;
                case Direction.Left:
                    pre.Left = new TreeNode(value);
                    pre.Left.Previous = pre;
                    break;
                case Direction.Right:
                    pre.Right = new TreeNode(value);
                    pre.Right.Previous = pre;
                    break;
            }
            return true;
        }

        protected bool Delete(TreeNode pre, TreeNode a, Direction dir, bool found)
        {
            if (!found)
                return false;
            if (a.Type == TreeNode.NodeType.Symmetric)
                return DelSymPred(a);
            
            var b = a.Left ?? a.Right;

            if (pre == null)
            {
                root = b;
                if (b !=null)
                    root.Previous = null;
                return true;
            }

            if (dir == Direction.Left)
            {
                pre.Left = b;
                pre.Left.Previous = pre;
            }
            else
            {
                pre.Right = b;
                pre.Right.Previous = pre;
            }
            return true;
        }
        

        private string IntendPrint(string value, int intend)
        {
            return new string(_intendString, intend) + (intend > 0? "----" : "") + value + _eol;
        }
        private static bool DelSymPred(TreeNode node)
        {
            var symPred = MaxNode(node.Left);
            var preSymPre = symPred.Previous;
            node.Value = symPred.Value;
            if (preSymPre.Value == node.Value)
            {
                node.Left = node.Left.Left;
                if (node.Left != null)
                   node.Left.Previous = node;
            }
            else
            {
                preSymPre.Right = symPred.Left;
                if (preSymPre.Right != null)
                    preSymPre.Right.Previous = preSymPre.Right;
            }
            return true;
        }
        
        protected static TreeNode MaxNode(TreeNode n)
        {
            while (n.Right != null)
            {
                n = n.Right;
            }
            return n;
        }
        protected static TreeNode MinNode(TreeNode n)
        {
            while (n.Left != null)
            {
                n = n.Left;
            }
            return n;
        }
    }
}