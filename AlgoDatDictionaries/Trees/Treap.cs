using System;
using System.Collections.Generic;
using System.Text;
namespace AlgoDatDictionaries.Trees
{
    public class Treap : BinSearchTree
    {
        private Random _random = new System.Random();
        public override bool Insert(int value)
        {
            throw new NotImplementedException();
        }
        public override bool Delete(int value)
        {
            throw new NotImplementedException();
        }
        
        protected override BinSearchTreeNode ConstructTreeNode(int value)
        {
            return new TreapNode(value, _random.Next());
        }

        public void DownHeap(BinSearchTreeNode node)
        {
            throw new NotImplementedException();
        }

        public void RotationHeap(BinSearchTreeNode node)
        {
            throw new NotImplementedException();
        }

        protected override string IntendPrint(BinSearchTreeNode node, int intend, bool endOfLine = true, Direction dir = Direction.Unset)
        {
            var n = (TreapNode) node;
            return base.IntendPrint($"{n.Value},{n.Priority}", intend, endOfLine, dir);
        }
    }
}
