using System.Collections.Generic;
using WizardSpells.Data.Scene;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Infrastructure.GameStates.InitialSettingStrategies
{
    public class InitialGameStateSettingStrategyProvider : IStrategyProvider<StateSettingStrategy, SceneName>
    {
        private readonly InitialGameStateSettingDefaultStrategy _defaultStrategy;
        private readonly Dictionary<SceneName, StateSettingStrategy> _initialStateSettingStrategiesByScene;

        public InitialGameStateSettingStrategyProvider(InitialGameStateSettingDefaultStrategy defaultStrategy,
            InitialGameStateSettingBootstrapSceneStrategy bootstrapSceneStrategy,
            InitialGameStateSettingMainSceneStrategy mainSceneStrategy)
        {
            _defaultStrategy = defaultStrategy;
            _initialStateSettingStrategiesByScene = new Dictionary<SceneName, StateSettingStrategy>
            {
                { SceneName.Bootstrap, bootstrapSceneStrategy },
                { SceneName.Main, mainSceneStrategy }
            };
        }

        public StateSettingStrategy GetStrategy(SceneName sceneName) => _initialStateSettingStrategiesByScene
            .TryGetValue(sceneName, out StateSettingStrategy strategy) ? strategy : _defaultStrategy;
    }
}