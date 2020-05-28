namespace AlgoDatDictionaries.Trees
{
    public class TreapNode : BinSearchTreeNode
    {
        public int Priority { get; }

        public TreapNode(int value, int prio) : base(value)
        {
            Priority = prio;
        }

    }
}