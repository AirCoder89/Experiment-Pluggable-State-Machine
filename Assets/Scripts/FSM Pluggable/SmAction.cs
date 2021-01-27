using FSM_Pluggable;
using UnityEngine;

namespace FSM_Pluggable
{
    public abstract class SmAction : ScriptableObject 
    {
        public abstract void OnEnter<T> (StateMachine<T> machine) where T : MonoBehaviour;
        public abstract void OnUpdate<T> (StateMachine<T> machine) where T : MonoBehaviour;
        public abstract void OnExit<T> (StateMachine<T> machine) where T : MonoBehaviour;
    }
}