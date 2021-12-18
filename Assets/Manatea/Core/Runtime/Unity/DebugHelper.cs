using UnityEditor;
using UnityEngine;

namespace Manatea
{
    public static class DebugHelper
    {
        public static void DrawWireCircle(Vector3 position, float radius, int iterations = 32)
            => DrawWireCircle(position, radius, Vector3.forward, Color.white, 0, true, iterations);
        public static void DrawWireCircle(Vector3 position, float radius, Vector3 normal, Color color, float duration = 0.0f, bool depthTest = true, int iterations = 32)
        {
            Vector3 tangent = Vector3.Cross(normal, Vector3.up);
            if (tangent == Vector3.zero)
                tangent = Vector3.Cross(normal, Vector3.right);
            if (tangent == Vector3.zero)
                tangent = Vector3.Cross(normal, Vector3.forward);

            Vector3 lastPos = position + tangent * radius;
            for (int i = 1; i <= iterations; i++)
            {
                Vector3 newPos = position + Quaternion.AngleAxis(i / (float)iterations * 360, normal) * tangent * radius;
                Debug.DrawLine(lastPos, newPos, color, duration, depthTest);
                lastPos = newPos;
            }
        }
    }
}