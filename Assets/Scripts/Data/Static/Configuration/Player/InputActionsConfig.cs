using UnityEngine;
using UnityEngine.InputSystem;

namespace WizardSpells.Data.Static.Configuration.Player
{
    [CreateAssetMenu(fileName = nameof(InputActionsConfig), menuName = "Configuration/Input Actions")]
    public class InputActionsConfig : ScriptableObject, IInputActionsConfig
    {
        [SerializeField] private InputActionReference move;
        [SerializeField] private InputActionReference jump;
        public InputAction Move => move.action;
        public InputAction Jump => jump.action;

        [field: SerializeField, Min(default)] public float MoveSmoothDelta { get; private set; }
    }
    
}