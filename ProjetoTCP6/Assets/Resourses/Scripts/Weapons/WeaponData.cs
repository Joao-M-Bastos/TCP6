using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory System/Weapon")]
public class WeaponData : ScriptableObject
{
    public int ID;
    public string weaponName;
    public int damage;
    public string animToTrigger;
    public GameObject weaponPrefab;
}
