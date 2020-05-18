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
        public BinSearchTree()
        {
            
        }
        
        // ###############################################
        // ISetSorted
        // ###############################################
        public bool Search(int value)
        {
            return search(value).Item4;
        }

        /// <summary>
        /// asdf
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
                    a = a.left;
                    continue;
                }
                pre = a;
                dir = Direction.Right;
                a = a.right;
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
                    r.Item1.left = new TreeNode(value);
                    break;
                case Direction.Right:
                    r.Item1.right = new TreeNode(value);
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
            switch(t.Item3)
            {
                case Direction.Unset:
                    root = null;
                    break;
                case Direction.Left:
                    t.Item1.left = null;
                    break;
                case Direction.Right:
                    t.Item1.right = null;
                    break;
            }
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
            if (node.right != null)
            {
                InOrder(node.right);
            }
            if (node.left != null)
            {
                InOrder(node.left);
            }
            return node;
        }

        // ###############################################
        // Private Stuff
        // ###############################################
    }
}