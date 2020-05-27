using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatDictionaries.Trees
{
    class Treap : BinSearchTree
    {
        public override bool Insert(int value)
        {
            throw new NotImplementedException();
        }
        public override bool Delete(int value)
        {
            throw new NotImplementedException();
        }

        public void DownHeap(TreeNode node)
        {
            throw new NotImplementedException();
        }

        public void RotationHeap(TreeNode node)
        {
            throw new NotImplementedException();
        }

        protected override string IntendPrint(TreeNode node, int intend, bool endOfLine = true, Direction dir = Direction.Unset)
        {
            var value = node.Value;
            var priority = node.priority;

            return base.IntendPrint($"{value},{priority}", intend, endOfLine, dir);
        }
    }
}
