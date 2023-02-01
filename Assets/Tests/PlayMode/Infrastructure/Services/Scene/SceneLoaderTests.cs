using System.Collections;
using FluentAssertions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Infrastructure.Services.Scene;
using WizardSpells.Tests.Utilities.Infrastructure.Services.Scene;

namespace WizardSpells.Tests.PlayMode.Infrastructure.Services.Scene
{
    public class SceneLoaderTests
    {
        [UnitySetUp]
        public IEnumerator SetUp() => Setup.SetActiveSceneName(SceneName.Bootstrap);

        [UnityTest]
        public IEnumerator WhenLoadScene_AndSceneNameIsMain_AndSceneIsLoaded_ThenCurrentSceneNameShouldBeMain()
        {
            // Arrange
            SceneLoader sceneLoader = Create.SceneLoader();

            // Act
            AsyncOperation mainSceneLoadingOperation = sceneLoader.Load(SceneName.Main);
            yield return new WaitUntil(() => mainSceneLoadingOperation.isDone);

            // Assert
            sceneLoader.CurrentSceneName.Should().Be(SceneName.Main);
        }

        [UnityTest]
        public IEnumerator WhenLoadScene_AndSceneIsLoaded_ThenCurrentSceneNameShouldBeActiveSceneName()
        {
            // Arrange
            SceneLoader sceneLoader = Create.SceneLoader();

            // Act
            AsyncOperation mainSceneLoadingOperation = sceneLoader.Load(SceneName.Main);
            yield return new WaitUntil(() => mainSceneLoadingOperation.isDone);

            // Assert
            var currentSceneName = new { SceneName = sceneLoader.CurrentSceneName.ToString() };
            var activeSceneName = new { SceneName = SceneManager.GetActiveScene().name };
            currentSceneName.Should().Be(activeSceneName);
        }
    }
}