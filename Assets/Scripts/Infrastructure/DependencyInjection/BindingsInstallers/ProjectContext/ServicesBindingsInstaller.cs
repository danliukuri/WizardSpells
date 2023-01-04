using Services.SceneManagement;
using Zenject;

namespace Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class ServicesBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindSceneLoader();

        private void BindSceneLoader() => Container.BindInterfacesTo<SceneLoader>().AsSingle();
    }
}