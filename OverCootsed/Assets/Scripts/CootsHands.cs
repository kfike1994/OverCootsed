using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CootsHands : MonoBehaviour
{
    public bool hovered;
    public bool cootsActive;
    public int perceantageCompleted;
    public float totalTime;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onHover()
    {
        hovered = true;
    }

    public void onExit()
    {
        hovered = false;
    }
}
