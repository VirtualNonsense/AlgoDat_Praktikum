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
        public int value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            this.value = value;
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