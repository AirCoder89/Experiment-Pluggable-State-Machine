using System;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Actions
{
    [CreateAssetMenu(menuName = "PFSM/Actions/GetNearest")]
    public class TankGetNearestAction : SmAction
    {
        public override void OnEnter<T>(StateMachine<T> machine) {}

        public override void OnUpdate<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            if (typeof(T) != typeof(TankController) || machine.parent == null)
                throw new Exception("machine parent must be not null !!");
            var parent = machine.parent as TankController;
            if(parent == null) 
                throw new Exception($"State machine parent is null : parent type [{typeof(T)}]");
            //2- do action
            //parent.GetNearest();
        }

        public override void OnExit<T>(StateMachine<T> machine) {}

    }
}