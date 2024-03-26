using System;
using UnityEngine;

namespace Utility
{
    [Serializable]
    public static class Destroyer
    {
        public static void Destroy(GameObject gameObject)
        {
            GameObject.Destroy(gameObject);
        }

        public static void Destroy(GameObject[] gameObjects)
        {
            for (int i = 0; i < gameObjects.Length; i++)
                GameObject.Destroy(gameObjects[i]);
        }
    }
}

