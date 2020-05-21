using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class TreeNode
    {
        internal enum NodeType
        {
            Leaf,
            OneChild,
            TwoChildren
        }
        public int Value;

        public TreeNode Previous;
        public TreeNode Left;
        public TreeNode Right;

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
                    case NodeType.TwoChildren:
                        return Right.MaxHeight - Left.MaxHeight;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        public int MaxHeight
        {
            get
            {
                switch (Type)
                {
                    case NodeType.Leaf:
                        return 0;
                    case NodeType.OneChild:
                        TreeNode node = Left ?? Right;
                        return 1 + node.MaxHeight;
                    case NodeType.TwoChildren:
                        int leftHeight = Left.MaxHeight;
                        int rightHeight = Right.MaxHeight;
                        int max = (leftHeight > rightHeight) ? leftHeight : rightHeight;
                        return 1 + max;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public TreeNode MaxNode => Right == null ? this : Right.MaxNode;

        public TreeNode MinNode => Left == null ? this : Left.MinNode;
        

        public TreeNode(int value)
        {
            this.Value = value;
        }

        internal NodeType Type
        {
            get
            {
                if (Left != null && Right != null)
                    return NodeType.TwoChildren;
                if (Left == null && Right == null)
                    return NodeType.Leaf;
                return NodeType.OneChild;
            }        
        }
    }
}