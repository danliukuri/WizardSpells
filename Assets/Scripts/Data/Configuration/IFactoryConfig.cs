using UnityEngine;

namespace WizardSpells.Data.Configuration
{
    public interface IFactoryConfig
    {
        GameObject Prefab { get; }
    }
}