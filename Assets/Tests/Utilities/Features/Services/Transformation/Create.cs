using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Force.Providers;
using WizardSpells.Features.Services.Transformation;
using WizardSpells.Tests.Utilities.Common.Extensions;

namespace WizardSpells.Tests.Utilities.Features.Services.Transformation
{
    public static class Create
    {
        public static CharacterController CharacterController(GameObject gameObject = default) =>
            gameObject.NewIfDefault().AddIfMissing<CharacterController>();

        public static PositionChanger PositionChanger(CharacterController characterController = default,
            IGroundableObjectData data = default, IForceProvider motionForceProvider = default) =>
            new(characterController ? characterController : CharacterController(),
                data.SubstituteIfDefault(), motionForceProvider.SubstituteIfDefault());
    }
}