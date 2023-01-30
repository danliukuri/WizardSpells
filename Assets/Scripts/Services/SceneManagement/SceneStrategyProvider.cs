using System.Collections.Generic;
using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Services.SceneManagement
{
    public class SceneStrategyProvider : IStrategyProvider<IStrategy, SceneName>
    {
        private readonly IDictionary<SceneName, IStrategy> _sceneStrategies;
        private readonly IStrategy _defaultStrategy;

        public SceneStrategyProvider(IDictionary<SceneName, IStrategy> sceneStrategies, IStrategy defaultStrategy)
        {
            _sceneStrategies = sceneStrategies;
            _defaultStrategy = defaultStrategy;
        }

        public IStrategy GetStrategy(SceneName sceneName) => _sceneStrategies
            .TryGetValue(sceneName, out IStrategy strategy) ? strategy : _defaultStrategy;
    }
}