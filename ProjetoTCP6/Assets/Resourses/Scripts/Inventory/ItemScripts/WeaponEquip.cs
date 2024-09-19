using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class WeaponEquip : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20;
    [SerializeField] WeaponData weaponData;

    private SphereCollider myCollider;
    public float pickupRadius = 1;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
        myCollider.radius = pickupRadius;
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RightHand rightHand = other.GetComponent<PlayerScpt>().RightHand;

            rightHand.SetSword(weaponData);
            Destroy(gameObject);
        }
    }
}
