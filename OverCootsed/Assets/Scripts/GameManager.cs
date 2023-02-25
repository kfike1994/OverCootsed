using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector3 cameraTablePosition;
    public Vector3 cameraTableRotation;
    public Vector3 cameraOvenPosition;
    public Vector3 cameraOvenRotation;

    public List<GameObject> theStates;

    public Camera theCamera;

    public CootsManager cootsManager;
    public GameObject ovenManager;

    public GameObject cookingCanvas;
    public GameObject cootsCanvas;
    public GameObject ovenCanvas;
    public GameObject informationText;

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
            if(time <= 5)
            {
                if (successScreen)
                {
                    informationText.SetActive(true);
                    informationText.GetComponent<TextMeshProUGUI>().text = "NICE!";
                }

                else
                {
                    informationText.SetActive(true);
                    informationText.GetComponent<TextMeshProUGUI>().text = "GET COOTSED!";
                }
            }

            else
            {
                Time.timeScale = 1;
                time = 0;
                informationText.SetActive(false);
            }
        }
    }

    public void ChangeState(bool isSuccess)
    {
        if (isSuccess)
        {
            theStates[currentState].SetActive(false);
            currentState++;
            Time.timeScale = 0;
            successScreen = true;
            theStates[currentState].SetActive(true);
        }

        else
        {
            if(currentState <= 6)
            {
                theStates[currentState].SetActive(false);
                currentState = 0;
                pourIngredientsState = 0;
                theStates[currentState].SetActive(true);
            }

            else if(currentState <= 10)
            {
                theStates[currentState].SetActive(false);
                currentState = 7;
                pourIngredientsState = 3;
                theStates[currentState].SetActive(true);
            }

            else if (currentState <= 14)
            {
                theStates[currentState].SetActive(false);
                currentState = 11;
                pourIngredientsState = 6;
                theStates[currentState].SetActive(true);
            }

            else if (currentState <= 16)
            {
                theStates[currentState].SetActive(false);
                currentState = 15;
                pourIngredientsState = 8;
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
}
