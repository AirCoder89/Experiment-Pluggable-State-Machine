using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Decisions
{
    [CreateAssetMenu(menuName = "PFSM/Decisions/PatrolComplete")]
    public class TankPatrolCompleteDecision : SmDecision
    {
        private TankMachine _machine;
        
        public override void OnEnterState<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            _machine = machine as TankMachine;
            if(_machine == null)   throw new Exception($"State machine is null : Decision [{typeof(TankPatrolCompleteDecision)}]");
        }

        public override bool Decide<T>(StateMachine<T> machine)
        {
            return _machine.parent.IsWayPointsReached;
        }
    }
}