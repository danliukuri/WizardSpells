using NSubstitute;
using UnityEngine;
using WizardSpells.Data.Static.Configuration;
using Zenject;

namespace WizardSpells.Tests.Utilities.Infrastructure.Factories.Components
{
    public static class Substitute
    {
        public static IFactoryConfig FactoryConfig(GameObject returnPrefab = default)
        {
            var factoryConfig = NSubstitute.Substitute.For<IFactoryConfig>();
            if (returnPrefab != default)
                factoryConfig.Prefab.Returns(returnPrefab);
            return factoryConfig;
        }

        public static IInstantiator DiContainer<TComponent>()
        {
            var diContainer = NSubstitute.Substitute.For<IInstantiator>();
            diContainer.InstantiatePrefabForComponent<TComponent>(Arg.Any<GameObject>(), Arg.Any<Transform>())
                .Returns(info =>
                    Object.Instantiate(info.Arg<GameObject>(), info.Arg<Transform>()).GetComponent<TComponent>());
            return diContainer;
        }
    }
}