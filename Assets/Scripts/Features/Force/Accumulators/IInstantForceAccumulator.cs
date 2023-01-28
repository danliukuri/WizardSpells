using UnityEngine;

namespace WizardSpells.Features.Force.Accumulators
{
    public interface IInstantForceAccumulator
    {
        void AccumulateInstantForce(Vector3 force);
    }
}