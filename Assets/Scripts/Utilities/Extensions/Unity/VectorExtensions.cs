using System.Runtime.CompilerServices;
using UnityEngine;

namespace WizardSpells.Utilities.Extensions.Unity
{
    public static class VectorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 AsXZ(this Vector2 vector) => new(vector.x, default, vector.y);
    }
}