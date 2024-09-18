using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAim : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public Transform PlayerTransform => player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        Vector3 position = player.transform.position;
        position.y = 0.5f;

        transform.LookAt(position);
    }
}
