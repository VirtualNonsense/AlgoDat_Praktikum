namespace AlgoDatDictionaries.Trees
{
    internal class TreeNode
    {
        internal enum NodeType
        {
            Leaf,
            OneChild,
            TwoChildren
        }
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            this.Value = value;
        }

        public NodeType Type
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