using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WizardSpells.Data.Scene;

namespace WizardSpells.Tests.PlayMode.TestUtilities
{
    public class Setup
    {
        public static IEnumerator SetActiveSceneName(SceneName sceneName) => SetActiveScene(Create.Scene(sceneName));

        private static IEnumerator SetActiveScene(Scene scene)
        {
            yield return new WaitUntil(() => scene.isLoaded);
            SceneManager.SetActiveScene(scene);
        }
    }
}