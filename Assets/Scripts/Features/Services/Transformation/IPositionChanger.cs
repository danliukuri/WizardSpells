using UnityEngine;

namespace WizardSpells.Features.Services.Transformation
{
    public interface IPositionChanger
    {
        void ChangePosition(Vector3 motionForce);
    }
}