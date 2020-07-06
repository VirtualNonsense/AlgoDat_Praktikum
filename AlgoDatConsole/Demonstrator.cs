using System;
using System.Collections.Generic;
using System.Linq;
using AlgoDatDictionaries;
using AlgoDatDictionaries.Arrays;
using AlgoDatDictionaries.Hash;
using AlgoDatDictionaries.Lists;
using AlgoDatDictionaries.Trees;

namespace AlgoDatConsole
{
    public enum MenuState
    {
        ShutDown,
        InterfaceSelection,
        
        MultiSet,
        MultiSetSorted,
        Set,
        SetSorted,
        
        MultiSetSortedArray,
        MultiSetUnsortedArray,
        SetSortedArray,
        SetUnsortedArray,
        
        HashTabQuadProb,
        HashTabSepChain,
        
        MultiSetSortedLinkedList,
        MultiSetUnsortedLinkedList,
        SetSortedLinkedList,
        SetUnsortedLinkedList,
        
        AVLTree,
        BinSearchTree,
        Treap,
        
        Delete,
        Insert
    }

    internal enum MenuTrigger
    {
        Selection0,
        Selection1,
        Selection2,
        Selection3,
        Selection4,
        Back
    }
    public class Demonstrator : IObserver<MenuState>
    {
        private readonly Controller _controller;
        private readonly IDisposable _ticket;
        private readonly EzStateMachine<MenuTrigger, MenuState> _machine;

        private MenuState _lastState;
        private int _currentSelection = 0;
        private IDictionary _instance = null;

