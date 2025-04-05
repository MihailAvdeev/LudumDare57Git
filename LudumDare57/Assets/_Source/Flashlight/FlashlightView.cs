using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FlashlightSystem
{
    public class FlashlightView : MonoBehaviour
    {
        [SerializeField] private Light2D radiusLight;
        [SerializeField] private Light2D coneLight;

        [Space]
        [SerializeField] private FlashlightMode switchedOffMode;
        [SerializeField] private FlashlightMode[] flashlightModes = new FlashlightMode[1];
        [SerializeField] private int defaultModeIndex;

        public int CurrentModeIndex { get; private set; }
        public int LastModeIndex { get { return flashlightModes.Length - 1; } }

        private void Start()
        {
            SwitchFlashlightMode(defaultModeIndex);
        }

        public void SwitchFlashlightMode(int index)
        {
            if (index < -1 || index >= flashlightModes.Length)
            {
                return;
            }
            else
            {
                if (index == -1)
                {
                    SetFlashlightMode(switchedOffMode);
                }
                else
                {
                    SetFlashlightMode(flashlightModes[index]);
                }

                CurrentModeIndex = index;
            }
        }

        private void SetFlashlightMode(FlashlightMode mode)
        {
            radiusLight.falloffIntensity = mode.RadiusLightFalloffStrength;
            radiusLight.pointLightOuterRadius = mode.RadiusLightOuterRadius;

            coneLight.enabled = mode.ConeLightEnabled;
            coneLight.pointLightOuterRadius = mode.ConeLightOuterRadius;
            coneLight.pointLightInnerAngle = mode.ConeLightInnerAngle;
            coneLight.pointLightOuterAngle = mode.ConeLightOuterAngle;
            coneLight.falloffIntensity = mode.ConeLightFalloffStrength;
        }

        [Serializable]
        private struct FlashlightMode
        {
            [SerializeField] private float radiusLightOuterRadius;
            [SerializeField, Range(0f, 1.0f)] private float radiusLightFalloffStrength;

            [Space]
            [SerializeField] private bool coneLightEnabled;
            [SerializeField] private float coneLightOuterRadius;
            [SerializeField, Range(0f, 360.0f)] private float coneLightInnerAngle;
            [SerializeField, Range(0f, 360.0f)] private float coneLightOuterAngle;
            [SerializeField, Range(0f, 1.0f)] private float coneLightFalloffStrength;

            public readonly float RadiusLightOuterRadius { get { return radiusLightOuterRadius; } }
            public readonly float RadiusLightFalloffStrength { get { return radiusLightFalloffStrength; } }

            public readonly bool ConeLightEnabled { get { return coneLightEnabled; } }
            public readonly float ConeLightOuterRadius {  get { return coneLightOuterRadius; } }
            public readonly float ConeLightInnerAngle {  get { return coneLightInnerAngle; } }
            public readonly float ConeLightOuterAngle {  get { return coneLightOuterAngle; } }
            public readonly float ConeLightFalloffStrength {  get { return coneLightFalloffStrength; } }

        }
    }
}
