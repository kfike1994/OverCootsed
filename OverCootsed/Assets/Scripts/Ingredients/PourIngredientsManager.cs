using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PourIngredientsManager : MonoBehaviour
{
    public float totalGrams;
    public float currentGrams;
    public float totalStrength;
    public float currentStrength;
    public float time;

    public int currentState;

    public GameObject pourableIngredient;
    public List<GameObject> pourableIngredients;
    public GameObject gameManager;
    public GameObject cootsManager;
    public GameObject info;
    public ParticleSystem particles;

    private bool held;

    void OnEnable()
    {
        currentState = gameManager.GetComponent<GameManager>().pourIngredientsState;
        pourableIngredient = pourableIngredients[currentState];
        totalGrams = pourableIngredient.GetComponent<IngredientStats>().totalGrams;
        totalStrength = pourableIngredient.GetComponent<IngredientStats>().strength;
        currentGrams = 0;
        currentStrength = 0;
        info.GetComponent<TextMeshProUGUI>().text =  currentGrams + " / " + totalGrams;
        held = false;
        info.SetActive(true);
        pourableIngredient.SetActive(true);
    }

    private void OnDisable()
    {
        pourableIngredient.SetActive(false);
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(held)
        {
            time = Time.deltaTime * currentStrength;
            currentGrams += time;

            particles.Play();

            if (currentStrength < totalStrength)
            {
                currentStrength += time;
            }
        }

        else
        {
            if (currentGrams >= totalGrams)
            {
                OnSuccess();
            }

            if(currentStrength > 0)
            {
                time = Time.deltaTime * currentStrength;
                currentGrams += time;
                currentStrength -= 0.01f;
            }

            else 
            {
                particles.Stop();
            }
        }

        if (cootsManager.GetComponent<CootsManager>().cootsSucceeds)
        {
            OnFail();
        }
        info.GetComponent<TextMeshProUGUI>().text = (Math.Round(currentGrams * 100f) / 100f) + " / " + totalGrams + "g";
    }

    public void onHold()
    {
        held = true;
        currentStrength = 1;
    }

    public void onRelease()
    {
        held = false;
    }

    public void OnSuccess()
    {
        gameManager.GetComponent<GameManager>().pourIngredientsState++;
        info.SetActive(false);
        gameManager.GetComponent<GameManager>().ChangeState(true);
    }

    public void OnFail()
    {
        cootsManager.GetComponent<CootsManager>().cootsSucceeds = false;
        info.SetActive(false);
        gameManager.GetComponent<GameManager>().ChangeState(false);
    }
}
