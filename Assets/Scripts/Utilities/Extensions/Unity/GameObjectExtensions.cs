using System;
using UnityEngine;

namespace WizardSpells.Utilities.Extensions.Unity
{
    public static class GameObjectExtensions
    {
        public static T AsInactive<T>(this GameObject original,
            Func<GameObject, Transform, T> instantiationFunc, Transform parent = default) where T : UnityEngine.Object
        {
            bool previousActiveState = original.activeSelf;
            
            original.SetActive(false);
            T copy = instantiationFunc.Invoke(original, parent);
            original.SetActive(previousActiveState);
            
            return copy;
        }
    }
}