using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform playerTranform;
    // Start is called before the first frame update
    void Start()
    {
        playerTranform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position =  playerTranform.position;

        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
