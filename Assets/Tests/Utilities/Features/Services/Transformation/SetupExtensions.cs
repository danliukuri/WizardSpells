using UnityEngine;

namespace WizardSpells.Tests.Utilities.Features.Services.Transformation
{
    public static class SetupExtensions
    {
        public static CharacterController MakeGrounded(this CharacterController characterController)
        {
            characterController.Move(Vector3.down * characterController.contactOffset);
            return characterController;
        }
        public static CharacterController MakeUngrounded(this CharacterController characterController)
        {
            characterController.Move(Vector3.up * characterController.contactOffset);
            return characterController;
        }
    }
}