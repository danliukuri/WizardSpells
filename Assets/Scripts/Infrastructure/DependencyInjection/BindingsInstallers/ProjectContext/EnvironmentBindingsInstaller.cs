using UnityEngine;
using WizardSpells.Data.Static.Configuration.Environment;
using Zenject;

namespace WizardSpells.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class EnvironmentBindingsInstaller : MonoInstaller
    {
        [SerializeField] private EnvironmentConfig environmentConfig;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EnvironmentConfig>().FromScriptableObject(environmentConfig).AsSingle();
        }
    }
}