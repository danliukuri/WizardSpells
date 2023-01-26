using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using WizardSpells.Data.Scene;
using WizardSpells.Services.SceneManagement;
using WizardSpells.Tests.PlayMode.TestUtilities;

namespace WizardSpells.Tests.PlayMode.Services.SceneManagement
{
    public class SceneLoaderTests
    {
        [SetUp]
        public void SetUp() => Setup.LoadSceneIsDone(SceneName.Bootstrap);

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