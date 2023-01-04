using UnityEngine;
using Utilities.Patterns.State;

namespace Infrastructure.GameStates
{
    public class SetupGameState : IEnterableState
    {
        public void Enter() => Debug.Log("SetupGameState.Enter");
    }
}