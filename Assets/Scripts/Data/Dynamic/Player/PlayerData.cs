using System;

namespace WizardSpells.Data.Dynamic.Player
{
    public class PlayerData : IContactableObjectData
    {
        private bool _isGrounded;

        public PlayerData(float contactOffset) => ContactOffset = contactOffset;

        public float ContactOffset { get; set; }
        public event Action Grounded;

        public bool IsGrounded
        {
            get => _isGrounded;
            set
            {
                bool wasGrounded = _isGrounded;
                _isGrounded = value;

                if (!wasGrounded && _isGrounded)
                    Grounded?.Invoke();
            }
        }
    }
}