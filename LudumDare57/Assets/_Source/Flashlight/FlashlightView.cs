using Cinemachine;
using EnemySystem;
using MovementSystem;
using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace FlashlightSystem
{
    public class FlashlightView : MonoBehaviour
    {
        [SerializeField] private Light2D radiusLight;
        [SerializeField] private Light2D coneLight;
        [SerializeField] private Transform aimTarget;

        [Space]
        [SerializeField] private FlashlightMode[] flashlightModes = new FlashlightMode[1];
        [SerializeField] private int defaultModeIndex;

        [Space]
        [SerializeField] private CinemachineVirtualCamera switchedOffVirtualCamera;
        [SerializeField] private float switchedOffPerceptionDistance;

        [Space]
        [SerializeField] private PercievedObject percievedObject;

        public int CurrentModeIndex { get; private set; }
        public int LastModeIndex { get { return flashlightModes.Length - 1; } }

        private CinemachineVirtualCamera _currentVirtualCamera;

        private void Start()
        {
            _currentVirtualCamera = switchedOffVirtualCamera;
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
                    radiusLight.enabled = false;
                    coneLight.enabled = false;

                    _currentVirtualCamera.enabled = false;
                    _currentVirtualCamera = switchedOffVirtualCamera;
                    _currentVirtualCamera.enabled = true;

                    aimTarget.localPosition = new(aimTarget.localPosition.x, -0.719f, 0f);

                    percievedObject.Distance = switchedOffPerceptionDistance;
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
            radiusLight.enabled = true;
            coneLight.enabled = true;

            _currentVirtualCamera.enabled = false;
            _currentVirtualCamera = mode.VirtualCamera;
            _currentVirtualCamera.enabled = true;

            radiusLight.pointLightOuterRadius = mode.RadiusLightOuterRadius;
            radiusLight.pointLightInnerRadius = mode.RadiusLightInnerRadius;
            radiusLight.falloffIntensity = mode.RadiusLightFalloffStrength;

            coneLight.pointLightOuterRadius = mode.ConeLightOuterRadius;
            coneLight.pointLightInnerRadius = mode.ConeLightInnerRadius;
            coneLight.pointLightInnerAngle = mode.ConeLightInnerAngle;
            coneLight.pointLightOuterAngle = mode.ConeLightOuterAngle;
            coneLight.falloffIntensity = mode.ConeLightFalloffStrength;

            aimTarget.localPosition = new(aimTarget.localPosition.x, mode.AimDistance, 0f);

            percievedObject.Distance = mode.PerceptionDistance;
        }

        [Serializable]
        private struct FlashlightMode
        {
            [SerializeField] private float radiusLightInnerRadius;
            [SerializeField] private float radiusLightOuterRadius;
            [SerializeField, Range(0f, 1.0f)] private float radiusLightFalloffStrength;

            [Space]
            [SerializeField] private float coneLightInnerRadius;
            [SerializeField] private float coneLightOuterRadius;
            [SerializeField, Range(0f, 360.0f)] private float coneLightInnerAngle;
            [SerializeField, Range(0f, 360.0f)] private float coneLightOuterAngle;
            [SerializeField, Range(0f, 1.0f)] private float coneLightFalloffStrength;

            [Space]
            [SerializeField] private CinemachineVirtualCamera virtualCamera;
            [SerializeField] private float aimDistance;

            [Space]
            [SerializeField] private float perceptionDistance;

            public readonly float RadiusLightInnerRadius { get { return radiusLightInnerRadius; } }
            public readonly float RadiusLightOuterRadius { get { return radiusLightOuterRadius; } }
            public readonly float RadiusLightFalloffStrength { get { return radiusLightFalloffStrength; } }

            public readonly float ConeLightInnerRadius {  get { return coneLightInnerRadius; } }
            public readonly float ConeLightOuterRadius {  get { return coneLightOuterRadius; } }
            public readonly float ConeLightInnerAngle {  get { return coneLightInnerAngle; } }
            public readonly float ConeLightOuterAngle {  get { return coneLightOuterAngle; } }
            public readonly float ConeLightFalloffStrength {  get { return coneLightFalloffStrength; } }

            public readonly CinemachineVirtualCamera VirtualCamera { get { return virtualCamera; } }
            public readonly float AimDistance { get { return aimDistance; } }

            public readonly float PerceptionDistance { get { return perceptionDistance; } }
        }
    }
}
