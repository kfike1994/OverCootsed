using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManager : MonoBehaviour
{
    public GameObject egg;
    public GameObject gameManager;
    public GameObject cootsManager;
    void OnEnable()
    {
        egg.SetActive(true);
    }

    private void OnDisable()
    {
        egg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cootsManager.GetComponent<CootsManager>().cootsSucceeds)
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
