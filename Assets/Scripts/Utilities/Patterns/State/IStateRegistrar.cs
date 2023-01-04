namespace Utilities.Patterns.State
{
    public interface IStateRegistrar<in TState> where TState : IState
    {
        void Register(TState state);
    }
}