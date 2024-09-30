using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasManager canvasManager;
    [SerializeField] BossBehaviour bossBehaviour;
    [SerializeField] PlayerScpt player;

    [SerializeField] Vector3 initialPos, tutorialPos;

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

    private void Awake()
    {
        if(IsTutorial.isTutorial)
            player.transform.position = tutorialPos;
        else
            player.transform.position = initialPos;
    }

    public void PlayerDeath()
    {
        bossBehaviour.GoToSleep();
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

    public void ScreenFreeze()
    {

        if (Time.timeScale != 0)
        {
            StartCoroutine(FreezeScreen(0.03f));
        }

    }

    public void ScreenFreeze(float freezeTime)
    {
        
        if(Time.timeScale != 0)
        {
            StartCoroutine(FreezeScreen(freezeTime));
        }

    }

    IEnumerator FreezeScreen(float freezeTime)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(freezeTime);
        Time.timeScale = 1;
    }
}
