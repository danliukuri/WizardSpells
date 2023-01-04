using Utilities.Patterns.State.Machines;

namespace Utilities.Patterns.Strategy
{
    public abstract class StateSettingStrategy : IStrategy
    {
        protected readonly IStateMachine _stateMachine;

        protected StateSettingStrategy(IStateMachine stateMachine) => _stateMachine = stateMachine;

        public abstract void Execute();
    }
}