using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasManager canvasManager;
    bool paused, gameEnded;
    public void OnDisable()
    {
        PlayerScpt.onPlayerDie -= PlayerDeath;
        BossBehaviour.bossDeath -= BossDeath;
    }

    public void OnEnable()
    {
        PlayerScpt.onPlayerDie += PlayerDeath;
        BossBehaviour.bossDeath += BossDeath;
    }

    public void PlayerDeath()
    {
        gameEnded = true;
        //Time.timeScale = 0;
        canvasManager.ChangeCanvas(CanvasStates.GameOver);
    }

    public void BossDeath()
    {
        gameEnded = true;
        //Time.timeScale = 0;
        canvasManager.ChangeCanvas(CanvasStates.Win);
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
