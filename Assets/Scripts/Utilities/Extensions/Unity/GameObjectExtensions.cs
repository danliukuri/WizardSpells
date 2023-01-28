using System;
using UnityEngine;
using WizardSpells.Utilities.Unity.Wrappers;

namespace WizardSpells.Utilities.Extensions.Unity
{
    public static class GameObjectExtensions
    {
        public static InactiveGameObject AsInactive(this GameObject original) => new(original);

        public static T AsInactive<T>(this GameObject original,
            Func<GameObject, Transform, T> instantiationFunc, Transform parent = default) where T : UnityEngine.Object
        {
            using (original.AsInactive())
                return instantiationFunc.Invoke(original, parent);
        }
    }
}