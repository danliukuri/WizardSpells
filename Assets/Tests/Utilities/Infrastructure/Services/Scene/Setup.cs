using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WizardSpells.Data.Static.Enumerations.Scene;

namespace WizardSpells.Tests.Utilities.Infrastructure.Services.Scene
{
    public static class Setup
    {
        public static IEnumerator SetActiveSceneName(SceneName sceneName) => SetActiveScene(Create.Scene(sceneName));

        private static IEnumerator SetActiveScene(UnityEngine.SceneManagement.Scene scene)
        {
            yield return new WaitUntil(() => scene.isLoaded);
            SceneManager.SetActiveScene(scene);
        }
    }
}