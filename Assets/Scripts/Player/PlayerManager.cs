using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Player
{
    public class PlayerManager : AppSystem
    {
        private List<TankController> _players;
        public override void Initialize(Controller controller)
        {
            this._controller = controller;
            _players = new List<TankController>();
            foreach (Transform child in transform)
            {
                var t = child.gameObject.GetComponent<TankController>();
                if(t == null) continue;
                t.Initialize(this);
                t.onDestroy += OnPlayerDestroyed;
                _players.Add(t);
            }
        }

        private void OnPlayerDestroyed(IDestroyable player)
        {
            player.Remove();
        }

        public override void Tick()
        {
            foreach (var tank in _players)
                tank.Tick();
        }
    }
}