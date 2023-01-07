namespace WizardSpells.Utilities.Patterns.State
{
    public interface IExitableState : IState
    {
        void Exit();
    }
}