 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{  
    
    float currentTime;
    public float startingTime = 10f;
    private float update;

    FailScreen Failed;
    [SerializeField] TMP_Text countdownText;

    void Awake()
    {
        update = 0.0f;
    }
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {    
        update += Time.deltaTime;
        if (update > 5.0f)   
        {
            currentTime -= 1 * 2 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0.1f)
            {
                currentTime = 0;
            
            }
        }

    }
      
}