using System;
using UnityEngine;
using WizardSpells.Features.Services.Force.Providers;

namespace WizardSpells.Features.Services.Force.Accumulators
{
    public class ForceAccumulator : IInstantForceAccumulator, IPermanentForceAccumulator, IForceProvider
    {
        private Vector3 _instantForce;
        private Vector3 _permanentForce;

        public event Action ForceChanged;
        
        public Vector3 GetForce()
        {
            Vector3 moveForce = _permanentForce + _instantForce;
            _instantForce = Vector3.zero;
            return moveForce;
        }

        public Vector3 PermanentForce => _permanentForce;

        public void AccumulatePermanentForce(Vector3 force) => AccumulatePermanentForce(force.x, force.y, force.z);

        public void AccumulatePermanentForce(float x = default, float y = default, float z = default)
        {
            _permanentForce.x += x;
            _permanentForce.y += y;
            _permanentForce.z += z;
            ForceChanged?.Invoke();
        }

        public void AccumulateInstantForce(Vector3 force)
        {
            _instantForce += force;
            ForceChanged?.Invoke();
        }
    }
}