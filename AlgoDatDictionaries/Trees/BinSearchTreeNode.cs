using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class BinSearchTreeNode
    {
        internal enum NodeType
        {
            Leaf,
            OneChild,
            Symmetric
        }
        public int Value;

        public BinSearchTreeNode Left;
        public BinSearchTreeNode Right;
        

        public BinSearchTreeNode(int value)
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