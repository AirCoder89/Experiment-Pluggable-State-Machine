using System;

namespace Core
{
    public interface IDestroyable
    {
        event Action<IDestroyable> onDestroy; 
        float health { get; }
        void ApplyDamage(float damage);
        void Remove();
    }
}