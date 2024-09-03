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
    Animator animator;


    //Ponteiros
    public Rigidbody PlayerRB => playerRB;
    public RightHand RightHand => rightHand;
    public Animator Animator => animator;

    #endregion

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        rightHand = GetComponentInChildren<RightHand>();
        animator = GetComponent<Animator>();
        currentLife = baseLife;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Item itemCollided))
        {
            itemCollided.CollectItem();
        }
    }

    public void TakeAHit(int value)
    {
        currentLife -= value;
    }
}
