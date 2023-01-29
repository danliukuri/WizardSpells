using UnityEngine;

namespace WizardSpells.Features.Transformation
{
    public interface IPositionChanger
    {
        void ChangePosition(Vector3 motionForce);
    }
}