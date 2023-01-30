using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Utilities.Patterns.State.Machines;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Infrastructure.GameStates.InitialSettingStrategies
{
    public class InitialGameStateSettingBootstrapSceneStrategy : StateSettingStrategy
    {
        public InitialGameStateSettingBootstrapSceneStrategy(IStateMachine gameStateMachine) :
            base(gameStateMachine) { }

        public override void Execute() => _stateMachine.ChangeStateTo<LoadingGameState, SceneName>(SceneName.Main);
    }
}