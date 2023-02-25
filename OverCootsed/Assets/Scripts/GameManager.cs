using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameTimer;

    public Vector3 cameraTablePosition;
    public Vector3 cameraTableRotation;
    public Vector3 cameraOvenPosition;
    public Vector3 cameraOvenRotation;

    public List<GameObject> theStates;
    //I know this is dirty, but I am running out of time.
    public List<string> theStatesText;

    public Camera theCamera;

    public CootsManager cootsManager;
    public GameObject ovenManager;

    public float score;

    public GameObject cookingCanvas;
    public GameObject cootsCanvas;
    public GameObject ovenCanvas;
    public GameObject informationText;
    public GameObject informationImage;
    public TextMeshProUGUI currentTask;
    public TextMeshProUGUI completedTasks;
    public TextMeshProUGUI timerText;

    public GameObject switchSceneText;

    public int pourIngredientsState;

    private float time;
    private bool successScreen;
    private bool cookingScreen;
    private int currentState;
    private int gamePhase;
    // Start is called before the first frame update
    void Start()
    {
        theCamera.transform.position = cameraTablePosition;
        theCamera.transform.rotation = Quaternion.Euler(cameraTableRotation);
        currentState = 0;
        gamePhase = 0;
        pourIngredientsState = 0;
        score = 0;
        cootsManager.enabled = true;

        cookingScreen = true;

        ovenCanvas.transform.position = new Vector3(10000, 0, 0);

        theStates[currentState].SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            time += Time.unscaledDeltaTime;
            if(time <= 3)
            {
                if (successScreen)
                {
                    informationImage.SetActive(true);
                    informationText.GetComponent<TextMeshProUGUI>().text = "NICE!";
                }

                else
                {
                    informationImage.SetActive(true);
                    informationText.GetComponent<TextMeshProUGUI>().text = "GET COOTSED!";
                }
            }

            else
            {
                Time.timeScale = 1;
                time = 0;
                informationImage.SetActive(false);
            }
        }

        gameTimer -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(gameTimer / 60);
        float seconds = Mathf.FloorToInt(gameTimer % 60);

        timerText.text = "Time Left: " + string.Format("{0:00} : {1:00}", minutes, seconds);

        if(gameTimer <= 0)
        {
            OnGameEnd(true);
        }

        if(currentState == 16 && ovenManager.GetComponent<OvenManager>().progressBar.fillAmount == 1)
        {
            OnGameEnd(false);
        }
    }

    public void ChangeState(bool isSuccess)
    {
        if (isSuccess)
        {
            theStates[currentState].SetActive(false);
            currentState++;
            completedTasks.text = "Task: " + currentState + "/" + theStates.Count; 
            Time.timeScale = 0;
            successScreen = true;
            if (currentState < theStates.Count)
            {
                theStates[currentState].SetActive(true);
                currentTask.text = theStatesText[currentState];
            }

            else if(ovenManager.GetComponent<OvenManager>().progressBar.fillAmount == 1)
            {
                OnGameEnd(false);
            }
        }

        else
        {
            if(currentState <= 6)
            {
                theStates[currentState].SetActive(false);
                currentState = 0;
                pourIngredientsState = 0;
                currentTask.text = theStatesText[currentState];
                completedTasks.text = "Task: " + currentState + "/" + theStates.Count;
                theStates[currentState].SetActive(true);
            }

            else if(currentState <= 10)
            {
                theStates[currentState].SetActive(false);
                currentState = 7;
                pourIngredientsState = 3;
                currentTask.text = theStatesText[currentState];
                completedTasks.text = "Task: " + currentState + "/" + theStates.Count;
                theStates[currentState].SetActive(true);
            }

            else if (currentState <= 15)
            {
                theStates[currentState].SetActive(false);
                currentState = 11;
                pourIngredientsState = 6;
                currentTask.text = theStatesText[currentState];
                completedTasks.text = "Task: " + currentState + "/" + theStates.Count;
                theStates[currentState].SetActive(true);
            }

            Time.timeScale = 0;
            successScreen = false;
        }
    }

    public void OnSceneSwitch()
    {
        if (cookingScreen)
        {
            cookingCanvas.transform.position = new Vector3(10000, 0, 0); 
            cootsCanvas.transform.position = new Vector3(10000, 0, 0);
            ovenCanvas.transform.localPosition = new Vector3(0, 0, 0);

            switchSceneText.GetComponent<TextMeshProUGUI>().text = "To Counter";

            theCamera.transform.position = cameraOvenPosition;
            theCamera.transform.rotation = Quaternion.Euler(cameraOvenRotation);
            cookingScreen = false;
        }

        else
        {
            cookingCanvas.transform.localPosition = new Vector3(0, 0, 0);
            cootsCanvas.transform.localPosition = new Vector3(0, 0, 0);
            ovenCanvas.transform.position = new Vector3(10000, 0, 0);

            switchSceneText.GetComponent<TextMeshProUGUI>().text = "To Oven";

            theCamera.transform.position = cameraTablePosition;
            theCamera.transform.rotation = Quaternion.Euler(cameraTableRotation);
            cookingScreen = true;
        }
    }

    public void OnGameEnd(bool cootsDominated)
    {
        if(cootsDominated)
        {
            PlayerPrefs.SetFloat("rating", 0);
            Time.timeScale = 1;
            SceneManager.LoadScene("ScoreScreen");
        }

        else
        {
            PlayerPrefs.SetFloat("rating", 1);
            Time.timeScale = 1;
            SceneManager.LoadScene("CootsMinigame");
        }
    }
}
