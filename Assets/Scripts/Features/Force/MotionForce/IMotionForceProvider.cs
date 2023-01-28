using System;
using UnityEngine;

namespace WizardSpells.Features.Force.MotionForce
{
    public interface IMotionForceProvider
    {
        event Action MotionForceChanged;
        Vector3 GetMotionForce();
    }
}