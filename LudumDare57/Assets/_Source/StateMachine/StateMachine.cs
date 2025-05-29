using System;
using System.Collections.Generic;

namespace StateMachineSystem
{
    public class StateMachine : IState
    {
        private readonly IState _defaultState;

        private IState _currentState;

        private readonly Dictionary<Type, List<Transition>> _transitions = new();
        private List<Transition> _currentTransitions = new();
        private readonly List<Transition> _anyTransitions = new();

        private readonly static List<Transition> EmptyTransitions = new(0);

        public StateMachine(IState defaultState)
        {
            _defaultState = defaultState ?? throw new ArgumentNullException(nameof(defaultState));
        }

        public void Enter()
        {
            TransitToState(_defaultState);
        }

        public void Exit()
        {
            _currentState?.Exit();
            _currentTransitions = EmptyTransitions;
        }

        public void Tick()
        {
            Transition transition = GetTransition();
            if (transition != null)
            {
                TransitToState(transition.To);
            }

            _currentState?.Tick();
        }

        private void TransitToState(IState state)
        {
            if (state == null)
                return;

            if (state == _currentState)
                return;

            _currentState?.Exit();

            _currentState = state;

            _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
            _currentTransitions ??= EmptyTransitions;

            _currentState.Enter();
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
            {
                transitions = new List<Transition>();
                _transitions[from.GetType()] = transitions;
            }

            transitions.Add(new Transition(to, predicate));
        }

        public void AddAnyTransition(IState state, Func<bool> predicate)
        {
            _anyTransitions.Add(new Transition(state, predicate));
        }

        private class Transition
        {
            public Func<bool> Condition { get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }
        }

        private Transition GetTransition()
        {
            foreach (var transition in _anyTransitions)
                if (transition.Condition())
                    return transition;

            foreach (var transition in _currentTransitions)
                if (transition.Condition())
                    return transition;

            return null;
        }
    }
}