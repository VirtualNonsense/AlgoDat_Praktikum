namespace AlgoDatDictionaries.Trees
{
    public class DoubleLinkTreeNode : TreeNode
    {
        public DoubleLinkTreeNode(int value) : base(value)
        {
        }
        
        
        public DoubleLinkTreeNode Previous;
        
        
        public bool IsRoot => Previous == null;
        
        

        public override string ToString()
        {
            string root = IsRoot ? "ROOT " : "";
            string children = Right != null? 
                (Left != null ? $"; {Left.Value}, {Right.Value}" : $"; {Right.Value}") 
                : (Left != null ? $"; {Left.Value}" : $"");
            
            return $"{root}{Value}{children}";
        }
        
    }
}