using System;
using System.Collections;
using Addons.Utils.FastGizmosModule.Scripts;
using NaughtyAttributes;
using UnityEngine;

namespace FSM_Pluggable
{
    public abstract class StateMachine<T> :MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private FastGizmos gizmos;
        [Required]public SmState startState;
        [ReadOnly] public SmState currentState;
        [ReadOnly] public SmState previousState;
        [ReadOnly]public T parent;

        private bool _isRun;
        
        public virtual void Initialize(T machineParent)
        {
            this.parent = machineParent;
            _isRun = false;
        }

        public virtual void StartMachine()
        {
            TransitionToState(startState);
            _isRun = true;
            StartCoroutine(InternalTick());
        }

        public virtual void StopMachine()
        {
            _isRun = false;
            StopCoroutine(InternalTick());
        }
        
        private IEnumerator InternalTick()
        {
            while (this._isRun)
            {
                Tick();
                if(currentState != null) currentState.UpdateState (this);
                yield return null;
            }
        }
        
        public virtual void TransitionToState(SmState nextState)
        {
            if (nextState == null) throw new Exception("Cannot make transition to null state !");
            if(nextState == currentState) return;
                previousState = currentState;
                currentState = nextState;
                if(previousState) previousState.OnExitState(this);
                currentState.OnEnterState(this);
                OnExitState ();
        }

        protected virtual void Tick(){}
        protected virtual void OnExitState() {}

        public void SetGizmoColor(Color color)
        {
            if(gizmos) gizmos.color = color;
        }
    }
}
