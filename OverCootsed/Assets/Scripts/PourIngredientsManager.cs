using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourIngredientsManager : MonoBehaviour
{
    public int totalGrams;
    public int strength;
    public float time;

    public int currentState;

    public GameObject pourableIngredient;
    public List<GameObject> pourableIngredients;
    public GameObject gameManager;
    public GameObject cootsManager;

    void OnEnable()
    {
        currentState = gameManager.GetComponent<GameManager>().pourIngredientsState;
        pourableIngredient = pourableIngredients[currentState];
        pourableIngredient.SetActive(true);
    }

    private void OnDisable()
    {
        pourableIngredient.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cootsManager.GetComponent<CootsManager>().cootsSucceeds)
        {
            OnFail();
        }
    }

    public void onHold()
    {

    }

    public void onRelease()
    {
       
    }

    public void OnSuccess()
    {
        gameManager.GetComponent<GameManager>().pourIngredientsState++;
        gameManager.GetComponent<GameManager>().ChangeState(true);
    }

    public void OnFail()
    {
        cootsManager.GetComponent<CootsManager>().cootsSucceeds = false;
        gameManager.GetComponent<GameManager>().ChangeState(false);
    }
}
