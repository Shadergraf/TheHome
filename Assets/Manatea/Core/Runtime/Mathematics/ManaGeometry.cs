using UnityEngine;

namespace Manatea
{
    public static class ManaGeometry
    {
        /// <summary> Determines if the given point is inside a polygon. </summary>
        /// <param name="polygon"> The vertices of the polygon. </param>
        /// <param name="testPoint"> The point to test<. /param>
        /// <returns> Returns true if the point is inside the polygon, false otherwise. </returns>
        public static bool IsPointInPolygon(Vector2[] polygon, Vector2 testPoint)
        {
            bool result = false;
            int j = polygon.Length - 1;
            for (int i = 0; i < polygon.Length; i++)
            {
                if (polygon[i].y < testPoint.y && polygon[j].y >= testPoint.y || polygon[j].y < testPoint.y && polygon[i].y >= testPoint.y)
                {
                    if (polygon[i].x + (testPoint.y - polygon[i].y) / (polygon[j].y - polygon[i].y) * (polygon[j].x - polygon[i].x) < testPoint.x)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }


        /// <summary> Calculates the AABB of a Polygon. </summary>
        /// <param name="polygon"> The polygon whose verticies to test. </param>
        /// <returns> Returns the bounds that encapsulate all points. </returns>
        public static Bounds GetPolygonBounds(Vector2[] polygon)
        {
            Vector2 min = ManaMath.Min(polygon);
            Vector2 max = ManaMath.Max(polygon);
            return new Bounds((min + max) / 2, max - min);
        }
    }
}