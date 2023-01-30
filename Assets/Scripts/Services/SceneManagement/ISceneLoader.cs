using System;
using UnityEngine;
using WizardSpells.Data.Static.Enumerations.Scene;

namespace WizardSpells.Services.SceneManagement
{
    public interface ISceneLoader
    {
        SceneName CurrentSceneName { get; }
        AsyncOperation LoadingOperation { get; }

        AsyncOperation Load(SceneName sceneName, Action onLoaded = default);
    }
}