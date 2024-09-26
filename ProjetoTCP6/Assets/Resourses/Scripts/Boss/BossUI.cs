using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bossName;

    // Update is called once per frame
    void Update()
    {
        bossName.text = "Absolute Garbage | " + RecicleCounter.instance.RecicleCount;
    }
}
