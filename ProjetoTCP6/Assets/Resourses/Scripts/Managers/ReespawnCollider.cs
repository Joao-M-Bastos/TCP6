using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReespawnCollider : MonoBehaviour
{
    [SerializeField] ReespawnManager reespawnManager;

    private void Awake()
    {
        reespawnManager = gameObject.GetComponentInParent<ReespawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            reespawnManager.SetPosition(this.transform.position);
        
    }
}
