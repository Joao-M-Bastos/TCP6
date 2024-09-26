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
        canvasManager.ChangeCanvas(CanvasStates.GameOver);
    }

    public void BossDeath()
    {
        gameEnded = true;
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

    public void ScreenPause()
    {

        if (Time.timeScale != 0)
        {
            StartCoroutine(PauseScree(0.03f));
        }

    }

    public void ScreenPause(float pauseTime)
    {
        
        if(Time.timeScale != 0)
        {
            StartCoroutine(PauseScree(pauseTime));
        }

    }

    IEnumerator PauseScree(float pauseTime)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1;
    }
}
