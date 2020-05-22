using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;



[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class AVLTree : BinSearchTree
    {
        private readonly int _balanceThreshold = 2;
        private bool _enableBalance = true;
        

        public AVLTree()
        {
            Branch = "---";
        }
        
        /// <summary>
        /// Used for testing
        /// When balance is false the insert and delete method will behave like on the parent class.
        /// </summary>
        /// <param name="enableBalance"></param>
        internal AVLTree(bool enableBalance)
        {
            _enableBalance = enableBalance;
            Branch = "---";
        }
        public override bool Insert(int value)
        {
            var (pre, node, dir, found) = base.DetailedSearch(value);
            var result = Insert(pre, dir, value);
            if (!result || !_enableBalance) return result;
            var (treeNode, balance) = GetUnbalancedNode((dir == Direction.Left)? pre.Left : pre.Right);
            // if (unbalanced) Balance(pre, treeNode, balance);
            return true;
        }

        public override bool Delete(int value)
        {
            var (pre, node, dir, found) = base.DetailedSearch(value);
            var (result, newPre) = Delete(pre, node, dir);
            if (!result || !_enableBalance) return result;
            var (treeNode, balance) = GetUnbalancedNode(newPre);
            Balance(treeNode, balance);
            return true;
        }

        private bool Balance(TreeNode node, int balance)
        {
            throw new NotImplementedException();
        }

        internal (TreeNode, int) GetUnbalancedNode(TreeNode changedNote)
        {
            if (changedNote == null) return (null, 0);
            while (true)
            {
                var balance = changedNote.Balance;
                if (Math.Abs(balance) >= _balanceThreshold || changedNote.IsRoot) return (changedNote, balance);
                changedNote = changedNote.Previous;
            }
        }

        protected override string IntendPrint(TreeNode node, int intend, bool endOfLine = true)
        {
            var b = node.Balance;
            var bString = "0";
            if (b < 0)
                bString = new string('-', Math.Abs(b));
            else if (b > 0)
                bString = new string('+', b);

            var dir = "";
            var pre = node.Previous;
            if (pre?.Left?.Value == node.Value)
                dir = @" ╰";
            else if (pre?.Right?.Value == node.Value)
                dir = @" ╭";
            
            return new string(IntendString, intend) + dir + (intend > 0? Branch : "") + $"{node.Value}[{bString}]" + (endOfLine? Eol : "");
        }
    }
}