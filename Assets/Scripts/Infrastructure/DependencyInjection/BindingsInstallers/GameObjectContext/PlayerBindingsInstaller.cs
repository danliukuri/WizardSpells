using UnityEngine;
using WizardSpells.Data.Dynamic.Player;
using WizardSpells.Data.Static.Configuration.Player;
using WizardSpells.Features.Force.Generators.Environment;
using WizardSpells.Features.Force.Generators.Player;
using WizardSpells.Features.Force.MotionForce;
using WizardSpells.Features.Transformation;
using WizardSpells.Services.Input.Player;
using WizardSpells.Services.Transformation;
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
            Container.BindInterfacesTo<PlayerData>().AsSingle();

            BindInputServices();
            BindPositionChangingServices();
        }

        private void BindConfiguration()
        {
            Container.BindInterfacesTo<InputActionsConfig>().FromScriptableObject(inputActionsConfig).AsSingle();
            Container.BindInterfacesTo<PlayerConfig>().FromScriptableObject(playerConfig).AsSingle();
        }

        private void BindInputServices()
        {
            Container.BindInterfacesTo<PLayerMovementInputService>().AsSingle();
            Container.BindInterfacesTo<PlayerJumpingInputService>().AsSingle();
        }

        private void BindPositionChangingServices()
        {
            BindMotionForceAppliers();
            Container.BindInterfacesTo<MotionForceAccumulator>().AsSingle();

            Container.Bind<CharacterController>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesTo<PositionChanger>().AsSingle();

            Container.BindInterfacesTo<PositionUpdater>().AsSingle();
        }

        private void BindMotionForceAppliers()
        {
            Container.BindInterfacesTo<PlayerJumpForceGenerator>().AsSingle();
            Container.BindInterfacesTo<PlayerMovementForceGenerator>().AsSingle();
            Container.BindInterfacesTo<GravityForceGenerator>().AsSingle();
        }
    }
}