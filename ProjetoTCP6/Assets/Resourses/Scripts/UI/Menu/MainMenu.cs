using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Sair()
    {
        Application.Quit();
    }

    public void StartInTutorial()
    {
        IsTutorial.isTutorial = true;
        LoadGameScene();
    }

    public void StartNormalGame()
    {
        IsTutorial.isTutorial = false;
        LoadGameScene();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
