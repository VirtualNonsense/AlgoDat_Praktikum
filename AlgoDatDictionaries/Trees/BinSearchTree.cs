﻿using System;
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
                    break;
                case Direction.Right:
                    r.Item1.Right = new TreeNode(value);
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
                             pre.Left = null;
                            break;
                        case Direction.Right:
                            pre.Right = null;
                            break;
                    }
                    break;
                case TreeNode.NodeType.OneChild:
                    switch (predDir)
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
                    switch (predDir)
                    {
                        case Direction.Unset:
                            root.Value = root.Left.Value;
                            RemoveNode(root, root.Left, Direction.Left);
                            break;
                        default:
                            node.Value = node.Left.Value;
                            RemoveNode(node, node.Left, Direction.Left);
                            break;
                    }
                    break;
            }
        }
    }
}