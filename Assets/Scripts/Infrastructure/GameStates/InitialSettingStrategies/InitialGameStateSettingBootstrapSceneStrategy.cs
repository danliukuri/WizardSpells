using Data.Scene;
using Utilities.Patterns.State.Machines;
using Utilities.Patterns.Strategy;

namespace Infrastructure.GameStates.InitialSettingStrategies
{
    public class InitialGameStateSettingBootstrapSceneStrategy : StateSettingStrategy
    {
        public InitialGameStateSettingBootstrapSceneStrategy(IStateMachine gameStateMachine) :
            base(gameStateMachine) { }

        public override void Execute() => _stateMachine.ChangeStateTo<LoadingGameState, SceneName>(SceneName.Main);
    }
}