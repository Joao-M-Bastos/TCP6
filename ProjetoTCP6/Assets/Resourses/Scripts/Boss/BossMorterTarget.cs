using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMorterTarget : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPoint;

    [SerializeField] EnemyData[] trashToGenerate;

    float bulletSpeed;
    int damage;
    bool projectileAlreadyInstacieted;

    GameObject spitProjectile;
    // Start is called before the first frame update
    public void Inicialize(float bulletSpeed, int damage)
    {
        this.bulletSpeed = bulletSpeed;
        this.damage = damage;

        StartCoroutine(InstancietaProjectile());
    }

    public IEnumerator InstancietaProjectile()
    {
        yield return new WaitForSeconds(1f);

        projectileAlreadyInstacieted = true;
        spitProjectile = Instantiate(projectile, spawnPoint);
        spitProjectile.GetComponent<SpitProjectile>().Inicialize(bulletSpeed, damage);
    }

    private void Update()
    {
        if(projectileAlreadyInstacieted && spitProjectile == null)
        {
            EnemyData corpse = trashToGenerate[Random.Range(0, trashToGenerate.Length)];
            Instantiate(corpse.enemyPrefab, this.transform.position, corpse.enemyPrefab.transform.rotation);
            Destroy(gameObject);
        }
    }
}
