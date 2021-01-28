using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Controller : MonoBehaviour
    {
        public static Controller Instance;
        public List<AppSystem> systems;
        public string poolName;

        private void Awake()
        {
            if(Instance != null) return;
            Instance = this;
        }

        private void Start()
        {
            foreach (var appSystem in systems)
                appSystem.Initialize(this);

            StartCoroutine(InternalTick());
        }

        private IEnumerator InternalTick()
        {
            while (true)
            {
                foreach (var appSystem in systems)
                    appSystem.Tick();
                yield return null;
            }
        }
    }
}