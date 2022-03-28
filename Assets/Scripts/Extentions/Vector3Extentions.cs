using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtensionMethods
{
    public static class Vector3Extentions
    {
        public static Vector3 Clamp(this Vector3 v, float min, float max)
        {
            return Clamp(v, min, max, min, max, min, max);
        }

        public static Vector3 Clamp(this Vector3 v, float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
        {
            return new Vector3(Mathf.Clamp(v.x, minX, maxX),
                               Mathf.Clamp(v.y, minY, maxY),
                               Mathf.Clamp(v.z, minZ, maxZ));

        }

        public static Vector3 RoundToNearestMultiple(this Vector3 v, float factor)
        {
            return RoundToNearestMultiple(v, factor, factor, factor);
        }

        public static Vector3 RoundToNearestMultiple(this Vector3 v, float factorX, float factorY, float factorZ)
        {
            return new Vector3(v.x.RoundToNearestMultiple(factorX), 
                               v.y.RoundToNearestMultiple(factorY),
                               v.z.RoundToNearestMultiple(factorZ));

        }
    }

    public static class FloatExtentions
    {
        public static float RoundToNearestMultiple(this float f, float factor)
        {
            if (factor == 0f) return 0f;

            return Mathf.Round(f / factor) * factor;
        }
    }
}