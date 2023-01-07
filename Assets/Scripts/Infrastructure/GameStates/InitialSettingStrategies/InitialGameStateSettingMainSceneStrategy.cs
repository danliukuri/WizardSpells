using WizardSpells.Utilities.Patterns.State.Machines;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Infrastructure.GameStates.InitialSettingStrategies
{
    public class InitialGameStateSettingMainSceneStrategy : StateSettingStrategy
    {
        public InitialGameStateSettingMainSceneStrategy(IStateMachine gameStateMachine) : base(gameStateMachine) { }
        public override void Execute() => _stateMachine.ChangeStateTo<SetupGameState>();
    }
}