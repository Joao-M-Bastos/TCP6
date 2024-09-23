using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorpseEnemy : BaseEnemy
{
    [SerializeField] EnemyData enemyToSpawn;
    protected float currentCooldown;

    [SerializeField] protected SkinnedMeshRenderer[] skinnedRenderer;


    private void Start()
    {
        life = enemyData.life;
        currentCooldown = enemyData.baseAttackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        RemoveImmunityTime();
        currentCooldown -= Time.deltaTime;
        if(currentCooldown < 0)
        {
            Instantiate(enemyToSpawn.enemyPrefab, this.transform.position + transform.up, enemyToSpawn.enemyPrefab.transform.rotation);
            Destroy(gameObject);
        }
    }

    protected void FlashRender()
    {
        foreach (SkinnedMeshRenderer r in skinnedRenderer)
        {
            r.material.color = Color.red;
        }

        Invoke("UnFlashRender", 0.4f);
    }

    protected void UnFlashRender()
    {
        foreach (SkinnedMeshRenderer r in skinnedRenderer)
        {
            r.material.color = Color.white;
        }
    }

    public override void OnDie()
    {
        PlayParticuleOnDeath();
        DropItemOnDeath();
    }

    public override void OnTakeDamage()
    {
        FlashRender();
    }

    public override void Attack()
    {

    }
}
