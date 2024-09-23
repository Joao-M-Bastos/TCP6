using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAwaker : MonoBehaviour
{
    [SerializeField] BossBehaviour boss;
    [SerializeField] GameObject bossHealthBar;
    [SerializeField] bool awakeHim;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (awakeHim)
                boss.AwakeBoss();
            else
                boss.GoToSleep();

            bossHealthBar.SetActive(awakeHim);
        }
    }

}
