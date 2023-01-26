using UnityEngine;
using WizardSpells.Data.Configuration;
using WizardSpells.Utilities.Extensions.Unity;
using Zenject;

namespace WizardSpells.Infrastructure.Factories.Components
{
    public class DependentComponentFactory<TComponent> : ComponentFactory<TComponent> where TComponent : Component
    {
        private readonly IInstantiator _diContainer;

        public DependentComponentFactory(IFactoryConfig config, Transform objectParent, IInstantiator diContainer) :
            base(config, objectParent) => _diContainer = diContainer;

        public override TComponent Create() =>
            _config.Prefab.AsInactive(_diContainer.InstantiatePrefabForComponent<TComponent>, _objectParent);
    }
}