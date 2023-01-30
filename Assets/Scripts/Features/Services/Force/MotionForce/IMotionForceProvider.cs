using System;
using UnityEngine;

namespace WizardSpells.Features.Services.Force.MotionForce
{
    public interface IMotionForceProvider
    {
        event Action MotionForceChanged;
        Vector3 GetMotionForce();
    }
}