using System;
using Addons.Utils.FastGizmosModule.Scripts;
using Core;
using HUD;
using NaughtyAttributes;
using PathologicalGames;
using TanksSimpleAi.TankPFSM;
using UnityEngine;
using UnityEngine.AI;

namespace TanksSimpleAi
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(TankMachine))]
    public class TankNpc : MonoBehaviour, IDestroyable
    {
        [BoxGroup] [SerializeField][Label("Health")][ProgressBar(100,EColor.Green)] private float hp = 100f;
        [BoxGroup("Internal References")][SerializeField][Required] private RangeTrigger range;
        [BoxGroup("Internal References")][SerializeField][Required] private Transform spawnPoint;
        [BoxGroup("Internal References")][SerializeField]private string bulletName;
        [BoxGroup("Internal References")][SerializeField]private ProgressBar healthBar;

        [BoxGroup("Parameters")][SerializeField] float fireDamage = 5f;
        [BoxGroup("Parameters")][SerializeField] float fireInterval = 0.5f;
        [BoxGroup("Parameters")][SerializeField] float bulletSpeed = 20.0f;
        
        private SpawnPool _p;
        private SpawnPool pool
        {
            get
            {
                if (_p == null) _p = PoolManager.Pools[Controller.Instance.poolName];
                return _p;
            }
        }
        
        public event Action<IDestroyable> onDestroy;

        public bool isAlive { get; private set; }

        public float health
        {
            get => hp;
            set
            {
                hp = value;
                if (!(hp <= 0f)) return;
                hp = 0f;
                isAlive = false;
                onDestroy?.Invoke(this);
            }
        }
        public void ApplyDamage(float damage)
        {
            this.health -= damage;
            healthBar.SetProgression(this.health);
        }

        public float remainingDistance { get; set; }
        public float targetDistance { get; set; }

        
        //Flags
        public bool IsIdle { get; set; }
        public bool IsWayPointsReached { get; set; }
        public bool IsOnPatrol { get; set; }
        
        public void Remove()
        {
            GameObject.Destroy(this.gameObject);
        }

        public TankMachine machine { get; private set; }
        public NavMeshAgent agent { get; private set; }
        public Rigidbody rigidbody { get; private set; }
        
        private NPCManager _manager;
        private float _nextFire;
        public Transform targetActor;
        
        public void Initialize(NPCManager manager)
        {
            health = 100f;
            isAlive = health > 0f;
            IsIdle = false;
            _nextFire = Time.time + fireInterval;
            this._manager = manager;
            range.Initialize(this.transform);
            range.onDetect.AddListener(OnDetectEnemy);
            range.onLostDetection.AddListener(OnLostDetectionEnemy);
            machine = GetComponent<TankMachine>();
            machine.Initialize(this);
            machine.StartMachine();
            agent = GetComponent<NavMeshAgent>();
            rigidbody = GetComponent<Rigidbody>();    
        }

        private void OnLostDetectionEnemy(Transform target)
        {
            if (targetActor == target)
            {
                targetActor = null;
            }
        }

        private void OnDetectEnemy(Transform target)
        {
            targetActor = target;
        }

        public void MoveTo(Vector3 target)
        {
            if(agent == null)
                throw new NullReferenceException($"_agent [{typeof(NavMeshAgent)}] must be not null");
            
            agent.SetDestination(target);
            remainingDistance = agent.remainingDistance;
            targetDistance = agent.stoppingDistance;
        }
        
        [Button("Fire")]
        public void Fire()
        {
            if (Time.time > _nextFire)
            {
                print("NPC Fire");
                _nextFire = Time.time + fireInterval;
                var bullet = pool.Spawn(this.bulletName).gameObject.GetComponent<Bullet>();
                bullet.Initialize(this.pool, this.gameObject, this.fireDamage);
                bullet.transform.position = this.spawnPoint.position;
                bullet.rigidBody.velocity = transform.forward * bulletSpeed;
            }
        }

        public void GetNearest() => targetActor = this.range.GetNearest();
        public void OnStartPatrol() => IsOnPatrol = true;
        public void OnEndPatrol() => IsOnPatrol = false;
    }
}