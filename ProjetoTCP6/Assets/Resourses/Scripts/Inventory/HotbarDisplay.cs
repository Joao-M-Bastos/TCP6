using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarDisplay : StaticInventoryDisplay
{
    private int maxIndexSize = 5;
    private int currentIndexSize = 0;

    private PlayerControl playerControls;

    private void Awake()
    {
        playerControls = new PlayerControl();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentIndexSize = 0;
        maxIndexSize = slots.Length - 1;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        playerControls.Enable();
        /*
        playerControls.Player.Hotbar1.performed += Hotbar1;
        playerControls.Player.Hotbar2.performed += Hotbar2;
        playerControls.Player.Hotbar3.performed += Hotbar3;
        playerControls.Player.Hotbar4.performed += Hotbar4;
        playerControls.Player.Hotbar5.performed += Hotbar5;

        playerControls.Player.UseItem.performed += UseItem;
        */
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
