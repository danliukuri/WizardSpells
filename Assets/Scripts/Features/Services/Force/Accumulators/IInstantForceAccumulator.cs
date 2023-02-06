using UnityEngine;

namespace WizardSpells.Features.Services.Force.Accumulators
{
    public interface IInstantForceAccumulator
    {
        void AccumulateInstantForce(Vector3 force);
    }
}