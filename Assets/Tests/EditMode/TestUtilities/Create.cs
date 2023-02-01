using System;
using System.Linq;
using UnityEngine;
using WizardSpells.Architecture.GameStates.InitialSettingStrategies;
using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Features.Services.Force.MotionForce;
using WizardSpells.Infrastructure.Factories.Components;
using WizardSpells.Infrastructure.Services.Scene;
using WizardSpells.Utilities.Patterns.State.Machines;
using WizardSpells.Utilities.Patterns.Strategy;
using Zenject;

namespace WizardSpells.Tests.EditMode.TestUtilities
{
    public static class Create
    {
        public static InitialGameStateSettingMainSceneStrategy InitialGameStateSettingMainSceneStrategy(
            IStateMachine gameStateMachine = default) => new(gameStateMachine.SubstituteIfDefault());

        public static SceneStrategyProvider SceneStrategyProvider(IStrategy defaultStrategy = default,
            params (SceneName SceneName, IStrategy Instance)[] strategies) =>
            new(strategies?.ToDictionary(strategy => strategy.SceneName, strategy => strategy.Instance)
                .SubstituteIfDefault(), defaultStrategy.SubstituteIfDefault());

        public static GameObject GameObject(params Type[] componentTypesToAttach)
        {
            var newGameObject = new GameObject();
            foreach (Type type in componentTypesToAttach)
                newGameObject.AddComponent(type);
            return newGameObject;
        }

        public static ComponentFactory<TComponent> ComponentFactory<TComponent>(GameObject originalGameObject = default,
            Transform objectsParent = default) where TComponent : Component =>
            new(Substitute.FactoryConfig(originalGameObject.NewIfDefault()), objectsParent.SubstituteIfDefault());

        public static DependentComponentFactory<TComponent> DependentComponentFactory<TComponent>(
            GameObject originalGameObject = default, IInstantiator diContainer = default,
            Transform objectsParent = default) where TComponent : Component =>
            new(Substitute.FactoryConfig(originalGameObject.NewIfDefault()), objectsParent.SubstituteIfDefault(),
                diContainer ?? Substitute.DiContainer<TComponent>());

        public static MotionForceAccumulator MotionForceAccumulator() => new();

        public static T NewIfDefault<T>(this T obj) where T : class, new() => obj ?? new T();
    }
}