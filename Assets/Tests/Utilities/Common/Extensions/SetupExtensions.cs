using UnityEngine;

namespace WizardSpells.Tests.Utilities.Common.Extensions
{
    public static class SetupExtensions
    {
        public static T AddIfMissing<T>(this GameObject obj) where T : Component =>
            obj.TryGetComponent(out T component) ? component : obj.AddComponent<T>();
    }
}