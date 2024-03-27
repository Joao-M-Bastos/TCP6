using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfItems : MonoBehaviour
{
    [SerializeField] GameObject[] nonStaticPrimaryEquip;
    private static GameObject[] primaryEquip;

    private void Awake()
    {
        primaryEquip = nonStaticPrimaryEquip;
    }


    #region Get Sword
    public static GameObject GetSwordByName(string swordName)
    {
        foreach (GameObject go in primaryEquip)
        {
            if (go.name == swordName)
                return go;
        }

        return primaryEquip[0];
    }

    public static GameObject GetSwordById(int id)
    {
        return primaryEquip[id];
    }

    #endregion

}
