using UnityEngine;

namespace Core
{
    public abstract class AppSystem : MonoBehaviour
    {
        protected Controller _controller;
        public abstract void Initialize(Controller controller);
        public virtual void Tick(){}
    }
}