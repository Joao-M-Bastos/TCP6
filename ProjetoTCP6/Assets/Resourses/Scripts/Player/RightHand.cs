using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    [SerializeField] Transform boxStartPoint;
    [SerializeField] BaseWeapon currentWeapon;

    GameObject currentWeaponObj;

    // Start is called before the first frame update
    void Start()
    {
        SetSword(0);
    }

    public void SetSword(int id, string name = "")
    {
        if(currentWeaponObj != null)
            Destroy(currentWeaponObj);

        if (id >= 0)
            currentWeapon = ListOfItems.GetSwordById(0).GetComponent<BaseWeapon>();
        else
            currentWeapon = ListOfItems.GetSwordByName(name).GetComponent<BaseWeapon>();

        SetNewStatus();

        currentWeaponObj = Instantiate(currentWeapon.gameObject, this.transform);
    }

    private void SetNewStatus()
    {
        currentWeapon.SetSwordStatus(boxStartPoint);
    }

    public void ActivateSword()
    {
        currentWeapon.ActivateSword();
    }


}
