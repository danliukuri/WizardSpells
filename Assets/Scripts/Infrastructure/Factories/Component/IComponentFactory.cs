using Zenject;

namespace WizardSpells.Infrastructure.Factories.Component
{
    public interface IComponentFactory<TComponent> : IFactory<TComponent> where TComponent : UnityEngine.Component
    {
        void ActivateGameObject(TComponent component);
        void DeactivateGameObject(TComponent component);
        void DestroyGameObject(TComponent component);
    }
}