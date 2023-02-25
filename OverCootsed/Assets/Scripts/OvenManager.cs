using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OvenManager : MonoBehaviour
{
    public bool isOvenOn;
    public float preheatTime;
    public int totalPreheatTime;

    public Image progressBar;

    public TextMeshProUGUI textOfButton;

    // Start is called before the first frame update
    void Start()
    {
        isOvenOn = false;
        preheatTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOvenOn)
        {
            if (preheatTime < totalPreheatTime)
            {
                preheatTime += Time.deltaTime;
                progressBar.fillAmount = preheatTime/(float)totalPreheatTime;
            }
        }

        else
        {
            if(preheatTime >= 0)
            {
                preheatTime -= Time.deltaTime;
                progressBar.fillAmount = preheatTime / (float)totalPreheatTime;
            }
        }
    }

    public void OnOvenClick()
    {
        if (isOvenOn) 
        {
            isOvenOn = false;
            textOfButton.text = "Oven Is Off";
        }
        
        else
        {
            isOvenOn = true;
            textOfButton.text = "Oven Is On";
        }
    }
}
