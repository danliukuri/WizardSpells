using UnityEngine.InputSystem;

namespace WizardSpells.Data.Configuration.Player
{
    public interface IInputActionsConfig
    {
        InputAction Move { get; }
        InputAction Jump { get; }
        float MoveSmoothDelta { get; }
    }
}