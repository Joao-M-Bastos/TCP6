using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    float shakeIntesity = 2f;
    float shakeTime = 0.2f;

    float timer;
    CinemachineBasicMultiChannelPerlin channelPerlin;


    private void OnEnable()
    {
        PlayerScpt.playerTookeDamage += ShakeCamera;
    }

    private void OnDisable()
    {
        PlayerScpt.playerTookeDamage -= ShakeCamera;
    }

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera()
    {
        channelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        channelPerlin.m_AmplitudeGain = shakeIntesity;
        timer = shakeTime;
    }

    public void StopShake()
    {
        channelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        channelPerlin.m_AmplitudeGain = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
            timer -= Time.deltaTime;
        else
            StopShake();
    }
}
