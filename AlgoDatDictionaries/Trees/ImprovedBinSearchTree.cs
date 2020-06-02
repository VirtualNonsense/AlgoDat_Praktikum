using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class ImprovedBinSearchTree : BinSearchTree
    {
        public override bool Insert(int value)
        {
            var (pre, _, dir, _) = DetailedSearch(value);
            return Insert(pre, dir, new DoubleLinkBinSearchTreeNode(value));
        }


        // ###############################################
        // Private / Protected stuff
        // ###############################################

        /// <summary>
        /// Actual insert method
        /// </summary>
        /// <param name="pre">Predecessor| Node append new TreeNode on</param>
        /// <param name="dir">Direction| Side on which the new Node should be put</param>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool Insert(BinSearchTreeNode pre, Direction dir, DoubleLinkBinSearchTreeNode node)
        {
            switch(dir)
            {
                case Direction.Unset:
                    if (Root != null) return false;
                    Root = node;
                    break;
                case Direction.Left:
                    if (pre.Left != null) return false;
                    pre.Left = node;
                    ((DoubleLinkBinSearchTreeNode)pre.Left).Previous = (DoubleLinkBinSearchTreeNode) pre;
                    break;
                case Direction.Right:
                    if (pre.Right != null) return false;
                    pre.Right = node;
                    ((DoubleLinkBinSearchTreeNode)pre.Right).Previous = (DoubleLinkBinSearchTreeNode) pre;
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
        internal override (bool, BinSearchTreeNode) Delete(BinSearchTreeNode pre, BinSearchTreeNode a, Direction dir)
        {
            if (a == null)
                return (false, pre);
            if (a.Type == BinSearchTreeNode.NodeType.Symmetric)
                return DelSymPred(a);
            
            var b = a.Left ?? a.Right;

            if (pre == null)
            {
                Root = b;
                if (b !=null)
                    ((DoubleLinkBinSearchTreeNode)Root).Previous = null;
                return (true, Root);
            }

            if (dir == Direction.Left)
            {
                pre.Left = b;
                if (b !=null)
                    ((DoubleLinkBinSearchTreeNode)pre.Left).Previous = (DoubleLinkBinSearchTreeNode)pre;
            }
            else
            {
                pre.Right = b;
                if (b !=null)
                    ((DoubleLinkBinSearchTreeNode)pre.Right).Previous = (DoubleLinkBinSearchTreeNode)pre;
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
        protected override (bool, BinSearchTreeNode) DelSymPred(BinSearchTreeNode node)
        {
            // get symmetric predecessor
            var symPred = (DoubleLinkBinSearchTreeNode)(MaxNode(node.Left)).Item2;
            
            // get node bevor symPred
            var preSymPre = symPred.Previous;
            symPred.Previous = null;
            
            // Steal value from symPred
            var tmp = symPred.Value;

            
            // Check if the Node bevor symPred is node
            if (preSymPre.Value == node.Value)
            {
                // remove symPred
                node.Left = node.Left.Left;
                if (node.Left != null)
                    ((DoubleLinkBinSearchTreeNode)node.Left).Previous = (DoubleLinkBinSearchTreeNode)node;
            }
            else
            {
                // remove symPred
                preSymPre.Right = symPred.Left;
                if (preSymPre.Right != null)
                    ((DoubleLinkBinSearchTreeNode)preSymPre.Right).Previous = (DoubleLinkBinSearchTreeNode)preSymPre.Right;
            }

            node.Value = tmp;
            return (true, preSymPre);
        }
    }
}