using Cinemachine;
using HidableUISystem;
using UnityEngine;

public class VirtualCameraHidableUI : AHidableUI
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public override void Hide()
    {
        virtualCamera.enabled = false;
    }

    public override void Show()
    {
        virtualCamera.enabled = true;
    }
}
