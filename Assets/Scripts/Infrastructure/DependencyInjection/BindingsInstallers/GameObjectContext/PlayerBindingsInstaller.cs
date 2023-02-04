using UnityEngine;
using WizardSpells.Data.Dynamic.Player;
using WizardSpells.Data.Static.Configuration.Player;
using WizardSpells.Features.Services.Force.Accumulators;
using WizardSpells.Features.Services.Force.Generators.Environment;
using WizardSpells.Features.Services.Force.Generators.Player;
using WizardSpells.Features.Services.Transformation;
using WizardSpells.Infrastructure.Services.Input.Player;
using Zenject;

namespace WizardSpells.Infrastructure.DependencyInjection.BindingsInstallers.GameObjectContext
{
    public class PlayerBindingsInstaller : MonoInstaller
    {
        [SerializeField] private InputActionsConfig inputActionsConfig;
        [SerializeField] private PlayerConfig playerConfig;

        public override void InstallBindings()
        {
            BindConfiguration();
            BindData();

            BindInputServices();
            BindPositionChangingServices();
        }

        private void BindConfiguration()
        {
            Container.BindInterfacesTo<InputActionsConfig>().FromScriptableObject(inputActionsConfig).AsSingle();
            Container.BindInterfacesTo<PlayerConfig>().FromScriptableObject(playerConfig).AsSingle();
        }

        private void BindData()
        {
            Container
                .Bind<float>()
                .FromMethod(context => context.Container.Resolve<CharacterController>().contactOffset)
                .WhenInjectedInto<PlayerData>();
            
            Container.BindInterfacesTo<PlayerData>().AsSingle();
        }

        private void BindInputServices()
        {
            Container.BindInterfacesTo<PLayerMovementInputService>().AsSingle();
            Container.BindInterfacesTo<PlayerJumpingInputService>().AsSingle();
        }

        private void BindPositionChangingServices()
        {
            BindMotionForceGenerators();
            Container.BindInterfacesTo<ForceAccumulator>().AsSingle();

            Container.Bind<CharacterController>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesTo<PositionChanger>().AsSingle();
        }

        private void BindMotionForceGenerators()
        {
            Container.BindInterfacesTo<PlayerJumpForceGenerator>().AsSingle();
            Container.BindInterfacesTo<PlayerMovementForceGenerator>().AsSingle();

            Container.BindInterfacesTo<GravityForceGenerator>().AsSingle();
            Container.BindInterfacesTo<NormalForceGenerator>().AsSingle();
            Container.BindInterfacesTo<StickingForceGenerator>().AsSingle();
        }
    }
}