using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace Manatea
{
    // Ref: https://www.iquilezles.org/www/articles/distfunctions2d/distfunctions2d.htm

    public static class SDF2
    {
        const MethodImplOptions INLINE = MethodImplOptions.AggressiveInlining;

        [MethodImpl(INLINE)]
        public static float Circle(Vector2 p, float r) => p.magnitude - r;

        [MethodImpl(INLINE)]
        public static float Box(Vector2 p, Vector2 b)
        {
            Vector2 d = ManaMath.Abs(p) - b;
            return ManaMath.Max(d, Vector2.zero).magnitude + ManaMath.Min(ManaMath.Max(d.x, d.y), 0.0f);
        }

        [MethodImpl(INLINE)]
        public static float Union(float d1, float d2)
        {
            return ManaMath.Min(d1, d2);
        }
        [MethodImpl(INLINE)]
        public static float Subtraction(float d1, float d2)
        {
            return ManaMath.Max(-d1, d2);
        }
        [MethodImpl(INLINE)]
        public static float Intersection(float d1, float d2)
        {
            return ManaMath.Max(d1, d2);
        }

        [MethodImpl(INLINE)]
        public static float SmoothUnion(float d1, float d2, float k)
        {
            float h = ManaMath.Max(k - ManaMath.Abs(d1 - d2), 0.0f);
            return ManaMath.Min(d1, d2) - h * h * 0.25f / k;
        }

        [MethodImpl(INLINE)]
        public static float SmoothSubtraction(float d1, float d2, float k)
        {
            float h = ManaMath.Max(k - ManaMath.Abs(-d1 - d2), 0.0f);
            return ManaMath.Max(-d1, d2) + h * h * 0.25f / k;
        }

        [MethodImpl(INLINE)]
        public static float SmoothIntersection(float d1, float d2, float k)
        {
            float h = ManaMath.Max(k - ManaMath.Abs(d1 - d2), 0.0f);
            return ManaMath.Max(d1, d2) + h * h * 0.25f / k;
        }
    }
}
