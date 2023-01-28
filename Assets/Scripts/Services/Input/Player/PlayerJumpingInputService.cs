using System;
using UnityEngine.InputSystem;
using WizardSpells.Data.Configuration.Player;
using Zenject;

namespace WizardSpells.Services.Input.Player
{
    public class PlayerJumpingInputService : IJumpingInputService, IInitializable, IDisposable
    {
        private InputAction _jumpInputAction;
        
        public event Action InputReceived;

        [Inject]
        public void Construct(IInputActionsConfig inputActionsConfig) => _jumpInputAction = inputActionsConfig.Jump;

        public void Initialize()
        {
            _jumpInputAction.Enable();
            _jumpInputAction.performed += OnJumpInputReceived;
        }

        public void Dispose()
        {
            _jumpInputAction.Disable();
            _jumpInputAction.performed -= OnJumpInputReceived;
        }

        private void OnJumpInputReceived(InputAction.CallbackContext inputInfo) => InputReceived?.Invoke();
    }
}