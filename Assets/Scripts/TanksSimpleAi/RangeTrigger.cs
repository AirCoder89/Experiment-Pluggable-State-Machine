using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace TanksSimpleAi
{
    [System.Serializable]
    public class RangeEvent : UnityEvent<Transform>{}
    public class RangeTrigger : MonoBehaviour
    {
        public bool getNearest;
        public LayerMask targetLayer;
        
        [BoxGroup("Events")]public RangeEvent onDetect;
        [BoxGroup("Events")]public RangeEvent onLostDetection;
        
        private Transform _parent;
        private float _radius;
        public void Initialize(Transform parent)
        {
            _parent = parent;
            _radius = GetComponent<SphereCollider>().radius;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!targetLayer.CompareLayer(other.gameObject.layer)) return;
            if (getNearest)
            {
                var res = Physics.OverlapSphere(_parent.position, _radius, targetLayer);
                var target = GetNearest(res);
                if (target == null) return;
                onDetect?.Invoke(target);
            }
            else onDetect?.Invoke(other.transform);
        }

        private void OnTriggerExit(Collider other)
        {
           if (!targetLayer.CompareLayer(other.gameObject.layer)) return;
            onLostDetection?.Invoke(other.transform);
        }

        private Transform GetNearest(Collider[] colliders)
        {
            Transform nearestTarget = null;
            var closestDistance = Mathf.Infinity;
            foreach(var target in colliders)
            {
                var distance = Vector3.Distance(target.transform.position, _parent.position);
                if (!(distance < closestDistance)) continue;
                    closestDistance = distance;
                    nearestTarget = target.transform;
            }
            return nearestTarget;
        }
    }
}