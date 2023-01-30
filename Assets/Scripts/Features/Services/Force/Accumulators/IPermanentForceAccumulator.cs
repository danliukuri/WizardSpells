using UnityEngine;

namespace WizardSpells.Features.Services.Force.Accumulators
{
    public interface IPermanentForceAccumulator
    {
        Vector3 PermanentForce { get; }
        void AccumulatePermanentForce(Vector3 force);
        void AccumulatePermanentForce(float x = default, float y = default, float z = default);
    }
}