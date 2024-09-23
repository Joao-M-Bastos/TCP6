using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    Image lifeBarImage;
    [SerializeField] Sprite[] lifeSprites;
    // Start is called before the first frame update

    private void Awake()
    {
        lifeBarImage = GetComponent<Image>();
        
    }

    public void OnDisable()
    {
        PlayerScpt.onPlayerUpdateLife -= UpdateLifeBar;
    }

    public void OnEnable()
    {
        PlayerScpt.onPlayerUpdateLife += UpdateLifeBar;
    }

    public void UpdateLifeBar()
    {
        if( GameObject.FindGameObjectWithTag("Player") == null)
        {
            SetSprite(0);
            return;
        }
        else
        {
            int playerCurrentLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScpt>().CurrentLife;

            if (playerCurrentLife < 0)
                SetSprite(0);
            
            else if (playerCurrentLife > 5)
                SetSprite(5);
            else SetSprite(playerCurrentLife);
        }
    }

    public void SetSprite(int spriteID)
    {
        lifeBarImage.sprite = lifeSprites[spriteID];
    }
}
