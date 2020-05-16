namespace AlgoDatDictionaries.Trees
{
    public class BinSearchTree : ISetSorted
    {
        private TreeNode root;
        
        // ###############################################
        // Constructor
        // ###############################################
        public BinSearchTree()
        {
            
        }
        
        // ###############################################
        // ISetSorted
        // ###############################################
        public bool Search(int value)
        {  
            if (value == root.value)
            {
                return true;
            }
            else
            {
                Search(value, root);
                return false;
            }
        }
        private bool Search(int value, TreeNode node)
        {
            if (value < node.value)
            {
                return Search(value, node.left);
            }
            else if (value > node.value)
            {
               return Search(value, node.left);
            }
            else if (value == node.value)
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        public bool Insert(int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return true;
            }
            else
            {
               return Insert(value, root);          
            }
        }
        private bool Insert(int value, TreeNode node)
        {

            if (value < node.value)
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(value);
                    return true;
                }
                else
                {
                    Insert(value,node.left);
                }
                return false;
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(value);
                    return true;
                }
                else
                {
                    Insert(value, node.right);
                }
                return false;
            }
        }


        public bool Delete(int value)
        {
            if (root == null)
            {
                return true;
            }
            else
            {
                Delete(value, root);
                return false;
            }
        }
        private bool Delete(int value, TreeNode node)
        {

            if (value < node.value)
            {
              return  Delete(value, node.left);
            }
            else if (value > node.value)
            {
              return  Delete(value, node.right);
            }
            else if (node.left != null)
            {
                node = node.left;
                return true;
            }
            else
            {
                node = node.right;
                return true;
            }
           
        }

        public void Print()
        {
            throw new System.NotImplementedException();
        }
        
        // ###############################################
        // Private Stuff
        // ###############################################
    }
}