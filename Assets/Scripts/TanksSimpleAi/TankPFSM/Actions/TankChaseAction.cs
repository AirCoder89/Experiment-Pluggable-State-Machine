using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Actions
{
    [CreateAssetMenu(menuName = "PFSM/Actions/Chase")]
    public class TankChaseAction : SmAction
    {
        public float attackDistance;
        public bool attack;
        private TankMachine _machine;
        
        public override void OnEnter<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            _machine = machine as TankMachine;
            if(_machine == null)   throw new Exception($"State machine is null : Action [{typeof(TankChaseAction)}]");

            //2- init action
            _machine.parent.agent.enabled = true;
        }

        public override void OnUpdate<T>(StateMachine<T> machine)
        {
            //2- do action
           if(_machine.parent.targetActor == null) return;
               _machine.parent.MoveTo(_machine.parent.targetActor.transform.position);
               if (attack && ((_machine.parent.remainingDistance - attackDistance) <= _machine.parent.targetDistance))
               {
                  _machine.parent.Fire();
               }
        }

        public override void OnExit<T>(StateMachine<T> machine)
        {
           
        }

    }
}