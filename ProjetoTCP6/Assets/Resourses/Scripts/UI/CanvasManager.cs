using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CanvasStates{
    InGame,
    Paused,
    GameOver,
    Win
}

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject InGameCanvas, PausedCanvas, GameOverCanva, WinCanvas;
    [SerializeField] GameObject InventoryCanva;

    CanvasStates currentState;

    private void Start()
    {
        ChangeCanvas(CanvasStates.InGame);
    }

    public void PauseClicked()
    {
        if (currentState != CanvasStates.InGame)
            ChangeCanvas(CanvasStates.InGame);
        else ChangeCanvas(CanvasStates.Paused);
    }

    public void ChangeCanvas(CanvasStates state)
    {
        currentState = state;


        InGameCanvas.SetActive(currentState == CanvasStates.InGame);

        PausedCanvas.SetActive(currentState == CanvasStates.Paused);

        GameOverCanva.SetActive(currentState == CanvasStates.GameOver);

        WinCanvas.SetActive(currentState == CanvasStates.Win);

        InventoryCanva.SetActive(InGameCanvas.activeSelf);
    }
}
