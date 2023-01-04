namespace Utilities.Patterns.State.Machines
{
    public interface IStateMachine : IStateRegistrar<IState>
    {
        void ChangeStateTo<TState>() where TState : IState;

        public void ChangeStateTo<TState, TEnterArgument>(TEnterArgument argument) 
            where TState : IEnterableState<TEnterArgument>;
    }
}