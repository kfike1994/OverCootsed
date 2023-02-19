using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ButterManager : MonoBehaviour
{
    public GameObject butter;
    public GameObject gameManager;
    public GameObject cootsManager;
    void OnEnable()
    {
        butter.SetActive(true);
    }

    private void OnDisable()
    {
        butter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cootsManager.GetComponent<CootsManager>().cootsSucceeds)
        {
            OnFail();
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
