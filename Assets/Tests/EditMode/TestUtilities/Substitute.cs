using NSubstitute;
using UnityEngine;
using WizardSpells.Data.Configuration;

namespace WizardSpells.Tests.EditMode.TestUtilities
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

        public static T SubstituteIfDefault<T>(this T obj) where T : class => obj ?? NSubstitute.Substitute.For<T>();
    }
}