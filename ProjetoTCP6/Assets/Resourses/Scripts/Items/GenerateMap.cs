using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : ItemCollectCallback
{
    [SerializeField] GameObject mapPrefab;
    public override void Collected()
    {
        Instantiate(mapPrefab);
    }
}
