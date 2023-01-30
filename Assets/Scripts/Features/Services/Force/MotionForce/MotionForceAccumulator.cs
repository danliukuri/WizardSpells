using System;
using UnityEngine;
using WizardSpells.Features.Services.Force.Accumulators;

namespace WizardSpells.Features.Services.Force.MotionForce
{
    public class MotionForceAccumulator : IInstantForceAccumulator, IPermanentForceAccumulator, IMotionForceProvider
    {
        private Vector3 _instantForce;
        private Vector3 _permanentForce;

        public event Action MotionForceChanged;
        
        public Vector3 GetMotionForce()
        {
            Vector3 moveForce = PermanentForce + _instantForce;
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
            MotionForceChanged?.Invoke();
        }

        public void AccumulateInstantForce(Vector3 force)
        {
            _instantForce += force;
            MotionForceChanged?.Invoke();
        }
    }
}