using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected float baseCooldown;
    [SerializeField] protected int baseDamage, baseSize;

    LayerMask hitableMask;

    protected float cooldownReductionPercentage = 100, currentCooldown;
    protected float currentSize;
    protected Transform boxStartPoint;

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
        currentSize = baseSize;

        Vector3 currentVectorSize = new Vector3(currentSize, currentSize,currentSize);

        Vector3 trueStartPoint = boxStartPoint.transform.position + boxStartPoint.transform.forward;

        
        if (Physics.BoxCast(trueStartPoint, currentVectorSize, boxStartPoint.transform.forward,out RaycastHit hitInfo, Quaternion.identity,currentSize ,hitableMask))
        {

            Debug.Log(hitInfo.collider.name);
        }

        currentCooldown = baseCooldown;
    }

    private void OnDrawGizmos()
    {
        Vector3 currentVectorSize = new Vector3(currentSize, currentSize, currentSize);

        Debug.Log(boxStartPoint);

        if (boxStartPoint == null)
            return;

        Vector3 trueStartPoint = boxStartPoint.transform.position + boxStartPoint.transform.forward;
        Gizmos.DrawCube(trueStartPoint, currentVectorSize);
    }

    public abstract void SpecialEffect();

    public abstract void HitOtherCallback();

    public abstract void UpdateFrame();
}
