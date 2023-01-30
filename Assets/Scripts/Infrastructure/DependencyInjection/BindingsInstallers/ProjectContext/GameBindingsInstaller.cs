using System;
using System.Collections.Generic;
using System.Linq;
using WizardSpells.Architecture.GameStates;
using WizardSpells.Architecture.GameStates.InitialSettingStrategies;
using WizardSpells.Data.Static.Enumerations.Scene;
using WizardSpells.Services.Scene;
using WizardSpells.Utilities.Patterns.State.Machines;
using WizardSpells.Utilities.Patterns.Strategy;
using Zenject;

namespace WizardSpells.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class GameBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindGameStates();

            BindInitialGameStateSettingStrategies();
            Container.BindInterfacesTo<SceneStrategyProvider>().AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.BindInterfacesTo<StateMachine>().AsSingle();
            Container.BindInterfacesTo<StateMachineInitializer>().AsSingle();
        }

        private void BindGameStates()
        {
            var gameStatesTypes = new List<Type> { typeof(LoadingGameState), typeof(SetupGameState) };
            gameStatesTypes.ForEach(stateType => Container.BindInterfacesTo(stateType).AsSingle());
        }

        private void BindInitialGameStateSettingStrategies()
        {
            Container
                .Bind<IDictionary<SceneName, IStrategy>>()
                .FromMethod(context => new (SceneName SceneName, Type Type)[]
                    {
                        (SceneName.Bootstrap, typeof(InitialGameStateSettingBootstrapSceneStrategy)),
                        (SceneName.Main, typeof(InitialGameStateSettingMainSceneStrategy))
                    }
                    .ToDictionary(info => info.SceneName, info => (IStrategy)context.Container.Instantiate(info.Type)))
                .AsSingle()
                .WhenInjectedInto<SceneStrategyProvider>();

            Container
                .BindInterfacesAndSelfTo<InitialGameStateSettingDefaultStrategy>()
                .AsSingle()
                .WhenInjectedInto<SceneStrategyProvider>();
        }
    }
}