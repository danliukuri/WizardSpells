using System;
using UnityEngine;
using UnityEngine.InputSystem;
using WizardSpells.Data.Static.Configuration.Player;
using Zenject;

namespace WizardSpells.Services.Input.Player
{
    public class PLayerMovementInputService : IMovementInputService, IInitializable, IDisposable
    {
        private InputAction _moveInputAction;
        
        private Vector2 _currentInputVelocity;
        private Vector2 _currentInput;
        private float _smoothInputDelta;

        public bool HasInput => _currentInputVelocity != Vector2.zero || _moveInputAction.IsInProgress(); 

        [Inject]
        public void Construct(IInputActionsConfig inputActionsConfig)
        {
            _moveInputAction = inputActionsConfig.Move;
            _smoothInputDelta = inputActionsConfig.MoveSmoothDelta;
        }

        public void Initialize() => _moveInputAction.Enable();
        
        public void Dispose() => _moveInputAction.Disable();

        public Vector2 GetInput()
        {
            var targetInput = _moveInputAction.ReadValue<Vector2>();
            return _currentInput =
                Vector2.SmoothDamp(_currentInput, targetInput, ref _currentInputVelocity, _smoothInputDelta);
        }
    }
}