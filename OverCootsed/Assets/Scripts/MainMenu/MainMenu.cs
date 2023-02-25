using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnCreditsClick()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
}
