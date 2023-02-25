using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CootsTail : MonoBehaviour
{
    public bool hovered;
    public bool cootsActive;
    public int perceantageCompleted;
    public float totalTime;

    public GameObject theButton;
    public Color onHoverColor;
    public Color offHoverColor;

    public void onHover()
    {
        hovered = true;
        theButton.GetComponent<Image>().color = onHoverColor;
    }

    public void onExit()
    {
        hovered = false;
        theButton.GetComponent<Image>().color = offHoverColor;
    }
}
