using System;
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
            var r = search(value);
            return Insert(r, value);
        }

        public virtual bool Delete(int value)
        {
            var t = search(value);
            return Delete(t, value);
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

        protected bool Insert((TreeNode, TreeNode, Direction, bool) r, int value)
        {
            if(r.Item4)
            {
                return false;
            }
            switch(r.Item3)
            {
                case Direction.Unset:
                    root = new TreeNode(value);
                    break;
                case Direction.Left:
                    r.Item1.Left = new TreeNode(value);
                    r.Item1.Left.Previous = r.Item1;
                    break;
                case Direction.Right:
                    r.Item1.Right = new TreeNode(value);
                    r.Item1.Right.Previous = r.Item1;
                    break;
            }
            return true;
        }

        protected bool Delete((TreeNode, TreeNode, Direction, bool) t, int value)
        {
            if(!t.Item4)
            {
                return false;
            }
            RemoveNode(t.Item1, t.Item2, t.Item3);
            return true;
        }
            

        private string IntendPrint(string value, int intend)
        {
            return new string(_intendString, intend) + value + _eol;
        }
        
        private void RemoveNode(TreeNode pre , TreeNode node, Direction predDir)
        {
            switch (node.Type)
            {
                case TreeNode.NodeType.Leaf:
                    switch (predDir)
                    {
                        case Direction.Unset:
                            root = null;
                            break;
                        case Direction.Left:
                            pre.Left.Previous = null;
                            pre.Left = null;
                            break;
                        case Direction.Right:
                            pre.Right.Previous = null;
                            pre.Right = null;
                            break;
                    }
                    break;
                case TreeNode.NodeType.OneChild:
                    switch (predDir)
                    {
                        case Direction.Unset:
                            root = root.Left ?? root.Right;
                            root.Previous = null;
                            break;
                        case Direction.Left:
                            // replacing left child
                            pre.Left = node.Left ?? node.Right;
                            // replacing node as previous node
                            pre.Left.Previous = pre;
                            break;
                        case Direction.Right:
                            // replacing left child
                            pre.Right = node.Left ?? node.Right;
                            // replacing node as previous node
                            pre.Right.Previous = pre.Right;
                            break;
                    }
                    break;
                case TreeNode.NodeType.TwoChildren:
                    TreeNode symPre;
                    switch (predDir)
                    {
                        // Copy value of sym pre and remove sym pre
                        case Direction.Unset:
                            // get sym pre
                            symPre = root.Left.MaxNode;
                            // copy value to root
                            root.Value = symPre.Value;
                            // Check if previous is not root
                            if (symPre.Previous.Value != root.Value)
                                // replacing sym pre by left tree
                                symPre.Previous.Right = symPre.Left;
                            else
                                // removing sym pre
                                root.Left = null;
                            break;
                        default:
                            // get sym pre
                            symPre = node.Left.MaxNode;
                            // copy value to Node
                            node.Value = symPre.Value;
                            // Check if previous is not root
                            if (symPre.Previous.Value != node.Value)
                                // replacing sym pre by left tree
                                symPre.Previous.Right = symPre.Left;
                            else
                                // removing sym pre
                                node.Left = null;
                            break;
                    }
                    break;
            }
        }
    }
}