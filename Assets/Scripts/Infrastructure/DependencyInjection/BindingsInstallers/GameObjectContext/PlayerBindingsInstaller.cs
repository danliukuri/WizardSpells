using UnityEngine;
using WizardSpells.Data.Configuration.Player;
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
            BindInputServices();
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
    }
}