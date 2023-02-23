using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EggManager : MonoBehaviour
{
    public GameObject egg;
    public GameObject top;
    public GameObject bottom;
    public GameObject cursor;
    public GameObject gameManager;
    public GameObject cootsManager;

    public int cursorSpeed = 100;
    public int score;

    private bool goingUp;
    private Vector3 startingPosition;
    private Vector3 midPoint;
    private float position;
    void OnEnable()
    {
        goingUp = true;
        startingPosition = (top.transform.position + bottom.transform.position)/2;
        score = 0;
        cursor.transform.position = startingPosition;
        position = cursor.transform.position.y;
        egg.SetActive(true);
    }

    private void OnDisable()
    {
        egg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (position <= top.transform.position.y && goingUp)
        {
            position += Time.deltaTime * cursorSpeed;
            cursor.transform.position = new Vector3(startingPosition.x, position, startingPosition.z);
            if(position >= top.transform.position.y)
            {
                goingUp = false;
            }
        }

        else if(position > bottom.transform.position.y && !goingUp)
        {
            position -= Time.deltaTime * cursorSpeed;
            cursor.transform.position = new Vector3(startingPosition.x, position, startingPosition.z);
            if (position <= bottom.transform.position.y)
            {
                goingUp = true;
            }
        }

        if (cootsManager.GetComponent<CootsManager>().cootsSucceeds)
        {
            OnFail();
        }
    }

    public void OnClick()
    {
        
        OnSuccess();
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
