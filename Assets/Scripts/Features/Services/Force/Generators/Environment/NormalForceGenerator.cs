using System;
using UnityEngine;
using WizardSpells.Data.Dynamic;
using WizardSpells.Features.Services.Force.Accumulators;
using Zenject;

namespace WizardSpells.Features.Services.Force.Generators.Environment
{
    /// <remarks>
    ///     <a href="https://en.wikipedia.org/wiki/Normal_force">Normal force</a>
    /// </remarks>
    public class NormalForceGenerator : IInitializable, IDisposable
    {
        private readonly IPermanentForceAccumulator _forceAccumulator;
        private readonly IContactableObjectData _forceUserData;

        public NormalForceGenerator(IPermanentForceAccumulator forceAccumulator, IContactableObjectData forceUserData)
        {
            _forceAccumulator = forceAccumulator;
            _forceUserData = forceUserData;
        }

        public void Initialize() => _forceUserData.Grounded += GenerateNormalForceIfNeeded;
        public void Dispose() => _forceUserData.Grounded -= GenerateNormalForceIfNeeded;

        private bool IsBigEnoughToReact(Vector3 motionForce) => Mathf.Abs(motionForce.y) > _forceUserData.ContactOffset;

        private void GenerateNormalForceIfNeeded()
        {
            if (IsBigEnoughToReact(_forceAccumulator.PermanentForce))
                GenerateNormalForce();
        }

        private void GenerateNormalForce() =>
            _forceAccumulator.AccumulatePermanentForce(y: -_forceAccumulator.PermanentForce.y);
    }
}