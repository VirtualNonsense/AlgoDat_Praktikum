using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class ImprovedBinSearchTree : BinSearchTree
    {
        
        
        
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
        internal override bool Insert(TreeNode pre, Direction dir, int value)
        {
            switch(dir)
            {
                case Direction.Unset:
                    if (Root != null) return false;
                    Root = new DoubleLinkTreeNode(value);
                    break;
                case Direction.Left:
                    if (pre.Left != null) return false;
                    pre.Left = new DoubleLinkTreeNode(value);
                    ((DoubleLinkTreeNode)pre.Left).Previous = (DoubleLinkTreeNode) pre;
                    break;
                case Direction.Right:
                    if (pre.Right != null) return false;
                    pre.Right = new DoubleLinkTreeNode(value);
                    ((DoubleLinkTreeNode)pre.Right).Previous = (DoubleLinkTreeNode) pre;
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
        internal override (bool, TreeNode) Delete(TreeNode pre, TreeNode a, Direction dir)
        {
            if (a == null)
                return (false, pre);
            if (a.Type == TreeNode.NodeType.Symmetric)
                return DelSymPred(a);
            
            var b = a.Left ?? a.Right;

            if (pre == null)
            {
                Root = b;
                if (b !=null)
                    ((DoubleLinkTreeNode)Root).Previous = null;
                return (true, Root);
            }

            if (dir == Direction.Left)
            {
                pre.Left = b;
                if (b !=null)
                    ((DoubleLinkTreeNode)pre.Left).Previous = (DoubleLinkTreeNode)pre;
            }
            else
            {
                pre.Right = b;
                if (b !=null)
                    ((DoubleLinkTreeNode)pre.Right).Previous = (DoubleLinkTreeNode)pre;
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
        protected override (bool, TreeNode) DelSymPred(TreeNode node)
        {
            // get symmetric predecessor
            var symPred = (DoubleLinkTreeNode)(MaxNode(node.Left)).Item2;
            
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
                    ((DoubleLinkTreeNode)node.Left).Previous = (DoubleLinkTreeNode)node;
            }
            else
            {
                // remove symPred
                preSymPre.Right = symPred.Left;
                if (preSymPre.Right != null)
                    ((DoubleLinkTreeNode)preSymPre.Right).Previous = (DoubleLinkTreeNode)preSymPre.Right;
            }

            node.Value = tmp;
            return (true, preSymPre);
        }
    }
}