using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsMiniGameTutorial : MonoBehaviour
{
     private float update;

    void Awake()
    {
        update = 0.0f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        update += Time.deltaTime;
        if (update > 4.0f)
        {
            GetComponent<Renderer>().enabled=false;
            
        }
    }
}
