using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScpt : MonoBehaviour
{
    #region Values

    [SerializeField] int acelleration, maxSpeed;
    [SerializeField] int baseLife, currentLife;
    [SerializeField] float dashCooldown;
    float currentDash;

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

    public void TakeAHit(int value)
    {
        currentLife -= value;
    }

    public void DeactivateWeapon()
    {
        rightHand.DeactivateWeapon();
    }

    public void ActivateWeaponCollider()
    {
        rightHand.ActivateWeaponCollider();
    }

    public void DeactivateWeaponCollider()
    {
        rightHand.DeactivateWeaponCollider();
    }

    public bool CanDash()
    {
        if (currentDash >= 0)
            currentDash -= Time.deltaTime;

        return currentDash <= 0;
    }

    public void ResetDashTime()
    {
        currentDash = dashCooldown;
    }
}
