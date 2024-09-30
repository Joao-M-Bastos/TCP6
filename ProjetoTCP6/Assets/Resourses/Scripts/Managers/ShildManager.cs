using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildManager : MonoBehaviour
{
    public GameObject shildPrefab;
    GameObject[] currentShilds;

    private void Awake()
    {
        currentShilds = new GameObject[5];

        for (int i = 0; i < currentShilds.Length; i++)
        {
            currentShilds[i] = Instantiate(shildPrefab, transform);
            currentShilds[i].transform.position += Vector3.right * i;
            currentShilds[i].SetActive(false);
        }
    }

    public void OnDisable()
    {
        PlayerScpt.onPlayerUpdateLife -= UpdateShildIcons;
    }

    public void OnEnable()
    {
        PlayerScpt.onPlayerUpdateLife += UpdateShildIcons;
    }

    public void UpdateShildIcons()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            SetShild(0);
            return;
        }
        else
        {
            int playerCurrentShild = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScpt>().CurrentShild;

            if (playerCurrentShild <= 0)
                SetShild(0);
            else if (playerCurrentShild > 5)
                SetShild(5);
            else SetShild(playerCurrentShild);
        }
    }

    public void SetShild(int shildAmount)
    {

        for (int i = 0; i < currentShilds.Length; i++)
        {
            currentShilds[i].SetActive(false);
            

            if(shildAmount>i)
                currentShilds[i].SetActive(true);

        }
    }
}
