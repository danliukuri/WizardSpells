using System;
using NSubstitute;
using UnityEngine;
using WizardSpells.Data.Configuration;
using WizardSpells.Infrastructure.Factories.Component;
using WizardSpells.Infrastructure.GameStates.InitialSettingStrategies;
using WizardSpells.Utilities.Patterns.State.Machines;

namespace WizardSpells.Tests.EditMode
{
    public class Create
    {
        public static InitialGameStateSettingMainSceneStrategy InitialGameStateSettingMainSceneStrategy(
            IStateMachine gameStateMachine = default) => new(gameStateMachine);

        public static InitialGameStateSettingStrategyProvider InitialGameStateSettingStrategyProvider(
            InitialGameStateSettingDefaultStrategy defaultStrategy = default,
            InitialGameStateSettingBootstrapSceneStrategy bootstrapSceneStrategy = default,
            InitialGameStateSettingMainSceneStrategy mainSceneStrategy = default) =>
            Substitute.For<InitialGameStateSettingStrategyProvider>(defaultStrategy, bootstrapSceneStrategy,
                mainSceneStrategy);

        public static GameObject NewGameObject(params Type[] componentTypesToAttach)
        {
            var newGameObject = new GameObject();
            foreach (Type type in componentTypesToAttach)
                newGameObject.AddComponent(type);
            return newGameObject;
        }

        public static IFactoryConfig FactoryConfig(GameObject returnPrefab = default)
        {
            returnPrefab ??= NewGameObject();
            var factoryConfig = Substitute.For<IFactoryConfig>();
            factoryConfig.Prefab.Returns(returnPrefab);
            return factoryConfig;
        }

        public static ComponentFactory<Transform> ComponentFactory(IFactoryConfig factoryConfig = default,
            Transform objectsParent = default) =>
            Substitute.ForPartsOf<ComponentFactory<Transform>>(factoryConfig ?? FactoryConfig(), objectsParent);
    }
}