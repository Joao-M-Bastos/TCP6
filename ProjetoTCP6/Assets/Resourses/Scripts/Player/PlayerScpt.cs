using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PlayerScpt;

public class PlayerScpt : MonoBehaviour
{
    public delegate void OnPlayerDeath();
    public static OnPlayerDeath onPlayerDie;

    public delegate void OnPlayerUpdateLife();
    public static OnPlayerUpdateLife onPlayerUpdateLife;

    public delegate void PlayerTookeDamage();
    public static PlayerTookeDamage playerTookeDamage;

    #region Values

    [SerializeField] int acelleration, maxSpeed;
    [SerializeField] int baseLife, currentLife;
    [SerializeField] float dashCooldown;
    float currentDash;

    public int Aceleration => acelleration;
    public int MaxSpeed => maxSpeed;

    public int CurrentLife => currentLife;

    #endregion

    #region Instaces

    Rigidbody playerRB;
    RightHand rightHand;
    Animator animator;
    PlayerStateController playerStateController;
    [SerializeField] MeshRenderer[] renderers;
    [SerializeField] public AudioSource walkingSound;


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
        playerStateController = GetComponent<PlayerStateController>();
        currentLife = baseLife;
    }

    public void TakeAHit(int value, Vector3 direction)
    {
        currentLife -= value;
        playerTookeDamage?.Invoke();
        onPlayerUpdateLife?.Invoke();
        FlashRender();

        playerStateController.ChangeState(playerStateController.walkState);

        if (currentLife <= 0)
        {
            onPlayerDie?.Invoke();
            Destroy(gameObject);
        }
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

    protected void FlashRender()
    {
        foreach (MeshRenderer r in renderers)
        {
            r.material.color = Color.red;
        }

        Invoke("UnFlashRender", 0.4f);
    }

    protected void UnFlashRender()
    {
        foreach (MeshRenderer r in renderers)
        {
            r.material.color = Color.white;
        }
    }
}
