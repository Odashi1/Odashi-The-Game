using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour
{

    public void NextLvL1()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1.0f;
    }
    public void NextLvL2()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1.0f;
    }

    public void NextLvL3()
    {
        SceneManager.LoadScene("Level 3");
        Time.timeScale = 1.0f;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
