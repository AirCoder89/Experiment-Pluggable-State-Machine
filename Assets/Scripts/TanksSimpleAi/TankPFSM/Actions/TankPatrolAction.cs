using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Actions
{
    [CreateAssetMenu(menuName = "PFSM/Actions/Patrol")]
    public class TankPatrolAction : SmAction
    {
        public override void OnEnter<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            var tankMachine = machine as TankMachine;
            if(tankMachine == null) 
                throw new Exception($"State machine is null : Action [{typeof(TankPatrolAction)}]");
            
            //move & check reach
            //if (!vehicleAi.onPatrol) vehicleAi.OnStartPatrol();
        }

        public override void OnUpdate<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            var tankMachine = machine as TankMachine;
            if(tankMachine == null) 
                throw new Exception($"State machine is null : Action [{typeof(TankPatrolAction)}]");
            if (typeof(T) != typeof(TankController) || machine.parent == null)
                throw new Exception("machine parent must be not null !!");
            var parent = machine.parent as TankController;
            if(parent == null) 
                throw new Exception($"State machine parent is null : parent type [{typeof(T)}]");
            
            /*
            if (!vehicleAi.onPatrol) return;
            parent.MoveTo(vehicleAi.targetWaypoint);
            if ((parent.remainingDistance - vehicleAi.distanceToReachWaypoint) <= parent.targetDistance && !vehicleAi.onReachWaypoint)
            {
                vehicleAi.onReachWaypoint = true;
                vehicleAi.UpdateTargetWaypoint();
            }*/
        }

        public override void OnExit<T>(StateMachine<T> machine)
        {
           
        }

    }
}