using NaughtyAttributes;

namespace FSM_Pluggable
{
    [System.Serializable]
    public class SmTransition
    {
        public bool hasFalseState;
        [Required] public SmDecision decision;
        [Required]public SmState trueState;
        [ShowIf("hasFalseState")][Required]public SmState falseState;
    }
}