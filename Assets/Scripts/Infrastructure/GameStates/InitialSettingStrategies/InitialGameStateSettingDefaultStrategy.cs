using WizardSpells.Data.Scene;
using WizardSpells.Utilities.Patterns.State.Machines;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Infrastructure.GameStates.InitialSettingStrategies
{
    public class InitialGameStateSettingDefaultStrategy : StateSettingStrategy
    {
        public InitialGameStateSettingDefaultStrategy(IStateMachine gameStateMachine) : base(gameStateMachine) { }

        public override void Execute() => _stateMachine.ChangeStateTo<LoadingGameState, SceneName>(SceneName.Bootstrap);
    }
}