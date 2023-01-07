using System.Collections;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using WizardSpells.Data.Scene;
using WizardSpells.Services.SceneManagement;

namespace WizardSpells.Tests.PlayMode
{
    public class SceneLoaderTests
    {
        [SetUp]
        public void SetUp() => Setup.LoadSceneIsDone(SceneName.Bootstrap);

        [UnityTest]
        public IEnumerator WhenLoadScene_AndSceneNameIsMain_AndSceneIsLoaded_ThenCurrentSceneNameShouldBeMain()
        {
            // Arrange
            var sceneLoader = Substitute.For<SceneLoader>();

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
            var sceneLoader = Substitute.For<SceneLoader>();

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