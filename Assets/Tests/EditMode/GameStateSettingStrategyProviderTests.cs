using FluentAssertions;
using NUnit.Framework;
using WizardSpells.Data.Scene;
using WizardSpells.Infrastructure.GameStates.InitialSettingStrategies;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Tests.EditMode
{
    public class GameStateSettingStrategyProviderTests
    {
        [Test]
        public void WhenGetStrategy_AndSceneNameIsMain_ThenReturnedStrategyShouldBeForMainScene()
        {
            // Arrange
            InitialGameStateSettingMainSceneStrategy mainStrategy = Create.InitialGameStateSettingMainSceneStrategy();
            InitialGameStateSettingStrategyProvider provider =
                Create.InitialGameStateSettingStrategyProvider(default, default, mainStrategy);

            // Act
            StateSettingStrategy returnedStateSettingStrategy = provider.GetStrategy(SceneName.Main);

            // Assert
            returnedStateSettingStrategy.Should().BeOfType(typeof(InitialGameStateSettingMainSceneStrategy));
        }
    }
}