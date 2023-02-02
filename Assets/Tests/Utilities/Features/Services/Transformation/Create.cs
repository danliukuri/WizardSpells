using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Force.MotionForce;
using WizardSpells.Features.Services.Transformation;
using WizardSpells.Tests.Utilities.Common.Extensions;

namespace WizardSpells.Tests.Utilities.Features.Services.Transformation
{
    public static class Create
    {
        public static CharacterController CharacterController(GameObject gameObject = default) =>
            gameObject.NewIfDefault().AddIfMissing<CharacterController>();

        public static CharacterController GroundedCharacterController(GameObject ground = default) =>
            CharacterController().PlaceAbove(ground ? ground : Common.Create.Ground())
                .MakeGrounded();

        public static PositionChanger PositionChanger(CharacterController characterController = default,
            ICharacterData data = default, IMotionForceProvider motionForceProvider = default) =>
            new(characterController ? characterController : CharacterController(),
                data.SubstituteIfDefault(), motionForceProvider.SubstituteIfDefault());
    }
}