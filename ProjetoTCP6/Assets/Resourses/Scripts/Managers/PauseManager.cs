using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public void SairDoJogo()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
