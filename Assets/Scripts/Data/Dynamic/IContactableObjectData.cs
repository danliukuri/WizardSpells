namespace WizardSpells.Data.Dynamic
{
    public interface IContactableObjectData : IGroundableObjectData
    {
        public float ContactOffset { get; set; }
    }
}