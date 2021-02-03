using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Actions
{
    [CreateAssetMenu(menuName = "PFSM/Actions/Idle")]
    public class TankIdleAction : SmAction
    {
        public float idleTime = 2f;

        private float _timeCounter;
        private TankMachine _machine;
        
        public override void OnEnter<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            _machine = machine as TankMachine;
            if(_machine == null)   throw new Exception($"State machine is null : Action [{typeof(TankIdleAction)}]");
            
            //2- init action
            _machine.parent.IsIdle = true;
            _timeCounter = 0f;
        }

        public override void OnUpdate<T>(StateMachine<T> machine)
        {
            if(!_machine.parent.IsIdle) return;
                _timeCounter += Time.deltaTime;
                if (_timeCounter >= idleTime)
                {
                    Debug.Log("Idle Complete");
                    _machine.parent.IsIdle = false;
                }
        }

        public override void OnExit<T>(StateMachine<T> machine)
        {
            //2- exit action
            _machine.parent.IsIdle = false;
        }
    }
}