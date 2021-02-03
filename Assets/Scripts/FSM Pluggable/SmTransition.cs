using NaughtyAttributes;
using UnityEngine;

namespace FSM_Pluggable
{
    [System.Serializable]
    public class SmTransition
    {
        public bool hasFalseState;
        [Required] public SmDecision decision;
        [Required]public SmState trueState;
        [ShowIf("hasFalseState")][Required]public SmState falseState;

        public void OnEnterState<T>(StateMachine<T> machine) where T : MonoBehaviour => decision.OnEnterState(machine);
    }
}