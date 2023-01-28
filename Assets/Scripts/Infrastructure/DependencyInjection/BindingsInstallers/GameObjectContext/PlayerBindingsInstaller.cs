using UnityEngine;
using WizardSpells.Data.Configuration.Player;
using WizardSpells.Data.Dynamic.Player;
using WizardSpells.Features.Force.Generators.Player;
using WizardSpells.Features.Force.MotionForce;
using WizardSpells.Services.Input.Player;
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

            Container.BindInterfacesTo<MotionForceAccumulator>().AsSingle();
            BindMotionForceGenerators();
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

        private void BindMotionForceGenerators()
        {
            Container.BindInterfacesTo<PlayerJumpForceGenerator>().AsSingle();
            Container.BindInterfacesTo<PlayerMovementForceGenerator>().AsSingle();
        }
    }
}