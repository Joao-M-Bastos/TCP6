using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReespawnManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector3 reespawnPosition;

    private void OnEnable()
    {
        PlayerScpt.onPlayerDie += WaitToRealocatePlayer;
    }

    private void OnDisable()
    {
        PlayerScpt.onPlayerDie -= WaitToRealocatePlayer;
    }

    private void Start()
    {
        if (playerTransform == null)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if(playerTransform != null)
            reespawnPosition = playerTransform.position;
    }

    public void SetPosition(Vector3 newReespawnPoint)
    {
        reespawnPosition = newReespawnPoint;
    }

    public void WaitToRealocatePlayer()
    {
        Invoke("RealocatePlayer", 2f);
    }

    public void RealocatePlayer()
    {
        playerTransform.position = reespawnPosition;
    }
}
