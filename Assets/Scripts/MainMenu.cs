using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Win");
        Time.timeScale = 1.0f;  
    }


    public void QuitButton()
    {
        Application.Quit();
    }
}
