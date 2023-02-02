namespace WizardSpells.Data.Dynamic.Player
{
    public class PlayerData : ICharacterData
    {
        public bool IsGrounded { get; set; }
        public float ColliderContactOffset { get; set; }
    }
}