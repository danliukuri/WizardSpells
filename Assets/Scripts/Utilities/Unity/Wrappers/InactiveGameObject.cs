using System;
using UnityEngine;

namespace WizardSpells.Utilities.Unity.Wrappers
{
    public readonly struct InactiveGameObject : IDisposable
    {
        private readonly GameObject _gameObject;
        private readonly bool _previousActiveState;
        
        public InactiveGameObject(GameObject gameObject)
        {
            
            _gameObject = gameObject;
            _previousActiveState = gameObject.activeSelf;
            gameObject.SetActive(false);
            
        }

        void IDisposable.Dispose() => _gameObject.SetActive(_previousActiveState);
    }
}