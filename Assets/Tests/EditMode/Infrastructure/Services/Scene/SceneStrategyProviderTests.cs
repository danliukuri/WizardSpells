using FluentAssertions;
using NUnit.Framework;
using WizardSpells.Architecture.GameStates.InitialSettingStrategies;
using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Infrastructure.Services.Scene;
using WizardSpells.Tests.Utilities.Infrastructure.Services.Scene;
using WizardSpells.Utilities.Patterns.Strategy;

namespace WizardSpells.Tests.EditMode.Infrastructure.Services.Scene
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