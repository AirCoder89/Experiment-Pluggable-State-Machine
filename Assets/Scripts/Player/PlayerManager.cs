using System.Collections.Generic;
using Core;
using HUD;
using UnityEngine;

namespace Player
{
    public class PlayerManager : AppSystem
    {
        [SerializeField] private ProgressBar healthPb;
        [SerializeField] private HitFx hitFx;
        [SerializeField] private TankController player;
        
        public override void Initialize(Controller controller)
        {
            this._controller = controller;
            player.Initialize(this);
            player.onDestroy += OnPlayerDestroyed;
            player.onTakeDamage += OnPlayerTakeDamage;
            healthPb.SetProgression(player.health);
        }

        private void OnPlayerTakeDamage(float health)
        {
            hitFx.Play();
            healthPb.SetProgression(health);
        }

        private void OnPlayerDestroyed(IDestroyable target)
        {
            target.Remove();
        }

        public override void Tick()
        {
            if(player != null && player.isAlive)
            player.Tick();
        }
        
    }
}