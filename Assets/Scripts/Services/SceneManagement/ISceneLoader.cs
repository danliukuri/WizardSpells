using System;
using Data.Scene;
using UnityEngine;

namespace Services.SceneManagement
{
    public interface ISceneLoader
    {
        SceneName CurrentSceneName { get; }
        AsyncOperation LoadingOperation { get; }

        void Load(SceneName sceneName, Action onLoaded = default);
    }
}