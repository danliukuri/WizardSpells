using UnityEngine.SceneManagement;
using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Services.SceneManagement;

namespace WizardSpells.Tests.PlayMode.TestUtilities
{
    public static class Create
    {
        public static SceneLoader SceneLoader() => new();

        public static Scene Scene(SceneName sceneName) => SceneManager.CreateScene(sceneName.ToString());
    }
}