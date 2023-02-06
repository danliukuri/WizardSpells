using UnityEngine;
using UnityEngine.Pool;
using WizardSpells.Features.Player;
using WizardSpells.Utilities.Patterns.State;

namespace WizardSpells.Architecture.GameStates
{
    public class SetupGameState : IEnterableState
    {
        private readonly IObjectPool<Player> _playerPool;

        public SetupGameState(IObjectPool<Player> playerPool) => _playerPool = playerPool;

        public void Enter()
        {
            Debug.Log("SetupGameState.Enter");
            _playerPool.Get();
        }
    }
}