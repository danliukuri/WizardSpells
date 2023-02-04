using System;
using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Force.Providers;
using Zenject;

namespace WizardSpells.Features.Services.Transformation
{
    public class PositionChanger : IInitializable, IDisposable, ITickable
    {
        private readonly CharacterController _characterController;
        private readonly IGroundableObjectData _data;
        private readonly IForceProvider _motionForceProvider;

        private bool _isNeededToChangePosition;

        public PositionChanger(CharacterController characterController, IGroundableObjectData data,
            IForceProvider motionForceProvider)
        {
            _characterController = characterController;
            _data = data;
            _motionForceProvider = motionForceProvider;
        }

        public void Initialize() => _motionForceProvider.ForceChanged += ChangePositionNextFrame;

        public void Dispose() => _motionForceProvider.ForceChanged -= ChangePositionNextFrame;

        public void Tick()
        {
            if (_isNeededToChangePosition)
                ChangePosition(_motionForceProvider.GetForce() * Time.deltaTime);
        }

        private void ChangePositionNextFrame() => _isNeededToChangePosition = true;

        public void ChangePosition(Vector3 motionForce)
        {
            _characterController.Move(motionForce);
            _data.IsGrounded = _characterController.isGrounded;
            _isNeededToChangePosition = false;
        }
    }
}