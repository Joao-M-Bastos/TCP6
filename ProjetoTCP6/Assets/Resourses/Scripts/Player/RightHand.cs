using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    BaseWeapon currentWeapon;
    [SerializeField] WeaponDataBase weaponDataBase;

    float extraDamage;

    GameObject currentWeaponObj;


    private void OnEnable()
    {
        BagInventoryDisplay.useGlass += GlassUsed;
    }

    private void OnDisable()
    {
        BagInventoryDisplay.useGlass -= GlassUsed;
    }

    // Start is called before the first frame update
    void Awake()
    {
        SetSword(0);
        extraDamage = 0;
    }

    public void GlassUsed()
    {
        extraDamage += 0.5f;
    }

    public void SetSword(int id)
    {
        if(currentWeaponObj != null)
            Destroy(currentWeaponObj);

        currentWeaponObj = Instantiate(weaponDataBase.GetWeapon(id).weaponPrefab, this.transform);
        currentWeapon = currentWeaponObj.GetComponent<BaseWeapon>();
    }

    public void SetSword(string name = "")
    {
        if (currentWeaponObj != null)
            Destroy(currentWeaponObj);

        currentWeaponObj = Instantiate(weaponDataBase.GetWeapon(name).weaponPrefab, this.transform);
        currentWeapon = currentWeaponObj.GetComponent<BaseWeapon>();
    }

    public void SetSword(WeaponData data)
    {
        if (currentWeaponObj != null)
            Destroy(currentWeaponObj);

        currentWeaponObj = Instantiate(data.weaponPrefab, this.transform);
        currentWeapon = currentWeaponObj.GetComponent<BaseWeapon>();
    }

    public bool IsWeaponActive()
    {
        return currentWeapon.isWeaponActive;
    }

    public void ActivateWeapon(Animator playerAnim)
    {
        currentWeapon.ActivateWeapon(playerAnim);
        currentWeapon.SetExtraDamage(extraDamage);
    }

    public void DeactivateWeapon()
    {
        currentWeapon.DeactivateWeapon();
    }

    public void ActivateWeaponCollider()
    {
        currentWeapon.ActivateCollider();
    }

    public void DeactivateWeaponCollider()
    {
        currentWeapon.DeactivateCollider();
    }
}
