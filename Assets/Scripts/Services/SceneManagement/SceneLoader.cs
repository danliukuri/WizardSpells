using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using WizardSpells.Data.Static.Enumerations.Scene;

namespace WizardSpells.Services.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public SceneName CurrentSceneName { get; private set; } =
            Enum.Parse<SceneName>(SceneManager.GetActiveScene().name);

        public AsyncOperation LoadingOperation { get; private set; }

        public AsyncOperation Load(SceneName sceneName, Action onLoaded = default)
        {
            LoadingOperation = SceneManager.LoadSceneAsync(sceneName.ToString());
            LoadingOperation.completed += OnLoadingCompleted;
            return LoadingOperation;
            
            void OnLoadingCompleted(AsyncOperation loadingOperation)
            {
                CurrentSceneName = sceneName;
                onLoaded?.Invoke();
                LoadingOperation.completed -= OnLoadingCompleted;
            }
        }
    }
}