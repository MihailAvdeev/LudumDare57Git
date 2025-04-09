using CoverSystem;
using FlashlightSystem;
using PerceptionSystem;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibility : APercievedObject, ICoverable
{
    [Space]
    [SerializeField] private Flashlight flashlight;
    [SerializeField] private float[] flashlightConfigurationvisibilities = new float[0];

    private readonly HashSet<Cover> _covers = new();
    private bool IsInCover { get { return _covers.Count > 0; } }
    private bool IsHidden { get { return IsInCover && flashlight.CurrentConfigurationIndex == -1; } }

    protected override float VisibilityDistance { get { return IsHidden ? 0 : TryGetFlashlightConfigurationVisibility(flashlight.CurrentConfigurationIndex); } }

    public void TakeCover(Cover cover)
    {
        _covers.Add(cover);
    }

    public void LeaveCover(Cover cover)
    {
        _covers.Remove(cover);
    }

    private float TryGetFlashlightConfigurationVisibility(int index)
    {
        if (index >= 0 && index < flashlightConfigurationvisibilities.Length)
            return flashlightConfigurationvisibilities[index];

        return 0;
    }
}
