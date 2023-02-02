using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Force.Accumulators;
using WizardSpells.Features.Services.Force.MotionForce;
using Zenject;

namespace WizardSpells.Features.Services.Force.Generators.Environment
{
    public class StickingForceGenerator : ITickable
    {
        private readonly IPermanentForceAccumulator _forceAccumulator;
        private readonly ICharacterData _forceUserData;

        public StickingForceGenerator(ICharacterData forceUserData, IPermanentForceAccumulator forceAccumulator)
        {
            _forceUserData = forceUserData;
            _forceAccumulator = forceAccumulator;
        }

        public void Tick()
        {
            Vector3 currentForce = _forceAccumulator.PermanentForce;
            if (_forceUserData.IsGrounded && !currentForce.IsEnoughToMoveUp() && !IsEnoughToStayGrounded(currentForce))
                GenerateStickingForce();
        }

        private bool IsEnoughToStayGrounded(Vector3 motionForce) =>
            motionForce.y <= -_forceUserData.ColliderContactOffset;

        private void GenerateStickingForce() =>
            _forceAccumulator.AccumulatePermanentForce(Vector3.down * _forceUserData.ColliderContactOffset);
    }
}