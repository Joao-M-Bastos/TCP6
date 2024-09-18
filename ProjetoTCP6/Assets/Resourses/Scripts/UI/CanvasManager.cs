using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CanvasStates{
    InGame,
    Paused
}

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject InGameCanvas, PausedCanvas;

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
    }

    public void ChangeCanvas(CanvasStates state)
    {
        currentState = state;

        InGameCanvas.SetActive(currentState == CanvasStates.InGame || currentState == CanvasStates.Paused);

        PausedCanvas.SetActive(currentState == CanvasStates.Paused);
    }
}
