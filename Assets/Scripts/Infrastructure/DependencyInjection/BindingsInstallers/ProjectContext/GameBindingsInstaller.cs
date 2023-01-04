using System;
using System.Collections.Generic;
using Infrastructure.GameStates;
using Infrastructure.GameStates.InitialSettingStrategies;
using Utilities.Patterns.State.Machines;
using Zenject;

namespace Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class GameBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindGameStates();

            BindInitialGameStateSettingStrategies();
            BindInitialGameStateSettingStrategyProvider();
        }

        private void BindGameStateMachine()
        {
            Container.BindInterfacesTo<StateMachine>().AsSingle();
            Container.BindInterfacesTo<StateMachineInitializer>().AsSingle();
        }

        private void BindGameStates()
        {
            var gameStatesTypes = new List<Type>
            {
                typeof(LoadingGameState),
                typeof(SetupGameState)
            };
            gameStatesTypes.ForEach(stateType => Container.BindInterfacesTo(stateType).AsSingle());
        }

        private void BindInitialGameStateSettingStrategies()
        {
            var initialGameStateSettingStrategyTypes = new List<Type>
            {
                typeof(InitialGameStateSettingDefaultStrategy),
                typeof(InitialGameStateSettingBootstrapSceneStrategy),
                typeof(InitialGameStateSettingMainSceneStrategy)
            };
            foreach (Type initialGameStateSettingStrategyType in initialGameStateSettingStrategyTypes)
                Container.BindInterfacesAndSelfTo(initialGameStateSettingStrategyType).AsTransient();
        }

        private void BindInitialGameStateSettingStrategyProvider() =>
            Container.BindInterfacesTo<InitialGameStateSettingStrategyProvider>().AsSingle();
    }
}