using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    [SerializeField] Transform boxStartPoint;
    [SerializeField] BaseWeapon currentSword;
    // Start is called before the first frame update
    void Start()
    {

            SetSword(1);
    }

    public void SetSword(int id, string name = "")
    {
        SetNewStatus();

        Instantiate(currentSword.gameObject, this.transform);
    }

    private void SetNewStatus()
    {
        currentSword.SetSwordStatus(boxStartPoint);
    }

    public void ActivateSword()
    {
        currentSword.ActivateSword();
    }


}
