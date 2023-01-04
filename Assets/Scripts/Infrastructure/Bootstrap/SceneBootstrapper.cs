using Data.Scene;
using Services.SceneManagement;
using UnityEngine;
using Utilities.Patterns.Strategy;
using Zenject;

namespace Infrastructure.Bootstrap
{
    public class SceneBootstrapper : MonoBehaviour
    {
        private IStrategyProvider<StateSettingStrategy, SceneName> _initialGameStateSettingStrategyProvider;
        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(
            IStrategyProvider<StateSettingStrategy, SceneName> initialGameStateSettingStrategyProvider,
            ISceneLoader sceneLoader)
        {
            _initialGameStateSettingStrategyProvider = initialGameStateSettingStrategyProvider;
            _sceneLoader = sceneLoader;
        }

        private void Start() => _initialGameStateSettingStrategyProvider.GetStrategy(_sceneLoader.CurrentSceneName)
            .Execute();
    }
}