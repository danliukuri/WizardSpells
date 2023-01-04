using System;
using Data.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public SceneName CurrentSceneName { get; private set; } =
            Enum.Parse<SceneName>(SceneManager.GetActiveScene().name);

        public AsyncOperation LoadingOperation { get; private set; }

        public void Load(SceneName sceneName, Action onLoaded = default)
        {
            LoadingOperation = SceneManager.LoadSceneAsync(sceneName.ToString());
            CurrentSceneName = sceneName;
            LoadingOperation.completed += OnLoadingCompleted;

            void OnLoadingCompleted(AsyncOperation loadingOperation)
            {
                onLoaded?.Invoke();
                LoadingOperation.completed -= OnLoadingCompleted;
            }
        }
    }
}