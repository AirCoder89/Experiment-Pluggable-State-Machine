using System;
using TanksSimpleAi;
using UnityEngine;

namespace FSM_Pluggable
{
    public abstract class SmDecision : ScriptableObject
    {
        public abstract void OnEnterState<T>(StateMachine<T> machine) where T : MonoBehaviour;
        public abstract bool Decide<T> (StateMachine<T> machine) where T : MonoBehaviour;
    }
}