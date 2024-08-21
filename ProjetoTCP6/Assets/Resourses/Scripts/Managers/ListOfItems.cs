using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfItems : MonoBehaviour
{
    [SerializeField] GameObject[] nonStaticPrimaryEquip;
    private static GameObject[] primaryEquipList;

    [SerializeField] GameObject[] nonStaticItem;
    private static GameObject[] itemList;

    

    private void Awake()
    {
        primaryEquipList = nonStaticPrimaryEquip;

        itemList = nonStaticItem;
    }



    #region Get Sword
    public static GameObject GetSwordByName(string swordName)
    {
        foreach (GameObject go in primaryEquipList)
        {
            if (go.name == swordName)
                return go;
        }

        return primaryEquipList[0];
    }

    public static GameObject GetSwordById(int id)
    {
        return primaryEquipList[id];
    }

    #endregion

    #region Item
    public static GameObject GetItemByName(string itemName)
    {
        foreach (GameObject go in itemList)
        {
            if (go.name == itemName)
                return go;
        }

        return itemList[0];
    }

    public static GameObject GetItemById(int id)
    {
        return itemList[id];
    }
    #endregion
}
