using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixingIngredientsManager : MonoBehaviour
{
    public GameObject mixingIngredient;
    public GameObject gameManager;
    public GameObject cootsManager;

    public Image progressBar;

    public int currentMixes;
    public float fillSpeed = 0.05f;
    public int totalMixes;
    void OnEnable()
    {
        mixingIngredient.SetActive(true);
        progressBar.fillAmount = 0;
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
        progressBar.fillAmount += fillSpeed;

        if(progressBar.fillAmount == 1)
        {
            OnSuccess();
        }
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
