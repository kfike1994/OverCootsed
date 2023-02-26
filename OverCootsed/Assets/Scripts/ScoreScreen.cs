using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour
{
    public int rating;
    public TextMeshProUGUI score;
    public List<GameObject> images;
    // Start is called before the first frame update
    void Start()
    {
        rating = PlayerPrefs.GetInt("rating");
        if (rating == 0)
        {
            images[1].SetActive(true);
            score.text = "You Failed!";
        }

        else if (rating == 1)
        {
            images[0].SetActive(true);
            score.text = "You Did It!";
        }
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
