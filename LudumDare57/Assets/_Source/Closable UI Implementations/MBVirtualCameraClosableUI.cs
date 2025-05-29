using Cinemachine;
using ClosableUISystem;
using UnityEngine;

public class MBVirtualCameraClosableUI : AMBClosableUI
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public override void Open()
    {
        virtualCamera.enabled = true;
    }

    public override void Close()
    {
        virtualCamera.enabled = false;
    }
}
