using UnityEngine;
using Zenject;

namespace WizardSpells.Tests.Utilities.Infrastructure.Factories.Components
{
    public class TestObject : MonoBehaviour
    {
        [Inject] public float FloatValue { get; }
    }
}