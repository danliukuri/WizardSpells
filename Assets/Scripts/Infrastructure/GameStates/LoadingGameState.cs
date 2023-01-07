using UnityEngine;
using WizardSpells.Data.Scene;
using WizardSpells.Services.SceneManagement;
using WizardSpells.Utilities.Patterns.State;

namespace WizardSpells.Infrastructure.GameStates
{
    public class LoadingGameState : IEnterableState<SceneName>
    {
        private readonly ISceneLoader _sceneLoader;

        private LoadingGameState(ISceneLoader sceneLoader) => _sceneLoader = sceneLoader;

        public void Enter(SceneName sceneToLoadName) => _sceneLoader.Load(sceneToLoadName, LoadingCompleted);

        private void LoadingCompleted() => Debug.Log($"{_sceneLoader.CurrentSceneName} scene loaded");
    }
}