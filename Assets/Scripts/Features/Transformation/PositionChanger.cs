using UnityEngine;
using WizardSpells.Data.Dynamic;

namespace WizardSpells.Features.Transformation
{
    public class PositionChanger : IPositionChanger
    {
        private readonly CharacterController _characterController;
        private readonly ICharacterData _data;

        public PositionChanger(CharacterController characterController, ICharacterData data)
        {
            _characterController = characterController;
            _data = data;
        }

        public void ChangePosition(Vector3 motionForce)
        {
            if (_data.IsGrounded && !HasForceToStayGrounded(motionForce))
                AddStickingForce(ref motionForce);
            
            _characterController.Move(motionForce);
            _data.IsGrounded = _characterController.isGrounded;
        }

        private static bool HasForceToStayGrounded(Vector3 motionForce) => Mathf.Abs(motionForce.y) > float.Epsilon;

        private void AddStickingForce(ref Vector3 motionForce) => motionForce.y = -_characterController.contactOffset;
    }
}