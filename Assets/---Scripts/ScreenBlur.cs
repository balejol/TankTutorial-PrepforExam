using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenBlur : MonoBehaviour
{
    //private PlayerController playerController;
    //private DepthOfField depthOfField;

    //private bool currentPlayerControllerState;

    //private DepthOfFieldMode initialMode;
    //private float initialGaussianStart;
    //private float initialGaussianEnd;

    //private void Awake()
    //{
    //    playerController = GetComponent<PlayerController>();
    //    if (playerController == null)
    //    {
    //        Debug.LogError("Could not find PlayerController component", this);
    //        enabled = false;
    //        return;
    //    }

    //    currentPlayerControllerState = playerController.enabled;

    //    depthOfField = GetDepthOfField();
    //    if (depthOfField == null)
    //    {
    //        Debug.LogError("Could not find DepthOfField effect", this);
    //        enabled = false;
    //        return;
    //    }

    //    initialMode = depthOfField.mode.value;
    //    initialGaussianStart = depthOfField.gaussianStart.value;
    //    initialGaussianEnd = depthOfField.gaussianEnd.value;
    //}

    //private DepthOfField GetDepthOfField()
    //{
    //    var volume = FindObjectOfType<Volume>();
    //    if (volume == null)
    //    {
    //        return null;
    //    }

    //    volume.profile.TryGet(out DepthOfField depthOfField);
    //    return depthOfField;
    //}

    //private bool IsPlayerControllerStateChanged()
    //{
    //    return currentPlayerControllerState != playerController.enabled;
    //}

    //private void UpdateDepthOfField()
    //{
    //    if (playerController.enabled)
    //    {
    //        RestoreDepthOfField();
    //    }
    //    else
    //    {
    //        BlurDepthOfField();
    //    }
    //}

    //private void RestoreDepthOfField()
    //{
    //    depthOfField.mode.value = initialMode;
    //    depthOfField.gaussianStart.value = initialGaussianStart;
    //    depthOfField.gaussianEnd.value = initialGaussianEnd;
    //}

    //private void BlurDepthOfField()
    //{
    //    depthOfField.mode.value = DepthOfFieldMode.Gaussian;
    //    depthOfField.gaussianStart.value = 0f;
    //    depthOfField.gaussianEnd.value = 5f;
    //}

    //private void UpdateCurrentPlayerControllerState()
    //{
    //    currentPlayerControllerState = playerController.enabled;
    //}

    //private void Update()
    //{
    //    if (IsPlayerControllerStateChanged())
    //    {
    //        UpdateDepthOfField();
    //        UpdateCurrentPlayerControllerState();
    //    }
    //}
}
