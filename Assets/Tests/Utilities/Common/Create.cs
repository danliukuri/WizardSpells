using System;
using UnityEngine;

namespace WizardSpells.Tests.Utilities.Common
{
    public static class Create
    {
        public static GameObject GameObject(params Type[] componentTypesToAttach)
        {
            var newGameObject = new GameObject();
            foreach (Type type in componentTypesToAttach)
                newGameObject.AddComponent(type);
            return newGameObject;
        }
    }
}