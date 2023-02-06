using System;

namespace WizardSpells.Data.Dynamic
{
    public interface IGroundableObjectData
    {
        bool IsGrounded { get; set; }
        event Action Grounded;
    }
}