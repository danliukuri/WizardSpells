using System;

namespace WizardSpells.Data.Dynamic.Player
{
    public class PlayerData : ICharacterData
    {
        private bool _isGrounded;

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

        public float ColliderContactOffset { get; set; }
        public event Action Grounded;
    }
}