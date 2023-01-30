using UnityEngine;

namespace WizardSpells.Infrastructure.Services.Input
{
    public interface IMovementInputService
    {
        bool HasInput { get; }
        Vector2 GetInput();
    }
}