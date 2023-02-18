using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector3 cameraTablePosition;
    public Quaternion cameraTableRotation;
    public Vector3 cameraOvenPosition;
    public Quaternion cameraOvenRotation;

    public List<GameObject> theStates;

    public Camera theCamera;

    public CootsManager cootsManager;

    public int pourIngredientsState;

    private float time;
    private int currentState;
    private int gamePhase;
    // Start is called before the first frame update
    void Start()
    {
        theCamera.transform.position = cameraTablePosition;
        theCamera.transform.rotation = cameraTableRotation;
        currentState = 0;
        gamePhase = 0;
        pourIngredientsState = 0;
        cootsManager.enabled = true;

        theStates[currentState].SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public void ChangeState(bool isSuccess)
    {
        if (isSuccess)
        {
            theStates[currentState].SetActive(false);
            currentState++;
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
        }
    }
}
