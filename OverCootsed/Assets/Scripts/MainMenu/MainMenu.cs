using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayClick()
    {
        SceneManager.LoadScene("TutorialScreen");
    }

    public void OnCreditsClick()
    {
        SceneManager.LoadScene("MyScene");
    }

    public void OnExitClick()
    {

    }
}
