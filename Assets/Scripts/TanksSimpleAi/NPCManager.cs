using System.Collections.Generic;
using Core;
using UnityEngine;

namespace TanksSimpleAi
{
    public class NPCManager : AppSystem
    {
        private List<TankNpc> _tanks;
        public override void Initialize(Controller controller)
        {
            this._controller = controller;
            _tanks = new List<TankNpc>();
            foreach (Transform child in transform)
            {
                var t = child.gameObject.GetComponent<TankNpc>();
                if(t == null) continue;
                t.Initialize(this);
                t.onDestroy += OnNpcTankDestroyed;
                _tanks.Add(t);
            }
        }

        private void OnNpcTankDestroyed(IDestroyable npcTank)
        {
            npcTank.Remove();
        }
    }
}