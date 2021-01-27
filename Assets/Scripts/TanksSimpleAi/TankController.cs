using System;
using NaughtyAttributes;
using TanksSimpleAi.TankPFSM;
using UnityEngine;
using UnityEngine.AI;

namespace TanksSimpleAi
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(TankMachine))]
    public class TankController : MonoBehaviour
    {
        public TankMachine machine { get; private set; }
        public NavMeshAgent agent { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        
        
        private NPCManager _manager;
        public void Initialize(NPCManager manager)
        {
            this._manager = manager;
            machine = GetComponent<TankMachine>();
            machine.Initialize(this);
            agent = GetComponent<NavMeshAgent>();
            rigidbody = GetComponent<Rigidbody>();    
        }
        
        public void MoveTo(Vector3 target)
        {
            if(agent == null)
                throw new NullReferenceException($"_agent [{typeof(NavMeshAgent)}] must be not null");
            
            agent.SetDestination(target);
            //remainingDistance = agent.remainingDistance;
            //targetDistance = agent.stoppingDistance;
        }

    }
}