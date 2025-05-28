using System.Collections.Generic;
using UnityEngine;

namespace CountDisplayerSystem
{
    public class MBEnablerCountDisplayer : AMBCountDisplayer
    {
        [SerializeField] private List<GameObject> gameObjects = new();

        public override void DisplayCount(int count)
        {
            if (count < 0)
                count = 0;

            if (count > gameObjects.Count)
                count = gameObjects.Count;

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(false);
            }

            for (int i = 0; i < count; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
}
