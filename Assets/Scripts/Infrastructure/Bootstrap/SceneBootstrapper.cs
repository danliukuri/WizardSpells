using UnityEngine;
using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Services.SceneManagement;
using WizardSpells.Utilities.Patterns.Strategy;
using Zenject;

namespace WizardSpells.Infrastructure.Bootstrap
{
    public class SceneBootstrapper : MonoBehaviour
    {
        private IStrategyProvider<IStrategy, SceneName> _initialGameStateSettingStrategyProvider;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(IStrategyProvider<IStrategy, SceneName> initialGameStateSettingStrategyProvider,
            ISceneLoader sceneLoader)
        {
            _initialGameStateSettingStrategyProvider = initialGameStateSettingStrategyProvider;
            _sceneLoader = sceneLoader;
        }

        private void Start() => 
            _initialGameStateSettingStrategyProvider.GetStrategy(_sceneLoader.CurrentSceneName).Execute();
    }
}