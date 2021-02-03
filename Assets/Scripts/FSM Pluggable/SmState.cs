using System;
using NaughtyAttributes;
using UnityEngine;

namespace FSM_Pluggable
{
    [CreateAssetMenu (menuName = "PFSM/State")]
    public class SmState : ScriptableObject
    {
        public Color stateColor;
        [BoxGroup("Actions")][ReorderableList] public SmAction[] actions;
        [BoxGroup("Transitions")][ReorderableList] public SmTransition[] transitions;

        public void OnEnterState<T>(StateMachine<T> machine) where T : MonoBehaviour
        {
            machine.SetGizmoColor(stateColor);
            foreach (var transition in transitions)
                transition.OnEnterState(machine);
            
            for (var i = 0; i < actions.Length; i++) 
                actions[i].OnEnter(machine);
        }
        public void UpdateState<T>(StateMachine<T> machine) where T : MonoBehaviour
        {
            DoActions(machine);
            CheckTransitions(machine);
        }
        public void OnExitState<T>(StateMachine<T> machine) where T : MonoBehaviour
        {
            for (var i = 0; i < actions.Length; i++) 
                actions[i].OnExit(machine);
        }
        
        private void DoActions<T>(StateMachine<T> machine) where T : MonoBehaviour
        {
            for (var i = 0; i < actions.Length; i++) 
                actions[i].OnUpdate(machine);
        }

        private void CheckTransitions<T>(StateMachine<T> machine) where T : MonoBehaviour
        {
            for (var i = 0; i < transitions.Length; i++) 
            {
                var decisionSucceeded = transitions[i].decision.Decide(machine);
                if (decisionSucceeded) 
                {
                    machine.TransitionToState (transitions[i].trueState);
                } 
                else if(transitions[i].hasFalseState)
                {
                    if(transitions[i].falseState == null)
                        throw new Exception("when hasFalseState = true, falseState must be not null !!");
                    machine.TransitionToState(transitions[i].falseState);
                }
            }
        }


    }
}