using UnityEngine;
using UnityEngine.Pool;
using WizardSpells.Data.Configuration;
using WizardSpells.Features.Player;
using WizardSpells.Infrastructure.Factories.Component;
using Zenject;

namespace WizardSpells.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class PlayerBindingInstaller : MonoInstaller
    {
        [SerializeField] private Transform playerObjectsParent;
        [SerializeField] private PoolConfig poolConfig;
        [SerializeField] private FactoryConfig factoryConfig;

        public override void InstallBindings()
        {
            BindObjectPoolConfiguration();
            BindObjectPoolFactory();
            BindObjectPool();

            BindFactoryConfiguration();
            BindFactory();
        }

        private void BindObjectPoolConfiguration() =>
            Container.BindInterfacesTo<PoolConfig>().FromInstance(poolConfig).AsSingle();

        private void BindObjectPoolFactory() =>
            Container.BindInterfacesTo<ComponentPoolFactory<Player>>().AsSingle();

        private void BindObjectPool() =>
            Container
                .BindInterfacesTo<ObjectPool<Player>>()
                .FromIFactory<ObjectPool<Player>>(x => x.FromResolve())
                .AsSingle();

        private void BindFactoryConfiguration() =>
            Container.BindInterfacesTo<FactoryConfig>().FromInstance(factoryConfig).AsSingle();

        private void BindFactory() =>
            Container
                .BindInterfacesTo<ComponentFactory<Player>>()
                .AsSingle()
                .WithArguments(playerObjectsParent);
    }
}