using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CanvasStates{
    InGame,
    Paused,
    GameOver,
    Dialogue,
    Win
}

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject InGameCanvas, PausedCanvas, GameOverCanva, WinCanvas, DialogueCanvas;
    [SerializeField] GameObject InventoryCanva;

    CanvasStates currentState;

    private void OnEnable()
    {
        DialogueManager.dialogueStart += SetDialogue;
        DialogueManager.dialogueEnd += UnSetDialogue;
    }

    private void OnDisable()
    {
        DialogueManager.dialogueStart -= SetDialogue;
        DialogueManager.dialogueEnd -= UnSetDialogue;
    }

    private void Start()
    {
        ChangeCanvas(CanvasStates.InGame);
    }

    public void SetDialogue()
    {
        ChangeCanvas(CanvasStates.Dialogue);
    }

    public void UnSetDialogue()
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


        InGameCanvas.SetActive(currentState == CanvasStates.InGame || currentState == CanvasStates.Dialogue);

        PausedCanvas.SetActive(currentState == CanvasStates.Paused);

        GameOverCanva.SetActive(currentState == CanvasStates.GameOver);

        WinCanvas.SetActive(currentState == CanvasStates.Win);

        DialogueCanvas.SetActive(currentState == CanvasStates.Dialogue);

        InventoryCanva.SetActive(InGameCanvas.activeSelf);
    }
}
