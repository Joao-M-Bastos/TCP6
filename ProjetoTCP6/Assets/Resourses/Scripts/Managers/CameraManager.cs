using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera starterCamera;
    private CinemachineVirtualCamera currentCamera;

    private void Start()
    {
        SwichCamera(starterCamera);
    }

    public void SwichCamera(int newCameraID)
    {
        currentCamera = cameras[newCameraID];

        foreach (var cam in cameras)
        {
            cam.Priority = 10;

            if (cam == currentCamera)
                cam.Priority = 20;
        }
    }

    public void SwichCamera(CinemachineVirtualCamera newCamera)
    {
        currentCamera = newCamera;

        foreach (var cam in cameras)
        {
            cam.Priority = 10;

            if (cam == currentCamera)
                cam.Priority = 20;
        }
    }
}
