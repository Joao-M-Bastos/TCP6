using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BossBehaviour;

public class BossGround : MonoBehaviour
{
    [SerializeField] Material cleanMaterial;
    private void OnEnable()
    {
        bossDeath += ChangeToCleanMaterial;
    }

    private void OnDisable()
    {
        bossDeath -= ChangeToCleanMaterial;
    }

    public void ChangeToCleanMaterial()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = cleanMaterial;
    }
}
