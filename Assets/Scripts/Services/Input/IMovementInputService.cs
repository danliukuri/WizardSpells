using UnityEngine;

namespace WizardSpells.Services.Input
{
    public interface IMovementInputService
    {
        bool HasInput { get; }
        Vector2 GetInput();
    }
}