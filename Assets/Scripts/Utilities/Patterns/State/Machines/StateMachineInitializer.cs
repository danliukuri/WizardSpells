using Zenject;

namespace Utilities.Patterns.State.Machines
{
    public class StateMachineInitializer : IInitializable
    {
        private readonly IStateMachine _stateMachine;
        private readonly IState[] _states;

        private StateMachineInitializer(IStateMachine stateMachine, params IState[] states)
        {
            _stateMachine = stateMachine;
            _states = states;
        }

        public void Initialize()
        {
            foreach (IState state in _states)
                _stateMachine.Register(state);
        }
    }
}