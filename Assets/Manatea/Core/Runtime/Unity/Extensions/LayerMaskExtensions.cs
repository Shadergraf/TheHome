
namespace UnityEngine
{
    public static class LayerMaskExtensions
    {
        public static LayerMask CalculatePhysicsLayerMask(int currentLayer)
        {
            int finalMask = 0;
            for (int i = 0; i < 32; i++)
            {
                if (!Physics.GetIgnoreLayerCollision(currentLayer, i)) 
                    finalMask |= 1 << i;
            }
            return finalMask;
        }
    }
}
