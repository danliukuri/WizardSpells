using UnityEngine;
using WizardSpells.Infrastructure.Factories.Components;
using WizardSpells.Tests.Utilities.Common.Extensions;
using Zenject;

namespace WizardSpells.Tests.Utilities.Infrastructure.Factories.Components
{
    public static class Create
    {
        public static ComponentFactory<TComponent> ComponentFactory<TComponent>(GameObject originalGameObject = default,
            Transform objectsParent = default) where TComponent : Component =>
            new(Substitute.FactoryConfig(originalGameObject.NewIfDefault()), objectsParent.SubstituteIfDefault());

        public static DependentComponentFactory<TComponent> DependentComponentFactory<TComponent>(
            GameObject originalGameObject = default, IInstantiator diContainer = default,
            Transform objectsParent = default) where TComponent : Component =>
            new(Substitute.FactoryConfig(originalGameObject.NewIfDefault()), objectsParent.SubstituteIfDefault(),
                diContainer ?? Substitute.DiContainer<TComponent>());
    }
}