        public Demonstrator(Controller controller)
        {
            _controller = controller;
            _machine = new EzStateMachine<MenuTrigger, MenuState>(MenuState.InterfaceSelection, MenuState.ShutDown);
            _ticket = _machine.Subscribe(this);

            #region StateMachineConfig
            _machine.Permit(MenuTrigger.Back, MenuState.InterfaceSelection, MenuState.ShutDown);
            _machine.Permit(MenuTrigger.Selection0, MenuState.InterfaceSelection, MenuState.MultiSet);
            _machine.Permit(MenuTrigger.Selection1, MenuState.InterfaceSelection, MenuState.MultiSetSorted);
            _machine.Permit(MenuTrigger.Selection2, MenuState.InterfaceSelection, MenuState.Set);
            _machine.Permit(MenuTrigger.Selection3, MenuState.InterfaceSelection, MenuState.SetSorted);
            
            _machine.Permit(MenuTrigger.Back, MenuState.MultiSet, MenuState.InterfaceSelection);
            _machine.Permit(MenuTrigger.Selection0, MenuState.MultiSet, MenuState.MultiSetUnsortedArray);
            _machine.Permit(MenuTrigger.Selection1, MenuState.MultiSet, MenuState.MultiSetUnsortedLinkedList);

            _machine.Permit(MenuTrigger.Back, MenuState.MultiSetSorted, MenuState.InterfaceSelection);
            _machine.Permit(MenuTrigger.Selection0, MenuState.MultiSetSorted, MenuState.MultiSetSortedArray);
            _machine.Permit(MenuTrigger.Selection1, MenuState.MultiSetSorted, MenuState.MultiSetSortedLinkedList);

            _machine.Permit(MenuTrigger.Back, MenuState.Set, MenuState.InterfaceSelection);
            _machine.Permit(MenuTrigger.Selection0, MenuState.Set, MenuState.SetUnsortedArray);
            _machine.Permit(MenuTrigger.Selection1, MenuState.Set, MenuState.SetUnsortedLinkedList);
            _machine.Permit(MenuTrigger.Selection2, MenuState.Set, MenuState.HashTabQuadProb);
            _machine.Permit(MenuTrigger.Selection3, MenuState.Set, MenuState.HashTabSepChain);

            _machine.Permit(MenuTrigger.Back, MenuState.SetSorted, MenuState.InterfaceSelection);
            _machine.Permit(MenuTrigger.Selection0, MenuState.SetSorted, MenuState.SetSortedArray);
            _machine.Permit(MenuTrigger.Selection1, MenuState.SetSorted, MenuState.SetSortedLinkedList);
            _machine.Permit(MenuTrigger.Selection2, MenuState.SetSorted, MenuState.BinSearchTree);
            _machine.Permit(MenuTrigger.Selection3, MenuState.SetSorted, MenuState.AVLTree);
            _machine.Permit(MenuTrigger.Selection4, MenuState.SetSorted, MenuState.Treap);
            
            _machine.Permit(MenuTrigger.Back, MenuState.MultiSetUnsortedArray, MenuState.MultiSet);
            _machine.Permit(MenuTrigger.Selection0, MenuState.MultiSetUnsortedArray, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.MultiSetUnsortedArray, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.MultiSetUnsortedLinkedList, MenuState.MultiSet);
            _machine.Permit(MenuTrigger.Selection0, MenuState.MultiSetUnsortedLinkedList, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.MultiSetUnsortedLinkedList, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.MultiSetSortedArray, MenuState.MultiSetSorted);
            _machine.Permit(MenuTrigger.Selection0, MenuState.MultiSetSortedArray, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.MultiSetSortedArray, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.MultiSetSortedLinkedList, MenuState.MultiSetSorted);
            _machine.Permit(MenuTrigger.Selection0, MenuState.MultiSetSortedLinkedList, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.MultiSetSortedLinkedList, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.SetUnsortedArray, MenuState.Set);
            _machine.Permit(MenuTrigger.Selection0, MenuState.SetUnsortedArray, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.SetUnsortedArray, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.SetUnsortedLinkedList, MenuState.Set);
            _machine.Permit(MenuTrigger.Selection0, MenuState.SetUnsortedLinkedList, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.SetUnsortedLinkedList, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.HashTabQuadProb, MenuState.Set);
            _machine.Permit(MenuTrigger.Selection0, MenuState.HashTabQuadProb, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.HashTabQuadProb, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.HashTabSepChain, MenuState.Set);
            _machine.Permit(MenuTrigger.Selection0, MenuState.HashTabSepChain, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.HashTabSepChain, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.SetSortedArray, MenuState.SetSorted);
            _machine.Permit(MenuTrigger.Selection0, MenuState.SetSortedArray, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.SetSortedArray, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.SetSortedLinkedList, MenuState.SetSorted);
            _machine.Permit(MenuTrigger.Selection0, MenuState.SetSortedLinkedList, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.SetSortedLinkedList, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.BinSearchTree, MenuState.SetSorted);
            _machine.Permit(MenuTrigger.Selection0, MenuState.BinSearchTree, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.BinSearchTree, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.AVLTree, MenuState.SetSorted);
            _machine.Permit(MenuTrigger.Selection0, MenuState.AVLTree, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.AVLTree, MenuState.Insert);
            
            _machine.Permit(MenuTrigger.Back, MenuState.Treap, MenuState.SetSorted);
            _machine.Permit(MenuTrigger.Selection0, MenuState.Treap, MenuState.Delete);
            _machine.Permit(MenuTrigger.Selection1, MenuState.Treap, MenuState.Insert);
            #endregion
        }

        public void Start()
        {
            UpdateState(_machine.CurrentState);
        }
        
        
        
        public void OnNext(MenuState value)
        {
            UpdateState(value);
        }

        
        public void OnCompleted()
        {
            Console.WriteLine("Demonstrator shutdown");
            _ticket.Dispose();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error);
            throw error;
        }

