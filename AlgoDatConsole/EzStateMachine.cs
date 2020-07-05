﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("tests")]
namespace AlgoDatConsole
{

    
    public class EzStateMachine <T, S> : IObservable<S> where S: Enum where T : Enum
    {
        private readonly List<(T, S, S)> _permittedTransitions;
        private readonly bool _errorIfInvalidPermission;
        private S _currentState;

        private readonly List<IObserver<S>> _observer;
        public EzStateMachine(S initialState, bool errorIfInvalidPermission=false)
        {
            _observer = new List<IObserver<S>>();
            _permittedTransitions = new List<(T, S, S)>();
            _currentState = initialState;
            _errorIfInvalidPermission = errorIfInvalidPermission;
        }

        internal S CurrentState => _currentState;

        public bool Permit(T trigger, S fromState, S toState)
        {
            var search = from tr in _permittedTransitions
                where Equals(tr.Item1, trigger) && Equals(tr.Item2, fromState)
                select tr;
            if (search.Any()) return false;
            
            var t = (trigger, fromState, toState);
            _permittedTransitions.Add(t);
            return true;
        }

        public bool Trigger(T trigger)
        {
            var t = from tr in _permittedTransitions
                where Equals(tr.Item1, trigger) && Equals(tr.Item2, CurrentState)
                select tr;
            var valueTuples = t as (T, S, S)[] ?? t.ToArray();
            if (!valueTuples.Any())
            {
                if(_errorIfInvalidPermission)
                    throw new Exception($"Invalid Transition: There is no transition from {CurrentState} with {trigger} defined");
                return false;
            }
            _currentState = valueTuples[0].Item3;
            UpdateSubscriber();
            return true;
        }
        
        private void UpdateSubscriber()
        {
            foreach (var observer in _observer)
            {
                observer.OnNext(CurrentState);
            }
        }

        internal bool IsSubscriber(IObserver<S> observer)
        {
            return _observer.Contains(observer);
        }
        // ##########################################################
        // OBSERVER STUFF
        // ##########################################################
        public IDisposable Subscribe(IObserver<S> observer)
        {
            if (! _observer.Contains(observer))
                _observer.Add(observer);
            return new MenuStateUnsubscribable(_observer, observer);
        }

        private class MenuStateUnsubscribable : IDisposable
        {
            private readonly List<IObserver<S>>_observers;
            private readonly IObserver<S> _observer;

            public MenuStateUnsubscribable(List<IObserver<S>> observers, IObserver<S> observer)
            {
                _observers = observers;
                _observer = observer;
            }
            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
        // ##########################################################
    }
}