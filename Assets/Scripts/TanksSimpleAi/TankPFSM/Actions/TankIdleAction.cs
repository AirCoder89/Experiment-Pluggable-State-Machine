using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Actions
{
    [CreateAssetMenu(menuName = "PFSM/Actions/Idle")]
    public class TankIdleAction : SmAction
    {
        public override void OnEnter<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            var tankMachine = machine as TankMachine;
            if(tankMachine == null) 
                throw new Exception($"State machine is null : Action [{typeof(TankIdleAction)}]");
            
            //2- do action
            Debug.Log("On Enter Idle action");
                
        }

        public override void OnUpdate<T>(StateMachine<T> machine)
        {
            
        }

        public override void OnExit<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            var tankMachine = machine as TankMachine;
            if(tankMachine == null) 
                throw new Exception($"State machine is null : Action [{typeof(TankIdleAction)}]");
            
            //2- do action
        }
    }
}