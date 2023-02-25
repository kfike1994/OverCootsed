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
    public GameObject cootsShadow;
    public GameObject cootsBlockButton;
    public GameObject cootsShadowEnd;
    public GameObject OvenManager;
    public bool leftHovered;
    public bool rightHovered;
    public bool shadowHovered;
    public bool cootsSucceeds;

    private Vector3 leftHandStartPos;
    private Vector3 rightHandStartPos;
    private Vector3 cootsShadowStartPos;
    private Vector3 differenceLeft;
    private Vector3 differenceRight;
    private Vector3 differenceShadow;
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
        shadowHovered = false;
        resetProgress = false;
        cootsActive = false;
        cootsSucceeds = false;
        mouseHeld = false;
        timer = 0;
        randomTime = UnityEngine.Random.Range(minTime, maxTime);
        cootsState = 0;
        leftHandStartPos = leftHand.transform.localPosition;
        rightHandStartPos = rightHand.transform.localPosition;
        cootsShadowStartPos = cootsShadow.transform.position;
        differenceLeft = leftHandEnd.transform.localPosition - leftHandStartPos;
        differenceRight = rightHandEnd.transform.localPosition - rightHandStartPos;
        differenceShadow = cootsShadowEnd.transform.position - cootsShadowStartPos;
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
        shadowHovered = cootsBlockButton.GetComponent<CootsTail>().hovered;

        if (timer >= randomTime || cootsActive)
        {
            timer = 0;
            if (!cootsActive)
            {
                cootsActive = true;
                randomTime = UnityEngine.Random.Range(minTime, maxTime);
                cootsState = UnityEngine.Random.Range(0, 4);
            }

            if ((int)CootsStates.LeftHand == cootsState)
            {
                int percentage = CootsAttackTimer(leftHovered);
                leftHand.transform.localPosition = leftHandStartPos + differenceLeft * ((float)percentage / 100);
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
                rightHand.transform.localPosition = rightHandStartPos + differenceRight * ((float)percentage / 100);
                rightHandText.text =  percentage + "%";

                if(percentage >= 100)
                {
                    CootsWins();
                    rightHand.transform.localPosition = rightHandStartPos;
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
                int percentage = CootsTailAttackTimer(shadowHovered);
                cootsShadow.transform.position = cootsShadowStartPos + differenceShadow * ((float)percentage / 100);
                if (percentage >= 50 && percentage <= 90 && !shadowHovered)
                {
                    CootsWins();
                    percentage = 0;
                    cootsTimer = 0;
                    cootsShadow.transform.position = cootsShadowStartPos;
                }

                else if(percentage >= 100)
                {
                    CootsLoses();
                    percentage = 0;
                    cootsTimer = 0;
                    cootsShadow.transform.position = cootsShadowStartPos;
                }
            }

            else if ((int)CootsStates.Oven == cootsState)
            {
                CootsLoses();
                OvenManager.GetComponent<OvenManager>().isOvenOn = false;
                OvenManager.GetComponent<OvenManager>().textOfButton.text = "Oven Is Off";
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

    public int CootsTailAttackTimer(bool isHovered)
    {
        cootsTimer += Time.deltaTime;
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
