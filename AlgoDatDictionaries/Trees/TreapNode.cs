namespace AlgoDatDictionaries.Trees
{
    public class TreapNode : BinSearchTreeNode
    {
        public int Priority { get; }
        
        
        public new TreapNode Right
        {
            get => (TreapNode) base.Right;
            set => base.Right = value;
        }
        
        public new TreapNode Left
        {
            get => (TreapNode) base.Left;
            set => base.Left = value;
        }

        public TreapNode(int value, int prio) : base(value)
        {
            Priority = prio;
        }

    }
}