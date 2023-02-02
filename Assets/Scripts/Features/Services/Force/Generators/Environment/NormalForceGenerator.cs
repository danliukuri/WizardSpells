using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Force.Accumulators;

namespace WizardSpells.Features.Services.Force.Generators.Environment
{
    /// <remarks>
    ///     <a href="https://en.wikipedia.org/wiki/Normal_force">Normal force</a>
    /// </remarks>
    public class NormalForceGenerator : IForceGenerator
    {
        private readonly IPermanentForceAccumulator _forceAccumulator;
        private readonly ICharacterData _forceUserData;

        public NormalForceGenerator(IPermanentForceAccumulator forceAccumulator, ICharacterData forceUserData)
        {
            _forceAccumulator = forceAccumulator;
            _forceUserData = forceUserData;
        }

        public void GenerateForce(float deltaTime)
        {
            Vector3 currentForce = _forceAccumulator.PermanentForce;
            if (_forceUserData.IsGrounded && !IsEnoughToMoveUp(currentForce) && IsBigEnoughToReact(currentForce))
                GenerateNormalForce();
        }

        private static bool IsEnoughToMoveUp(Vector3 motionForce) => motionForce.y > default(float);

        private bool IsBigEnoughToReact(Vector3 motionForce) =>
            Mathf.Abs(motionForce.y) > _forceUserData.ColliderContactOffset;

        private void GenerateNormalForce() =>
            _forceAccumulator.AccumulatePermanentForce(y: -_forceAccumulator.PermanentForce.y);
    }
}