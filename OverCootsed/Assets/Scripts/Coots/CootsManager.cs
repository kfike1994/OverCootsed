using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CootsManager : MonoBehaviour
{
    public int minTime;
    public int maxTime;
    public float attackTime;
    public bool resetProgress;
    public Button leftHandButton;
    public GameObject leftHand;
    public GameObject leftHandEnd;
    public TextMeshProUGUI leftHandText;
    public Button rightHandButton;
    public GameObject rightHand;
    public GameObject rightHandEnd;
    public TextMeshProUGUI rightHandText;
    public bool leftHovered;
    public bool rightHovered;
    public bool cootsSucceeds;

    private Vector3 leftHandStartPos;
    private Vector3 rightHandStartPos;
    private Vector3 differenceLeft;
    private Vector3 differenceRight;
    public bool mouseHeld;
    private float timer;
    private float cootsTimer;
    private float randomTime;
    private bool cootsActive;
    private int cootsState;
    // Start is called before the first frame update
    void Start()
    {
        leftHovered = false;
        rightHovered = false;
        resetProgress = false;
        cootsActive = false;
        cootsSucceeds = false;
        mouseHeld = false;
        timer = 0;
        randomTime = UnityEngine.Random.Range(minTime, maxTime);
        cootsState = 0;
        leftHandStartPos = leftHand.transform.position;
        rightHandStartPos = rightHand.transform.position;
        differenceLeft = leftHandEnd.transform.position - leftHandStartPos;
        differenceRight = rightHandEnd.transform.position - rightHandStartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseHeld = true;
        }

        else if(Input.GetMouseButtonUp(0))
        {
            mouseHeld = false;
        }

        timer += Time.deltaTime;
        leftHovered = leftHandButton.GetComponent<CootsHands>().hovered;
        rightHovered = rightHandButton.GetComponent<CootsHands>().hovered;

        if (timer >= randomTime || cootsActive)
        {
            timer = 0;
            if (!cootsActive)
            {
                cootsActive = true;
                randomTime = UnityEngine.Random.Range(minTime, maxTime);
                cootsState = UnityEngine.Random.Range(0, 2);
            }

            if ((int)CootsStates.LeftHand == cootsState)
            {
                int percentage = CootsAttackTimer(leftHovered);
                leftHand.transform.position = leftHandStartPos + differenceLeft * ((float)percentage / 100);
                leftHandText.text = percentage + "%";

                if (percentage >= 100)
                {
                    CootsWins();
                    leftHand.transform.position = leftHandStartPos;
                    percentage = 0;
                    cootsTimer = 0;
                    leftHandText.text = percentage + "%";
                }

                else if (percentage < 0)
                {
                    CootsLoses();
                    percentage = 0;
                    cootsTimer = 0;
                    leftHandText.text = percentage + "%";
                }
            }

            else if ((int)CootsStates.RightHand == cootsState)
            {
                int percentage = CootsAttackTimer(rightHovered);
                rightHand.transform.position = rightHandStartPos + differenceRight * ((float)percentage / 100);
                rightHandText.text =  percentage + "%";

                if(percentage >= 100)
                {
                    CootsWins();
                    rightHand.transform.position = rightHandStartPos;
                    percentage = 0;
                    cootsTimer = 0;
                    rightHandText.text = percentage + "%";
                }

                else if(percentage < 0)
                {
                    CootsLoses();
                    percentage = 0;
                    cootsTimer = 0;
                    rightHandText.text = percentage + "%";
                }
            }

            else if ((int)CootsStates.Tail == cootsState)
            {

            }

            else if ((int)CootsStates.Oven == cootsState)
            {

            }
        }
    }

    public int CootsAttackTimer(bool isHovered)
    {
        if (isHovered && !mouseHeld)
        {
            cootsTimer -= Time.deltaTime * 2;
        }

        else
        {
            cootsTimer += Time.deltaTime;
        }

        float percentage = (cootsTimer / attackTime) * 100;
        int timeTillComplete = (int)percentage;

        return timeTillComplete;
    }

    public void CootsWins()
    {
        randomTime = UnityEngine.Random.Range(minTime, maxTime);
        timer = 0;
        cootsActive = false;
        cootsState = 0;
        cootsSucceeds = true;
    }

    public void CootsLoses()
    {
        randomTime = UnityEngine.Random.Range(minTime, maxTime);
        timer = 0;
        cootsActive = false;
        cootsState = 0;
    }
}
