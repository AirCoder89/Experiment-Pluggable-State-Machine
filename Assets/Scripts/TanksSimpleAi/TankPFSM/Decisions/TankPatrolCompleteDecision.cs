using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Decisions
{
    [CreateAssetMenu(menuName = "PFSM/Decisions/PatrolComplete")]
    public class TankPatrolCompleteDecision : SmDecision
    {
        public override bool Decide<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            if (typeof(T) != typeof(TankController) || machine.parent == null)
                throw new Exception("machine parent must be not null !!");
            var parent = machine.parent as TankController;
            if(parent == null) 
                throw new Exception($"State machine parent is null : parent type [{typeof(T)}]");

            return true;
            //return parent.targetActor != null;
        }
    }
}