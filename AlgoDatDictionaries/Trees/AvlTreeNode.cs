using System;

namespace AlgoDatDictionaries.Trees
{
    public class AvlTreeNode : BinSearchTreeNode
    {
        public AvlTreeNode(int value) : base(value)
        {
        }

        public new AvlTreeNode Right
        {
            get => (AvlTreeNode) base.Right;
            set => base.Right = value;
        }
        
        public new AvlTreeNode Left
        {
            get => (AvlTreeNode) base.Left;
            set => base.Left = value;
        }
        
        public int Balance
        {
            get
            {
                switch (Type)
                {
                    case NodeType.Leaf:
                        return 0;
                    case NodeType.OneChild:
                        if (Left != null)
                        {
                            return -(1 + Left.MaxHeight);
                        }
                        return  1 + Right.MaxHeight;
                    case NodeType.Symmetric:
                        return Right.MaxHeight - Left.MaxHeight;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
                }
            }
        }


        internal int MaxHeight
        {
            get
            {
                switch (Type)
                {
                    case NodeType.Leaf:
                        return 0;
                    case NodeType.OneChild:
                        var node = Left ?? Right;
                        return 1 + node.MaxHeight;
                    case NodeType.Symmetric:
                        var leftHeight = Left.MaxHeight;
                        var rightHeight = Right.MaxHeight;
                        var max = (leftHeight > rightHeight) ? leftHeight : rightHeight;
                        return 1 + max;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
                }
            }
        }
        
        
    }
}