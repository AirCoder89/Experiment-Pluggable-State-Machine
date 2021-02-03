using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Actions
{
    [CreateAssetMenu(menuName = "PFSM/Actions/GetNearest")]
    public class TankGetNearestAction : SmAction
    {
        private TankMachine _machine;
        
        public override void OnEnter<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            _machine = machine as TankMachine;
            if(_machine == null)   throw new Exception($"State machine is null : Action [{typeof(TankGetNearestAction)}]");
        }

        public override void OnUpdate<T>(StateMachine<T> machine)
        {
            //2- do action
            _machine.parent.GetNearest();
        }

        public override void OnExit<T>(StateMachine<T> machine) {}

    }
}