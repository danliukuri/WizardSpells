using UnityEngine;
using UnityEngine.SceneManagement;
using WizardSpells.Data.Scene;

namespace WizardSpells.Tests.PlayMode.TestUtilities
{
    public class Setup
    {
        public static AsyncOperation LoadSceneIsDone(SceneName sceneName) =>
            SceneManager.LoadSceneAsync(sceneName.ToString());
    }
}