using UnityEngine;
using UnityEngine.Pool;
using WizardSpells.Data.Configuration;
using WizardSpells.Features.Player;
using WizardSpells.Infrastructure.Factories.Component;
using Zenject;

namespace WizardSpells.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class PlayerBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform playerObjectsParent;
        [SerializeField] private FactoryConfig factoryConfig;
        [SerializeField] private PoolConfig poolConfig;

        public override void InstallBindings()
        {
            BindFactory();
            BindObjectPool();
        }

        private void BindFactory()
        {
            Container.BindInterfacesTo<FactoryConfig>().FromScriptableObject(factoryConfig).AsSingle();
            
            Container
                .BindInterfacesTo<DependentComponentFactory<Player>>()
                .AsSingle()
                .WithArguments(playerObjectsParent);
        }

        private void BindObjectPool()
        {
            Container.BindInterfacesTo<PoolConfig>().FromScriptableObject(poolConfig).AsSingle();
            
            Container
                .Bind<IObjectPool<Player>>()
                .To<ObjectPool<Player>>()
                .FromFactory<ComponentPoolFactory<Player>>()
                .AsSingle();
        }
    }
}