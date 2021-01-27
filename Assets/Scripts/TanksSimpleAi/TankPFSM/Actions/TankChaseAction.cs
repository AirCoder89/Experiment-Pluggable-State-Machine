using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Actions
{
    [CreateAssetMenu(menuName = "PFSM/Actions/Chase")]
    public class TankChaseAction : SmAction
    {
        public override void OnEnter<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            if (typeof(T) != typeof(TankController) || machine.parent == null)
                throw new Exception("machine parent must be not null !!");
            var parent = machine.parent as TankController;
            if(parent == null) 
                throw new Exception($"State machine parent is null : parent type [{typeof(T)}]");
            var vehicleAi = machine as TankMachine;
            if(vehicleAi == null) 
                throw new Exception($"State machine is null : Action [{typeof(TankChaseAction)}]");

            parent.agent.enabled = true;
        }

        public override void OnUpdate<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            if (typeof(T) != typeof(TankController) || machine.parent == null)
                throw new Exception("machine parent must be not null !!");
            var parent = machine.parent as TankController;
            if(parent == null) 
                throw new Exception($"State machine parent is null : parent type [{typeof(T)}]");
            var tankMachine = machine as TankMachine;
            if(tankMachine == null) 
                throw new Exception($"State machine is null : Action [{typeof(TankChaseAction)}]");
            
           /* if(parent.targetActor != null)
                parent.MoveTo(parent.targetActor.transform.position);*/
        }

        public override void OnExit<T>(StateMachine<T> machine)
        {
           
        }

    }
}