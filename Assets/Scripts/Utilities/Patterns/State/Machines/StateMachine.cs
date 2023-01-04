using System;
using System.Collections.Generic;

namespace Utilities.Patterns.State.Machines
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IState> _states = new();
        private IState _currentState;

        public void Register(IState state) => _states.Add(state.GetType(), state);

        public void ChangeStateTo<TState>() where TState : IState
        {
            (_currentState as IExitableState)?.Exit();
            var newState = Get<TState>();
            (newState as IEnterableState)?.Enter();
            _currentState = newState;
        }

        public void ChangeStateTo<TState, TEnterArgument>(TEnterArgument argument)
            where TState : IEnterableState<TEnterArgument>
        {
            (_currentState as IExitableState)?.Exit();
            var newState = Get<TState>();
            newState.Enter(argument);
            _currentState = newState;
        }

        private TState Get<TState>() where TState : IState
        {
            Type stateType = typeof(TState);
            if (!_states.ContainsKey(stateType))
                throw new ArgumentException($"This state machine doesn't contains the '{stateType.Name}' state");
            return (TState)_states[stateType];
        }
    }
}