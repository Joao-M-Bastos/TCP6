using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
