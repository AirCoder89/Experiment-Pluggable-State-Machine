using UnityEngine;

namespace FSM_Pluggable
{
    public abstract class SmDecision : ScriptableObject
    {
        public abstract bool Decide<T> (StateMachine<T> machine) where T : MonoBehaviour;
    }
}