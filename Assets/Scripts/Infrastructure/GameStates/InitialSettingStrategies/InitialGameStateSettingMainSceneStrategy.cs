using Utilities.Patterns.State.Machines;
using Utilities.Patterns.Strategy;

namespace Infrastructure.GameStates.InitialSettingStrategies
{
    public class InitialGameStateSettingMainSceneStrategy : StateSettingStrategy
    {
        public InitialGameStateSettingMainSceneStrategy(IStateMachine gameStateMachine) : base(gameStateMachine) { }
        public override void Execute() => _stateMachine.ChangeStateTo<SetupGameState>();
    }
}