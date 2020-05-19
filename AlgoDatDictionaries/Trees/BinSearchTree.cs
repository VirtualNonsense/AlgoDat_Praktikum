using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("tests")]

namespace AlgoDatDictionaries.Trees
{
    public class BinSearchTree : ISetSorted
    {
        internal enum Direction
        {
            Unset,
            Left,
            Right
        }
        

        private TreeNode root;
        
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
            while(a != null && a.value != value)
            {
                if (value < a.value)
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


        public bool Insert(int value)
        {
            var r = search(value);
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
                    break;
                case Direction.Right:
                    r.Item1.Right = new TreeNode(value);
                    break;
            }
            return true;
        }


        public bool Delete(int value)
        {
            var t = search(value);
            if(!t.Item4)
            {
                return false;
            }
            RemoveNode(t.Item1, t.Item2, t.Item3);
            return true;
        }
        

        public void Print()
        {
            GeneratePrintString();
        }
        
        internal string GeneratePrintString()
        {
            TreeNode tmp = root;
            string s="";
            if (tmp == null)
            {
                Console.WriteLine("Tree is empty");
            }
            while (tmp != null )
            {
                //#######unfinisched
                tmp = InOrder(tmp);
                s += $"{tmp.value} ";
                //#######
            }
            Console.WriteLine();
            return s;
        } 
        internal TreeNode InOrder(TreeNode node)
        {
            if (node.Right != null)
            {
                InOrder(node.Right);
            }
            if (node.Left != null)
            {
                InOrder(node.Left);
            }
            return node;
        }

        // ###############################################
        // Private Stuff
        // ###############################################

        private void RemoveNode(TreeNode pre , TreeNode node, Direction prediDir)
        {
            switch (node.Type)
            {
                case TreeNode.NodeType.Leaf:
                    switch (prediDir)
                    {
                        case Direction.Unset:
                            root = null;
                            break;
                        case Direction.Left:
                             pre.Left = null;
                            break;
                        case Direction.Right:
                            pre.Right = null;
                            break;
                    }
                    break;
                case TreeNode.NodeType.OneChild:
                    switch (prediDir)
                    {
                        case Direction.Unset:
                            root = root.Left ?? root.Right;
                            break;
                        case Direction.Left:
                            pre.Left = root.Left ?? root.Right;
                            break;
                        case Direction.Right:
                            pre.Right = root.Left ?? root.Right;
                            break;
                    }
                    break;
                case TreeNode.NodeType.TwoChildren:
                    switch (prediDir)
                    {
                        case Direction.Unset:
                            root.value = root.Left.value;
                            RemoveNode(root, root.Left, Direction.Left);
                            break;
                        default:
                            node.value = node.Left.value;
                            RemoveNode(node, node.Left, Direction.Left);
                            break;
                    }
                    break;
            }
        }
    }
}