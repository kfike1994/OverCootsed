using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingIngredientsManager : MonoBehaviour
{
    public GameObject mixingIngredient;
    public GameObject gameManager;
    public GameObject cootsManager;
    void OnEnable()
    {
        mixingIngredient.SetActive(true);
    }

    private void OnDisable()
    {
        mixingIngredient.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (cootsManager.GetComponent<CootsManager>().cootsSucceeds)
        {
            OnFail();
        }
    }

    public void OnClick()
    {

    }

    public void OnSuccess()
    {
        gameManager.GetComponent<GameManager>().ChangeState(true);
    }

    public void OnFail()
    {
        cootsManager.GetComponent<CootsManager>().cootsSucceeds = false;
        gameManager.GetComponent<GameManager>().ChangeState(false);
    }
}
