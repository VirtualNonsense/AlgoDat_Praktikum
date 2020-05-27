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
            Symmetric
        }
        public int Value;
        public int priority;

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
                    case NodeType.Symmetric:
                        return Right.MaxHeight - Left.MaxHeight;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
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
                    case NodeType.Symmetric:
                        int leftHeight = Left.MaxHeight;
                        int rightHeight = Right.MaxHeight;
                        int max = (leftHeight > rightHeight) ? leftHeight : rightHeight;
                        return 1 + max;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
                }
            }
        }

        public TreeNode(int value)
        {
            this.Value = value;
        }

        internal NodeType Type
        {
            get
            {
                if (Left != null && Right != null)
                    return NodeType.Symmetric;
                if (Left == null && Right == null)
                    return NodeType.Leaf;
                return NodeType.OneChild;
            }        
        }


        public override string ToString()
        {
            string children = Right != null? 
                (Left != null ? $"; {Left.Value}, {Right.Value}" : $"; {Right.Value}") 
                : (Left != null ? $"; {Left.Value}" : $"");
            
            return $"{Value}{children}";
        }
    }
}