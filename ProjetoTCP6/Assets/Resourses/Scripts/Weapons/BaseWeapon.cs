using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected float baseCooldown;
    [SerializeField] int baseDamage, baseSize;
    [SerializeField] GameObject boxCollider;
    protected float cooldownReductionPercentage = 100, currentCooldown;
    int size;
    float currentSize;
    Transform boxStartPoint;

    public void SetSwordStatus(Transform _raycastStartPoint)
    {
        boxStartPoint = _raycastStartPoint;
    }

    public void ReduceTimer()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime * (cooldownReductionPercentage / 100);
        }
    }

    public abstract void ActivateSword();

    public void ActivateCollider()
    {
        currentSize = size;

        Vector3 trueStartPoint = boxStartPoint.transform.position + boxStartPoint.transform.forward * (size / 2);

        GameObject currentBox = Instantiate(boxCollider, boxStartPoint.transform);
        currentBox.transform.position = trueStartPoint;
        currentBox.GetComponent<DamageCollider>().SetCollider(0.5f, baseDamage);

        currentCooldown = baseCooldown;
    }

    public abstract void SpecialEffect();

    public abstract void HitOtherCallback();

    public abstract void UpdateFrame();
}
