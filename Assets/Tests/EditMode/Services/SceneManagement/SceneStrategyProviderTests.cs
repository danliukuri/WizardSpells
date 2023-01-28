using FluentAssertions;
using NUnit.Framework;
using WizardSpells.Data.Scene;
using WizardSpells.Infrastructure.GameStates.InitialSettingStrategies;
using WizardSpells.Services.SceneManagement;
using WizardSpells.Tests.EditMode.TestUtilities;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Tests.EditMode.Services.SceneManagement
{
    public class SceneStrategyProviderTests
    {
        [Test]
        public void WhenGetStrategy_AndSceneNameIsMain_ThenReturnedStrategyShouldBeForMainScene()
        {
            // Arrange
            IStrategy mainStrategy = Create.InitialGameStateSettingMainSceneStrategy();
            SceneStrategyProvider gameStateSettingStrategyProvider =
                Create.SceneStrategyProvider(default, (SceneName: SceneName.Main, Instance: mainStrategy));

            // Act
            IStrategy returnedStateSettingStrategy = gameStateSettingStrategyProvider.GetStrategy(SceneName.Main);

            // Assert
            returnedStateSettingStrategy.Should().BeOfType(typeof(InitialGameStateSettingMainSceneStrategy));
        }
    }
}