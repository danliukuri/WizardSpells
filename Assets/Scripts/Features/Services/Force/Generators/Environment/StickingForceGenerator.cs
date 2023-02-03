using System;
using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Force.Accumulators;
using Zenject;

namespace WizardSpells.Features.Services.Force.Generators.Environment
{
    public class StickingForceGenerator : IInitializable, IDisposable
    {
        private readonly IPermanentForceAccumulator _forceAccumulator;
        private readonly ICharacterData _forceUserData;

        public StickingForceGenerator(IPermanentForceAccumulator forceAccumulator, ICharacterData forceUserData)
        {
            _forceAccumulator = forceAccumulator;
            _forceUserData = forceUserData;
        }

        public void Initialize() => _forceUserData.Grounded += GenerateStickingForceIfNeeded;
        public void Dispose() => _forceUserData.Grounded -= GenerateStickingForceIfNeeded;

        private bool IsEnoughToStayGrounded(Vector3 motionForce) =>
            motionForce.y <= -_forceUserData.ColliderContactOffset;

        private void GenerateStickingForceIfNeeded()
        {
            if (!IsEnoughToStayGrounded(_forceAccumulator.PermanentForce))
                GenerateStickingForce();
        }

        private void GenerateStickingForce() =>
            _forceAccumulator.AccumulatePermanentForce(Vector3.down * _forceUserData.ColliderContactOffset);
    }
}