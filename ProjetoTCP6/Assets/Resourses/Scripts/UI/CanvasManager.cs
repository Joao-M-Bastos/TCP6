using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CanvasStates{
    InGame,
    Paused,
    Inventory
}

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject InGameCanvas, PausedCanvas, InventoryCanvas;

    CanvasStates currentState;

    private void Start()
    {
        ChangeCanvas(CanvasStates.InGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (currentState != CanvasStates.InGame)
                ChangeCanvas(CanvasStates.InGame);
            else ChangeCanvas(CanvasStates.Paused);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (currentState == CanvasStates.Inventory)
                ChangeCanvas(CanvasStates.InGame);
            else ChangeCanvas(CanvasStates.Inventory);
        }
    }

    public void ChangeCanvas(CanvasStates state)
    {
        currentState = state;

        InGameCanvas.SetActive(currentState == CanvasStates.InGame || currentState == CanvasStates.Paused || currentState == CanvasStates.Inventory);

        PausedCanvas.SetActive(currentState == CanvasStates.Paused);

        InventoryCanvas.SetActive(currentState == CanvasStates.Inventory);
    }
}
