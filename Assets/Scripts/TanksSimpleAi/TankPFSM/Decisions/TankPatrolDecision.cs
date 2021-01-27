using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Decisions
{
    [CreateAssetMenu(menuName = "PFSM/Decisions/Patrol")]
    public class TankPatrolDecision : SmDecision
    {
        public override bool Decide<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            var tankMachine = machine as TankMachine;
            if(tankMachine == null) 
                throw new Exception($"State machine is null : Decision [{typeof(TankPatrolDecision)}]");

            return true;
            //return !vehicleAi.shouldBeIdle;
        }
    }

}