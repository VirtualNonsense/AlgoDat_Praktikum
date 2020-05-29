using System;
using System.Collections.Generic;
using System.Text;
namespace AlgoDatDictionaries.Trees
{
    public class Treap : BinSearchTree
    {
        private Random _random = new System.Random();
        protected new TreapNode Root
        {
            get => (TreapNode)base.Root;
            set => base.Root = value;
        }

        public override bool Insert(int value)
        {
            return Insert(value, _random.Next(1,1001));
        }
        internal bool Insert(int value, int prio)
        {
            // Search vor insert node pre
            var (prePre, pre, _, dir, _) = EvenMoreDetailedSearch(value);

            // Perform insert
            var result = Insert(pre, dir, value, prio);

            // Step out if
            if (!result // Insert was unsuccessful
                || dir == Direction.Unset) // Root was inserted 
                return result;

            //// Get inserted node
            //var node = pre == null ? Root : (dir == Direction.Left ? pre.Left : pre.Right);>

            //Heap condition
            CheckHeap(value);

            // Insert successful
            return true;
        }
  
        internal virtual bool Insert(TreapNode pre, Direction dir, int value, int priority)
        {
            switch (dir)
            {
                case Direction.Unset:
                    if (Root != null) return false;
                    Root = new TreapNode(value, priority);
                    break;
                case Direction.Left:
                    if (pre.Left != null) return false;
                    pre.Left = new TreapNode(value, priority);
                    break;
                case Direction.Right:
                    if (pre.Right != null) return false;
                    pre.Right = new TreapNode(value, priority);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
            return true;
        }


        public void CheckHeap(int value)
        {
            var (prePre, pre, node, dir, _) = EvenMoreDetailedSearch(value);

            if (pre.Priority <= node.Priority)
                return;
            else
            {
                if (dir == Direction.Left)
                    TurnRight(prePre, pre, node, dir);
                else
                    TurnLeft(prePre, pre, node, dir);

                CheckHeap(value);
            }     
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
        internal new(TreapNode, TreapNode, TreapNode, Direction, bool) EvenMoreDetailedSearch(int value)
        {
            var (prePre, pre, node, dir, found) = base.EvenMoreDetailedSearch(value);
            return ((TreapNode)prePre, (TreapNode)pre, (TreapNode)node, dir, found);
        }
    }
}
