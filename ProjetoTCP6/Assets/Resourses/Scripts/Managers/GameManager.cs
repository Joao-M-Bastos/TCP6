using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasManager canvasManager;
    bool paused, gameEnded;
    private void Awake()
    {
        PlayerScpt.onPlayerDie += PlayerDeath;
    }
    public void PlayerDeath()
    {
        gameEnded = true;
        canvasManager.ChangeCanvas(CanvasStates.GameOver);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !gameEnded)
            Pause();
    }

    public void Pause()
    {
            canvasManager.PauseClicked();

            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
            }
        
    }
}
