using WizardSpells.Infrastructure.Services.Scene;
using Zenject;

namespace WizardSpells.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class ServicesBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindSceneLoader();

        private void BindSceneLoader() => Container.BindInterfacesTo<SceneLoader>().AsSingle();
    }
}