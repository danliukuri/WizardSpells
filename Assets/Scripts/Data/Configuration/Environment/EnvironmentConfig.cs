using UnityEngine;

namespace WizardSpells.Data.Configuration.Environment
{
    [CreateAssetMenu(fileName = nameof(EnvironmentConfig), menuName = "Configuration/Environment")]
    public class EnvironmentConfig : ScriptableObject, IEnvironmentConfig
    {
        [field: SerializeField] public Vector3 GravityForce { get; private set; }
    }
}