using Microsoft.Win32.SafeHandles;
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

        internal new(TreapNode, TreapNode, TreapNode, Direction, bool) EvenMoreDetailedSearch(int value)
        {
            var (prePre, pre, node, dir, found) = base.EvenMoreDetailedSearch(value);
            return ((TreapNode)prePre, (TreapNode)pre, (TreapNode)node, dir, found);
        }
        // Insert methods

        // Insert method for random priority
        public override bool Insert(int value)
        {
            // Search vor insert node pre
            var (prePre, pre, _, dir, _) = EvenMoreDetailedSearch(value);

            // Perform insert
            var result = Insert(pre, dir, value);

            // Step out if
            if (!result // Insert was unsuccessful
                || dir == Direction.Unset) // Root was inserted 
                return result;

            // Get inserted node
            var node = pre == null ? Root : (dir == Direction.Left ? pre.Left : pre.Right);

            // Check Heap condition
            CheckHeap(value);

            // Insert successful
            return true;
        }


        // Recursive method that rotates the node until the heap condition is met
        public void CheckHeap(int value)
        {
            var (prePre, pre, node, dir, _) = EvenMoreDetailedSearch(value);

            if(pre !=null && pre.Priority > node.Priority)
            {
                if (dir == Direction.Left)
                    TurnRight(prePre, pre, node, dir);
                else
                    TurnLeft(prePre, pre, node, dir);

                CheckHeap(value);
            }     
        }

        protected override BinSearchTreeNode ConstructTreeNode(int value)
        {
            return new TreapNode(value, _random.Next(1,101));
        }


        // Delete method
        public override bool Delete(int value)
        {
            //Rotate node to leaf
            RotationHeap(value);

            //Delete Node
            var (prePre, pre, node, dir, _) = EvenMoreDetailedSearch(value);
            var (result, newPre) = Delete(pre, node, dir);
           
             // Step out if
            if (!result // Delete was unsuccessful
                || Root == null)  // Tree is empty
                return result;     
            
            // Delete Successful
            return true;          
        }

        public void RotationHeap(int value)
        {
            var (_, pre, node, _, _) = EvenMoreDetailedSearch(value);
            if ((node.Type == BinSearchTreeNode.NodeType.OneChild && node.Left !=null)
                ||(node.Type == BinSearchTreeNode.NodeType.Symmetric && node.Left.Priority <= node.Right.Priority))
            {
                TurnRight(pre, node,node.Left, Direction.Left);
                RotationHeap(value);
            }

            else if ((node.Type == BinSearchTreeNode.NodeType.OneChild && node.Right != null)
                || (node.Type == BinSearchTreeNode.NodeType.Symmetric && node.Left.Priority > node.Right.Priority))
            {
                TurnLeft(pre, node, node.Right, Direction.Right);
                RotationHeap(value);
            }

        }
       
        protected override string IntendPrint(BinSearchTreeNode node, int intend, bool endOfLine = true, Direction dir = Direction.Unset)
        {
            var n = (TreapNode) node;
            return base.IntendPrint($"{n.Value},{n.Priority}", intend, endOfLine, dir);
        }
        
    }
}
