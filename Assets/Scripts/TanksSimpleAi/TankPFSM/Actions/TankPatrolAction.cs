using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FSM_Pluggable;
using UnityEngine;

namespace TanksSimpleAi.TankPFSM.Actions
{
    [CreateAssetMenu(menuName = "PFSM/Actions/Patrol")]
    public class TankPatrolAction : SmAction
    {
        public float distanceToReachWayPoint;
        public List<Vector3> wayPoints;
        
        private TankMachine _machine;
        private Vector3 _targetWayPoint;
        private bool _wait;
        private bool _onReachWayPoint;
        private int _wayPointIndex;
        
        public bool IsWayPointsReached
        {
            get
            {
                var reached = _wayPointIndex >= wayPoints.Count;
                _machine.parent.IsWayPointsReached = reached;
                return reached;
            }
        }
        
        public override void OnEnter<T>(StateMachine<T> machine)
        {
            //1- check references & dependencies
            _machine = machine as TankMachine;
            if(_machine == null)   throw new Exception($"State machine is null : Action [{typeof(TankPatrolAction)}]");
            
            //init patrol
            _machine.parent.agent.enabled = true;
            _wayPointIndex = -1;
            UpdateTargetWayPoint();
            _machine.parent.IsOnPatrol = true;
        }

        public override void OnUpdate<T>(StateMachine<T> machine)
        {
           if (!_machine.parent.IsOnPatrol && !IsWayPointsReached) return;
            _machine.parent.MoveTo(_targetWayPoint);
            
            if ((_machine.parent.remainingDistance - distanceToReachWayPoint) <= _machine.parent.targetDistance && !_onReachWayPoint)
            {
                _onReachWayPoint = true;
                UpdateTargetWayPoint();
            }
        }

        public override void OnExit<T>(StateMachine<T> machine) { }

        private void UpdateTargetWayPoint()
        {
            _wayPointIndex++;
            if (IsWayPointsReached)
            {
                _machine.parent.IsOnPatrol = false;
                return;
            }
            
            _targetWayPoint =  wayPoints[_wayPointIndex];
            if (!_wait)
            {
                _wait = true;
                var t = WaitForSeconds(250);
            }
        }

        private async Task WaitForSeconds(int ms)
        {
            await Task.Delay(ms);
            _onReachWayPoint = false;
            _wait = false;
        }
    }
}