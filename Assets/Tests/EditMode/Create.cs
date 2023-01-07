using NSubstitute;
using WizardSpells.Infrastructure.GameStates.InitialSettingStrategies;
using WizardSpells.Utilities.Patterns.State.Machines;

namespace WizardSpells.Tests.EditMode
{
    public class Create
    {
        public static InitialGameStateSettingMainSceneStrategy InitialGameStateSettingMainSceneStrategy(
            IStateMachine gameStateMachine = default) => new(gameStateMachine);

        public static InitialGameStateSettingStrategyProvider InitialGameStateSettingStrategyProvider(
            InitialGameStateSettingDefaultStrategy defaultStrategy = default,
            InitialGameStateSettingBootstrapSceneStrategy bootstrapSceneStrategy = default,
            InitialGameStateSettingMainSceneStrategy mainSceneStrategy = default) =>
            Substitute.For<InitialGameStateSettingStrategyProvider>(defaultStrategy, bootstrapSceneStrategy,
                mainSceneStrategy);
    }
}