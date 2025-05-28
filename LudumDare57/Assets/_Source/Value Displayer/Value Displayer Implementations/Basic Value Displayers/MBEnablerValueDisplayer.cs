using System.Collections.Generic;
using UnityEngine;

namespace ValueDisplayerSystem
{
    public class MBEnablerValueDisplayer : AMBValueDisplayer
    {
        [SerializeField] private RoundMode roundMode = RoundMode.closest;

        [Space]
        [SerializeField] private List<GameObject> gameObjects = new();

        public override void DisplayValue(float value)
        {
            if (roundMode == RoundMode.floor)
            {
                value = Mathf.Floor(value);
            }
            else if (roundMode == RoundMode.ceiling)
            {
                value = Mathf.Ceil(value);
            }
            else
            {
                value = Mathf.Round(value);
            }

            int count = (int)value;

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

        private enum RoundMode
        {
            closest,
            floor,
            ceiling
        }
    }
}
