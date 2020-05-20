using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;



[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatDictionaries.Trees
{
    public class AVLTree : BinSearchTree
    {
        private readonly int _balanceThreshold = 2;
        private bool _balance = true;

        public AVLTree()
        {
            
        }
        
        /// <summary>
        /// Used for testing
        /// When balance is false the insert and delete method will behave like on the parent class.
        /// </summary>
        /// <param name="balance"></param>
        internal AVLTree(bool balance)
        {
            _balance = balance;
        }
        public override bool Insert(int value)
        {
            var search = base.search(value);
            var result = Insert(search, value);
            if(result && _balance)
                Balance();
            return result;
        }

        public override bool Delete(int value)
        {
            var search = base.search(value);
            var result = Delete(search, value);
            if(result && _balance)
                Balance();
            return result;
        }

        private void Balance()
        {
            throw new NotImplementedException();
        }

        
    }
}