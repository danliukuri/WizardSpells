namespace WizardSpells.Data.Dynamic
{
    public interface ICharacterData
    {
        public bool IsGrounded { get; set; }
        public float ColliderContactOffset { get; set; }
    }
}