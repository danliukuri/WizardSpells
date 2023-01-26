using UnityEngine;
using Zenject;

namespace WizardSpells.Infrastructure.Factories.Components
{
    public interface IComponentFactory<TComponent> : IFactory<TComponent> where TComponent : Component
    {
        void ActivateGameObject(TComponent component);
        void DeactivateGameObject(TComponent component);
        void DestroyGameObject(TComponent component);
    }
}