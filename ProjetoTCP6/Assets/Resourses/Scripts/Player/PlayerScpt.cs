using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScpt : MonoBehaviour
{
    #region Values

    [SerializeField] int acelleration, maxSpeed;
    [SerializeField] int baseLife, currentLife;
    public int Aceleration => acelleration;
    public int MaxSpeed => maxSpeed;

    #endregion

    #region Instaces

    Rigidbody playerRB;
    RightHand rightHand;


    //Ponteiros
    public Rigidbody PlayerRB => playerRB;
    public RightHand RightHand => rightHand;

    #endregion

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        rightHand = GetComponentInChildren<RightHand>();
        currentLife = baseLife;
    }

    public void TakeAHit(int value)
    {
        currentLife -= value;
    }
}
