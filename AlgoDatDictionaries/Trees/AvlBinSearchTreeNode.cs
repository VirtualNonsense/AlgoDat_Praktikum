using System;

namespace AlgoDatDictionaries.Trees
{
    public class AvlBinSearchTreeNode : BinSearchTreeNode
    {
        public AvlBinSearchTreeNode(int value) : base(value)
        {
        }

        public AvlBinSearchTreeNode AvlBinSearchRight
        {
            get => (AvlBinSearchTreeNode) Right;
            set => Right = value;
        }
        
        public AvlBinSearchTreeNode AvlBinSearchLeft
        {
            get => (AvlBinSearchTreeNode) Left;
            set => Left = value;
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
                            return -(1 + AvlBinSearchLeft.MaxHeight);
                        }
                        return  1 + AvlBinSearchRight.MaxHeight;
                    case NodeType.Symmetric:
                        return AvlBinSearchRight.MaxHeight - AvlBinSearchLeft.MaxHeight;
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
                        var node = AvlBinSearchLeft ?? AvlBinSearchRight;
                        return 1 + node.MaxHeight;
                    case NodeType.Symmetric:
                        var leftHeight = AvlBinSearchLeft.MaxHeight;
                        var rightHeight = AvlBinSearchRight.MaxHeight;
                        var max = (leftHeight > rightHeight) ? leftHeight : rightHeight;
                        return 1 + max;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
                }
            }
        }
        
        
    }
}