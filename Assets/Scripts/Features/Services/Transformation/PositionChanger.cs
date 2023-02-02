using UnityEngine;
using WizardSpells.Data.Dynamic;

namespace WizardSpells.Features.Services.Transformation
{
    public class PositionChanger : IPositionChanger
    {
        private readonly CharacterController _characterController;
        private readonly ICharacterData _data;

        public PositionChanger(CharacterController characterController, ICharacterData data)
        {
            _characterController = characterController;
            _data = data;
            _data.ColliderContactOffset = _characterController.contactOffset;
        }

        public void ChangePosition(Vector3 motionForce)
        {
            _characterController.Move(motionForce);
            _data.IsGrounded = _characterController.isGrounded;
        }
    }
}