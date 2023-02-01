using UnityEngine;

namespace WizardSpells.Tests.Utilities.Features.Services.Transformation
{
    public static class SetupExtensions
    {
        public static CharacterController MakeGrounded(this CharacterController characterController)
        {
            characterController.Move(Vector3.down * characterController.stepOffset);
            return characterController;
        }

        public static T PlaceAbove<T>(this T component, GameObject gameObject) where T : Component
        {
            component.transform.position = gameObject.transform.position + Vector3.up;
            return component;
        }
    }
}