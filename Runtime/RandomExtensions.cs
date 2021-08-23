using System.Collections.Generic;
using UnityEngine;

namespace Plugins.Extensions
{
    public static class RandomExtensions
    {
        public static T Random<T>(this IList<T> objects, int maxI = -1, int minI = 0) where T : class
        {
            Debug.Assert(objects != null, "objects != null");

            if (objects.Count == 0)
            {
                return null;
            }

            var rand = UnityEngine.Random.Range(minI, maxI == -1 ? objects.Count : maxI);
            return objects[rand];
        }


        public static bool Random<T>(this IList<T> list, out T value) where T : struct
        {
            Debug.Assert(list != null, "list != null");

            value = default(T);

            if (list.Count == 0)
            {
                return false;
            }

            var rand = UnityEngine.Random.Range(0, list.Count);
            value = list[rand];
            return true;
        }

        public static float Random(this Vector4 minMax, int XYOrZW = 0)
        {
            if (XYOrZW == 0) return UnityEngine.Random.Range(minMax.x, minMax.y);

            return UnityEngine.Random.Range(minMax.z, minMax.w);
        }

        public static float Random(this Vector2 minMax)
        {
            return UnityEngine.Random.Range(minMax.x, minMax.y);
        }

        public static AudioClip Random(this AudioClip[] clips)
        {
            if (clips == null) return null;
            if (clips.Length == 0) return null;

            return clips[UnityEngine.Random.Range(0, clips.Length)];
        }
    }
}