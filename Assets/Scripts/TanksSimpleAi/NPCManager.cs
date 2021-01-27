using System.Collections.Generic;
using UnityEngine;

namespace TanksSimpleAi
{
    public class NPCManager : MonoBehaviour
    {
        private List<TankController> _tanks;

        private void Start()
        {
            _tanks = new List<TankController>();
            foreach (Transform child in transform)
            {
                var t = child.gameObject.GetComponent<TankController>();
                if(t == null) continue;
                t.Initialize(this);
                _tanks.Add(t);
            }
        }
    }
}