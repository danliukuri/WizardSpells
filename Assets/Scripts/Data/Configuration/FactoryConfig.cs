using UnityEngine;

namespace WizardSpells.Data.Configuration
{
    [CreateAssetMenu(fileName = nameof(FactoryConfig), menuName = "Configuration/Factory")]
    public class FactoryConfig : ScriptableObject, IFactoryConfig
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}