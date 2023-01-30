using UnityEngine.InputSystem;

namespace WizardSpells.Data.Static.Configuration.Player
{
    public interface IInputActionsConfig
    {
        InputAction Move { get; }
        InputAction Jump { get; }
        float MoveSmoothDelta { get; }
    }
}