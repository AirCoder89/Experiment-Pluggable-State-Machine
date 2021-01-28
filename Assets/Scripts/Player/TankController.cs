using System;
using Core;
using NaughtyAttributes;
using PathologicalGames;
using UnityEngine;

namespace Player
{
    public class TankController : MonoBehaviour, IDestroyable
    {
        [BoxGroup] [SerializeField][Label("Health")][ProgressBar(100,EColor.Green)] private float hp = 100f;
        [BoxGroup("Internal References")][SerializeField][Required] private Transform spawnPoint;
        [BoxGroup("Internal References")][SerializeField]private string bulletName;
   
        
        [BoxGroup("Parameters")][SerializeField] float rotateSpeed = 90f;
        [BoxGroup("Parameters")][SerializeField] float speed = 5f;
        [BoxGroup("Parameters")][SerializeField] float fireDamage = 5f;
        [BoxGroup("Parameters")][SerializeField] float fireInterval = 0.5f;
        [BoxGroup("Parameters")][SerializeField] float bulletSpeed = 20.0f;


        public event Action<IDestroyable> onDestroy;
         
                 public float health
                 {
                     get => hp;
                     set
                     {
                         hp = value;
                         if (!(hp <= 0f)) return;
                             hp = 0f;
                             onDestroy?.Invoke(this);
                     }
                 }

        private SpawnPool _p;
        private SpawnPool pool
        {
            get
            {
                if (_p == null) _p = PoolManager.Pools[Controller.Instance.poolName];
                return _p;
            }
        }
        
        public Rigidbody rigidbody { get; private set; }
        private float _nextFire;
        private PlayerManager _manager;
        

        public void Initialize(PlayerManager manager)
        {
            health = 100f;
            _manager = manager;
            _nextFire = Time.time + fireInterval;
            rigidbody = GetComponent<Rigidbody>();    
        }

        [Button("Apply Damage")]
        private void AD()
        {
            ApplyDamage(10f);
        }
        public void ApplyDamage(float damage)
        {
            this.health -= damage;
        }
        public void Remove()
        {
            GameObject.Destroy(this.gameObject);
        }
        public void Tick()
        {
            var transAmount = speed * Time.deltaTime;
            var rotateAmount = rotateSpeed * Time.deltaTime;

            if (Input.GetKey("up")) {
                transform.Translate(0, 0, transAmount);
            }
            if (Input.GetKey("down")) {
                transform.Translate(0, 0, -transAmount);
            }
            if (Input.GetKey("left")) {
                transform.Rotate(0, -rotateAmount, 0);
            }
            if (Input.GetKey("right")) {
                transform.Rotate(0, rotateAmount, 0);
            }
            if (Input.GetButtonDown("Fire1") && Time.time > _nextFire) {
                _nextFire = Time.time + fireInterval;
                Fire();
            }
        }
        
        private void Fire()
        {
            var bullet = pool.Spawn(this.bulletName).gameObject.GetComponent<Bullet>();
            bullet.Initialize(this.pool, this.gameObject, this.fireDamage);
            bullet.transform.position = this.spawnPoint.position;
            bullet.rigidBody.velocity = transform.forward * bulletSpeed;
        }

       
    }
}