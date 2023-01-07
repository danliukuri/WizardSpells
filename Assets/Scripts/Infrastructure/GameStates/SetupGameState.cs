using UnityEngine;
using WizardSpells.Utilities.Patterns.State;

namespace WizardSpells.Infrastructure.GameStates
{
    public class SetupGameState : IEnterableState
    {
        public void Enter() => Debug.Log("SetupGameState.Enter");
    }
}