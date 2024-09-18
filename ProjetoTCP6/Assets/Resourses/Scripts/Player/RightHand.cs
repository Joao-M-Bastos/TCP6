using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    BaseWeapon currentWeapon;
    [SerializeField] WeaponDataBase weaponDataBase;

    GameObject currentWeaponObj;

    // Start is called before the first frame update
    void Awake()
    {
        SetSword(0);
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

    public bool IsWeaponActive()
    {
        return currentWeapon.isWeaponActive;
    }

    public void ActivateWeapon(Animator playerAnim)
    {
        currentWeapon.ActivateWeapon(playerAnim);
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
