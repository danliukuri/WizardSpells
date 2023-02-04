using System;
using UnityEngine;

namespace WizardSpells.Features.Services.Force.Providers
{
    public interface IForceProvider
    {
        event Action ForceChanged;
        Vector3 GetForce();
    }
}