        private void UpdateState(MenuState s)
        {
            MenuTrigger tmp;
            Console.Clear();
            switch (s)
            {
                case MenuState.ShutDown:
                    break;
                case MenuState.InterfaceSelection:
                    _machine.Trigger(GetStateTransition(null));
                    break;
                case MenuState.MultiSet:
                    _machine.Trigger(GetStateTransition(null));
                    break;
                case MenuState.MultiSetSorted:
                    _machine.Trigger(GetStateTransition(null));
                    break;
                case MenuState.Set:
                    _machine.Trigger(GetStateTransition(null));
                    break;
                case MenuState.SetSorted:
                    _machine.Trigger(GetStateTransition(null));
                    break;
                case MenuState.MultiSetSortedArray:
                    _instance = _lastState==s? (MultiSetSortedArray)_instance : new MultiSetSortedArray();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.MultiSetUnsortedArray:
                    _instance = _lastState==s? (MultiSetUnsortedArray)_instance : new MultiSetUnsortedArray();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.SetSortedArray:
                    _instance = _lastState==s? (SetSortedArray)_instance : new SetSortedArray();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.SetUnsortedArray:
                    _instance = _lastState==s? (SetUnsortedArray)_instance : new SetUnsortedArray();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.HashTabQuadProb:
                    _instance = _lastState==s? (HashTabQuadProb)_instance : new HashTabQuadProb();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.HashTabSepChain:
                    _instance = _lastState==s? (HashTabSepChain)_instance : new HashTabSepChain();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.MultiSetSortedLinkedList:
                    _instance = _lastState==s? (MultiSetSortedLinkedList)_instance : new MultiSetSortedLinkedList();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.MultiSetUnsortedLinkedList:
                    _instance = _lastState==s? (MultiSetUnsortedLinkedList)_instance : new MultiSetUnsortedLinkedList();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.SetSortedLinkedList:
                    _instance = _lastState==s? (SetSortedLinkedList)_instance : new SetSortedLinkedList();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.SetUnsortedLinkedList:
                    _instance = _lastState==s? (SetUnsortedLinkedList)_instance : new SetUnsortedLinkedList();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.AVLTree:
                    _instance = _lastState==s? (AVLTree)_instance : new AVLTree();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.BinSearchTree:
                    _instance = _lastState==s? (BinSearchTree)_instance : new BinSearchTree();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.Treap:
                    _instance = _lastState==s? (Treap)_instance : new Treap();
                    _lastState = s;
                    tmp = GetStateTransition(null);
                    _machine.Trigger(tmp, tmp != MenuTrigger.Back);
                    break;
                case MenuState.Delete:
                    DeleteItems(_instance, "");
                    return;
                case MenuState.Insert:
                    AddItems(_instance, "");
                    return;
                default:
                    throw new ArgumentOutOfRangeException(nameof(s), s, null);
            }
        }

        private void plot_Transition(string banner, List<(MenuTrigger, MenuState)> trans, int selectionIndex)
        {
            Console.WriteLine(banner);
            var i = 0;
            foreach (var transition in trans)
            {
                var cursor = selectionIndex == i? "<<<" : " ";
                Console.WriteLine($"{transition.Item2}{cursor}");
                i++;
            }
        }

        private void DeleteItems(IDictionary instance, string banner)
        {
            do
            {
                Console.Clear();
                if (banner != null) Console.WriteLine(banner);
                Console.WriteLine("Current content of instance:");
                instance.Print();
                Console.WriteLine("Please enter an integer");
                var result = instance.Delete(_controller.AwaitIntInput());
                Console.WriteLine($"removal {(result? "successful" : "unsuccessful")}");
                Console.WriteLine("Changed content of instance:");
                instance.Print();
                Console.WriteLine($"press {_controller.GetKey(Control.Enter)} to remove another int\n" +
                                  $"press {_controller.GetKey(Control.Escape)} to exit");
            } while (_controller.AwaitInput() != Control.Escape);
        }
        private void AddItems(IDictionary instance, string banner)
        {
            do
            {
                Console.Clear();
                if (banner != null) Console.WriteLine(banner);
                Console.WriteLine("Current content of instance:");
                instance.Print();
                Console.WriteLine("Please enter an integer");
                var result = instance.Insert(_controller.AwaitIntInput());
                Console.WriteLine($"insert {(result? "successful" : "unsuccessful")}");
                Console.WriteLine("Changed content of instance:");
                instance.Print();
                Console.WriteLine($"press {_controller.GetKey(Control.Enter)} to enter another int\n" +
                                  $"press {_controller.GetKey(Control.Escape)} to exit");
            } while (_controller.AwaitInput() != Control.Escape);
        }

        private MenuTrigger GetStateTransition(string banner)
        {
            var trans = _machine.GetAvailableTransitions().ToList();
            var selectionIndex = _currentSelection % trans.Count;
            Control input;
            do
            {
                Console.Clear();
                plot_Transition(banner, trans, selectionIndex);
                input = _controller.AwaitInput();
                switch (input)
                {
                    case Control.Up:
                        selectionIndex--;
                        if (selectionIndex < 0)
                            selectionIndex = trans.Count - 1;
                        break;
                    case Control.Down:
                        selectionIndex = (selectionIndex + 1) % trans.Count;
                        break;
                }

            } while (input != Control.Enter && input != Control.Escape);

            return trans.ElementAt(selectionIndex).Item1;
        }
    }
}