using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScpt : MonoBehaviour
{
    #region Values

    [SerializeField] int speed;

    #endregion

    #region Instaces

    Rigidbody playerRB;


    //Ponteiros
    public Rigidbody PlayerRB => playerRB;

    #endregion

    

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}