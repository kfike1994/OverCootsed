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
    public Button leftHand;
    public TextMeshProUGUI leftHandText;
    public Button rightHand;
    public TextMeshProUGUI rightHandText;
    public bool leftHovered;
    public bool rightHovered;
    public bool cootsSucceeds;

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
        timer = 0;
        randomTime = UnityEngine.Random.Range(minTime, maxTime);
        cootsState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        leftHovered = leftHand.GetComponent<CootsHands>().hovered;
        rightHovered = rightHand.GetComponent<CootsHands>().hovered;

        if (timer >= randomTime || cootsActive)
        {
            timer = 0;
            if (!cootsActive)
            {
                cootsActive = true;
                randomTime = UnityEngine.Random.Range(minTime, maxTime);
                cootsState = UnityEngine.Random.Range(0, 2);
                Debug.Log(cootsState);
            }

            if ((int)CootsStates.LeftHand == cootsState)
            {
                int percentage = CootsAttackTimer(leftHovered);
                leftHandText.text = percentage + "%";

                if (percentage >= 100)
                {
                    CootsWins();
                }

                if (percentage < 0)
                {
                    CootsLoses();
                    percentage = 0;
                    leftHandText.text = percentage + "%";
                }
            }

            else if ((int)CootsStates.RightHand == cootsState)
            {
                int percentage = CootsAttackTimer(rightHovered);
                rightHandText.text =  percentage + "%";

                if(percentage >= 100)
                {
                    CootsWins();
                    percentage = 0;
                }

                if(percentage < 0)
                {
                    CootsLoses();
                    percentage = 0;
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
        if (isHovered)
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
