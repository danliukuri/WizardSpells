using UnityEngine;

namespace WizardSpells.Features.Services.Force.MotionForce
{
    public static class MotionForceExtensions
    {
        public static bool IsEnoughToMoveUp(this Vector3 motionForce) => motionForce.y > default(float);
    }
}