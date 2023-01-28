using UnityEngine;

namespace WizardSpells.Data.Configuration.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configuration/Player")]

    public class PlayerConfig : ScriptableObject, IPlayerConfig
    {
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float JumpPower { get; private set; }
    }
}