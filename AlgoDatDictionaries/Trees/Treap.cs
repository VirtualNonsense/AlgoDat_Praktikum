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


        // Delete methods

        // Delete method
        public override bool Delete(int value)
        {
            // Case 1: node with given value does not exist => nothing can be done
            if (!Search(value))
                return false;

            // Case 2: Node with given value exist 
            // 1) Swap node with successor that has the lower priority until node is a leaf
            // 2) Delete node
            else
            {
                // 1)
                // Search vor delete node and pre
                var (_, pre, node, dir, _) = EvenMoreDetailedSearch(value);
                
                // DownHeap
                var (deletePre, deleteNode, direction) = DownHeap(pre, node, dir);

                // 2)
                var (_, _) = Delete(deletePre, deleteNode, direction);
                return true;
            }

        }


        public (TreapNode, TreapNode, Direction) DownHeap(TreapNode preNode, TreapNode node, Direction dir)
        {
            TreapNode temporary;

            // Case 1: node is already a leaf => nothing needs to be done
            if(node.Type == BinSearchTreeNode.NodeType.Leaf)
                return (preNode, node, dir);

            // Case 2: node has one successor => swap node with it
            else if (node.Type == BinSearchTreeNode.NodeType.OneChild)
            {
                if (node.Left == null)
                {
                    temporary = node.Right;
                    temporary.Left = node.Left;

                    node.Left = node.Right.Left;
                    node.Right = node.Right.Right;

                    temporary.Right = node;
                    node = temporary;

                    if (preNode != null)
                    {
                        if (dir == Direction.Left)
                            preNode.Left = node;
                        else
                            preNode.Right = node;
                    }

                    return DownHeap(node, node.Right, Direction.Right);
                }
                else
                {
                    temporary = node.Left;
                    temporary.Right = node.Right;

                    node.Right = node.Left.Right;
                    node.Left = node.Left.Left;

                    temporary.Left = node;
                    node = temporary;

                    if (preNode != null)
                    {
                        if (dir == Direction.Left)
                            preNode.Left = node;
                        else
                            preNode.Right = node;
                    }

                    return DownHeap(node, node.Left, Direction.Left);

                }

            }

            // Case 3: node has two successors => swap node with the successor that has a smaller priority
            else
            {
                if (node.Left.Priority <= node.Right.Priority)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

        }

        
        protected override string IntendPrint(BinSearchTreeNode node, int intend, bool endOfLine = true, Direction dir = Direction.Unset)
        {
            var n = (TreapNode) node;
            return base.IntendPrint($"{n.Value},{n.Priority}", intend, endOfLine, dir);
        }
        
    }
}
