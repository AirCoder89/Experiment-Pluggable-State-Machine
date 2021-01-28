using UnityEngine;

namespace Extensions
{
    public static class LayerMaskExtensions
    {
        public static bool CompareLayer(this LayerMask layer1, LayerMask other)
        {
            return (layer1.value & 1 << other) == 1 << other;
        }
    }
}
