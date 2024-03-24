using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] float baseCooldown;
    [SerializeField] int baseSize;
    [SerializeField] GameObject boxCollider;
    float cooldownReductionPercentage = 100, currentCooldown;
    int size;
    float currentSize;
    Transform boxStartPoint;

    public void SetSwordStatus(Transform _raycastStartPoint)
    {
        boxStartPoint = _raycastStartPoint;
    }

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime * (cooldownReductionPercentage / 100);
        }
    }
    public void ActivateSword()
    {
        if (currentCooldown > 0)
        {
            return;
        }
        currentSize = size;

        Vector3 trueStartPoint = boxStartPoint.transform.position + boxStartPoint.transform.forward * (size / 2);

        GameObject currentBox = Instantiate(boxCollider, boxStartPoint.transform);
        currentBox.transform.position = trueStartPoint;
        currentBox.GetComponent<DamageCollider>().SetCooldown(0.2f);
        currentCooldown = baseCooldown;
    }

    public abstract void SpecialEffect();

    public abstract void HitOtherCallback();
}
