using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector3 cameraTablePosition;
    public Quaternion cameraTableRotation;
    public Vector3 cameraOvenPosition;
    public Quaternion cameraOvenRotation;

    public GameObject ingredientsManager;
    public List<Button> ingredients;

    public Camera theCamera;

    public CootsManager cootsManager;

    private float time;
    private int roundState;
    // Start is called before the first frame update
    void Start()
    {
        theCamera.transform.position = cameraTablePosition;
        theCamera.transform.rotation = cameraTableRotation;
        roundState = 0;
        cootsManager.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if((int)RoundStates.Round1 == roundState)
        {

        }
    }
}
