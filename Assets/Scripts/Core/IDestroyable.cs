using System;

namespace Core
{
    public interface IDestroyable
    {
        event Action<IDestroyable> onDestroy; 
        bool isAlive { get; }
        float health { get; }
        void ApplyDamage(float damage);
        void Remove();
    }
}