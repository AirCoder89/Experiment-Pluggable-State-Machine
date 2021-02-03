using System;
using System.Collections.Generic;
using System.Linq;
using Addons.Utils.FastGizmosModule.Scripts;
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
        public bool drawGizmos;
        public bool getNearest;
        public LayerMask targetLayer;
        
        [BoxGroup("Events")]public RangeEvent onDetect;
        [BoxGroup("Events")]public RangeEvent onLostDetection;
        
        private Transform _parent;
        private float _radius;
        private List<Collider> _targets;
        private Transform _target;
        
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
                _target = GetNearest();
                if (_target == null) return;
                onDetect?.Invoke(_target);
            }
            else
            {
                _target = other.transform;
                onDetect?.Invoke(_target);
            }
        }

        private void OnTriggerExit(Collider other)
        {
           if (!targetLayer.CompareLayer(other.gameObject.layer)) return;
           _targets.Remove(other);
           if (other.transform == _target) _target = GetNearest();
            onLostDetection?.Invoke(other.transform);
        }

        private void OnDrawGizmos()
        {
            if(!drawGizmos) return;
            if (getNearest)
            {
                if(_targets == null || _targets.Count == 0 || _target == null) return;
                foreach (var t in _targets)
                {
                    if(t.transform == _target) Gizmos.color = Color.red;
                    else Gizmos.color = Color.gray;
                    Gizmos.DrawLine(transform.position, t.transform.position);
                }
            }
            else
            {
                if(_target == null) return;
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, _target.position);
            }
        }

        private Transform CalculateNearest(List<Collider> colliders)
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

        [Button("Get Nearest")]
        public Transform GetNearest()
        {
            _targets = Physics.OverlapSphere(_parent.position, _radius, targetLayer).ToList();
            var target = CalculateNearest(_targets);
            if (target == null)
            {
                print($"Nearest : is null");
                return null;
            }
            print($"Nearest : {target.gameObject.name}");
            return target;
        }
    }
}