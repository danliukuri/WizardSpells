using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Force.Accumulators;
using WizardSpells.Features.Services.Force.MotionForce;
using Zenject;

namespace WizardSpells.Features.Services.Force.Generators.Environment
{
    /// <remarks>
    ///     <a href="https://en.wikipedia.org/wiki/Normal_force">Normal force</a>
    /// </remarks>
    public class NormalForceGenerator : ITickable
    {
        private readonly IPermanentForceAccumulator _forceAccumulator;
        private readonly ICharacterData _forceUserData;

        public NormalForceGenerator(IPermanentForceAccumulator forceAccumulator, ICharacterData forceUserData)
        {
            _forceAccumulator = forceAccumulator;
            _forceUserData = forceUserData;
        }

        public void Tick()
        {
            Vector3 currentForce = _forceAccumulator.PermanentForce;
            if (_forceUserData.IsGrounded && !currentForce.IsEnoughToMoveUp() && IsBigEnoughToReact(currentForce))
                GenerateNormalForce();
        }

        private bool IsBigEnoughToReact(Vector3 motionForce) =>
            Mathf.Abs(motionForce.y) > _forceUserData.ColliderContactOffset;

        private void GenerateNormalForce() =>
            _forceAccumulator.AccumulatePermanentForce(y: -_forceAccumulator.PermanentForce.y);
    }
}