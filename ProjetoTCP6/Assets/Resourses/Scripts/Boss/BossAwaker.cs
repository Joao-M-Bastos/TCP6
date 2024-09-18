using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAwaker : MonoBehaviour
{
    [SerializeField] BossBehaviour boss;
    [SerializeField] bool awakeHim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (awakeHim)
                boss.AwakeBoss();
            else
                boss.GoToSLeed();

            
        }
    }

}
