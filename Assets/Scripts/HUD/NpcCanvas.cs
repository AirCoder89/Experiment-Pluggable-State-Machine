using UnityEngine;

namespace HUD
{
    public class NpcCanvas : MonoBehaviour
    {
        [SerializeField] private Camera cameraToLookAt;
        private void Update()
        {
            var v = cameraToLookAt.transform.position - transform.position;
            v.x = v.z = 0.0f;
            transform.LookAt( cameraToLookAt.transform.position - v ); 
            transform.Rotate(0,180,0);
        }
    }
}
