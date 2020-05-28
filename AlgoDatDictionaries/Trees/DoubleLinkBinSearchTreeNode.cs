namespace AlgoDatDictionaries.Trees
{
    public class DoubleLinkBinSearchTreeNode : BinSearchTreeNode
    {
        public DoubleLinkBinSearchTreeNode(int value) : base(value)
        {
        }
        
        
        public DoubleLinkBinSearchTreeNode Previous;
        
        
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