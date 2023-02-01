using System.Linq;
using UnityEngine.SceneManagement;
using WizardSpells.Architecture.GameStates.InitialSettingStrategies;
using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Infrastructure.Services.Scene;
using WizardSpells.Tests.Utilities.Common.Extensions;
using WizardSpells.Utilities.Patterns.State.Machines;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Tests.Utilities.Infrastructure.Services.Scene
{
    public static class Create
    {
        public static InitialGameStateSettingMainSceneStrategy InitialGameStateSettingMainSceneStrategy(
            IStateMachine gameStateMachine = default) => new(gameStateMachine.SubstituteIfDefault());

        public static SceneStrategyProvider SceneStrategyProvider(IStrategy defaultStrategy = default,
            params (SceneName SceneName, IStrategy Instance)[] strategies) =>
            new(strategies?.ToDictionary(strategy => strategy.SceneName, strategy => strategy.Instance)
                .SubstituteIfDefault(), defaultStrategy.SubstituteIfDefault());

        public static SceneLoader SceneLoader() => new();

        public static UnityEngine.SceneManagement.Scene Scene(SceneName sceneName) => Scene(sceneName.ToString());

        public static UnityEngine.SceneManagement.Scene Scene(string sceneName) => SceneManager.CreateScene(sceneName);
    }
}