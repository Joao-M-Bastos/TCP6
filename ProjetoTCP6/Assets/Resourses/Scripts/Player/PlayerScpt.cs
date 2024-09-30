using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PlayerScpt;

public class PlayerScpt : MonoBehaviour
{

    #region Delegates
    public delegate void OnPlayerDeath();
    public static OnPlayerDeath onPlayerDie;

    public delegate void OnPlayerUpdateLife();
    public static OnPlayerUpdateLife onPlayerUpdateLife;

    public delegate void PlayerTookeDamage();
    public static PlayerTookeDamage playerTookeDamage;
    #endregion

    #region Values

    [SerializeField] int acelleration;
    [SerializeField] float maxSpeed;
    float extraSpeed;
    [SerializeField] int baseLife, currentLife;
    int shild;
    [SerializeField] float dashCooldown;
    float currentDash;

    public int Aceleration => acelleration;
    public float MaxSpeed => maxSpeed + extraSpeed;

    public int CurrentLife => currentLife;

    public int CurrentShild => shild;

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


    #region Inicialize

    private void OnEnable()
    {
        BagInventoryDisplay.usePaper += PaperUsed;
        BagInventoryDisplay.usePlastic += PlasticUsed;
        BagInventoryDisplay.useMetal += MetalUsed;
    }

    private void OnDisable()
    {
        BagInventoryDisplay.usePaper -= PaperUsed;
        BagInventoryDisplay.usePlastic -= PlasticUsed;
        BagInventoryDisplay.useMetal -= MetalUsed;
    }

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        rightHand = GetComponentInChildren<RightHand>();
        animator = GetComponent<Animator>();
        playerStateController = GetComponent<PlayerStateController>();
        ResetValues();
    }

    public void ResetValues()
    {
        InicializePlayer();
        extraSpeed = 0;
        shild = 0;
    }

    public void InicializePlayer()
    {
        currentLife = baseLife;
        animator.SetBool("Dead", false);
        animator.ResetTrigger("GountletAttack");
        animator.ResetTrigger("SpearAttack");
        onPlayerUpdateLife?.Invoke();
    }
    #endregion

    #region BuffItems

    public void PaperUsed()
    {
        if (currentLife < baseLife)
        {
            currentLife++;
            onPlayerUpdateLife?.Invoke();
        }
    }

    public void PlasticUsed()
    {
        extraSpeed += 0.5f;
    }

    public void MetalUsed()
    {
        shild += 1;
        onPlayerUpdateLife?.Invoke();
    }
    
    #endregion

    #region Weapon
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

    #endregion

    #region Movement
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

    #endregion

    #region Damage

    public void TakeAHit(int value)
    {
        if (currentLife <= 0)
            return;

        if (shild > 0)
        {
            shild -= value;
            if (shild < 0)
                shild = 0;
        }
        else
            currentLife -= value;
        
        playerTookeDamage?.Invoke();
        onPlayerUpdateLife?.Invoke();

        FlashRender();

        if (currentLife <= 0)
        {
            onPlayerDie?.Invoke();
            playerStateController.ChangeState(playerStateController.damageState);
            animator.SetBool("Dead", true);
            Invoke("InicializePlayer",2f);
        }
    }

    public void TakeKnockBack(Vector3 hitPosition)
    {
        Vector3 direction = (transform.position - hitPosition).normalized;

        playerRB.AddForce(direction * 10, ForceMode.VelocityChange);
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
    #endregion
}
