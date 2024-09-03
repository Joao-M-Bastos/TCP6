using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestuction : MonoBehaviour
{
    ParticleSystem particuleSistem;

    float duration;
    private void Awake()
    {
        particuleSistem = GetComponentInChildren<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        duration = particuleSistem.main.duration + particuleSistem.main.startLifetimeMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if(duration <= 0)
            Destroy(gameObject);
        duration -= Time.deltaTime;
    }
}
